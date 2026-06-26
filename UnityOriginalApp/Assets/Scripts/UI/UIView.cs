using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum AnimationDirection
{
    left,
    right
}

public class UIView : MonoBehaviour
{
    private Camera cam;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private UILayoutAnimator[] uiLayoutAnimators;
    private bool isStop = false;
    private float AnimationTimeing = 0.7f;
    private GameObject _gameObject;

    public virtual void Awake()
    {
        cam = this.GetComponent<Camera>();
        canvas = this.GetComponent<Canvas>();
        canvasGroup = this.GetComponent<CanvasGroup>();
        uiLayoutAnimators = this.GetComponentsInChildren<UILayoutAnimator>();
        this.transform.GetChild(0).transform.localPosition = Vector3.zero;
        _gameObject = this.transform.GetChild(0).gameObject;
    }

    public virtual void ShowAnimated()
    {
        canvas.enabled = true;
        _gameObject.SetActive(true);
        ViewController.instance.screenTransitionAnim.gameObject.GetComponent<Image>().raycastTarget = true;
        ViewController.instance.screenTransitionAnim.Play("TransitionAnimRev");
        Canvas.ForceUpdateCanvases();
        Invoke(nameof(startAnimation), 0f);
    }

    public virtual void HideAnimated()
    {

        ViewController.instance.screenTransitionAnim.Play("TransitionAnim");
        Invoke(nameof(setActiveFalse), 0.5f);
        Canvas.ForceUpdateCanvases();
    }

    public virtual void Hide()
    {
        _gameObject.SetActive(false);
        canvas.enabled = false;
    }

    public virtual void Show()
    {
        _gameObject.SetActive(true);
        canvas.enabled = true;
    }

    void startAnimation()
    {
        foreach (UILayoutAnimator uiAnimator in uiLayoutAnimators)
            uiAnimator.PlayLayoutAnimation();
    }

    void setActiveFalse()
    {
        _gameObject.SetActive(false);
        canvas.enabled = false;
    }

    void setActiveTrue()
    {
        canvas.enabled = true;
        _gameObject.SetActive(true);
        ViewController.instance.screenTransitionAnim.gameObject.GetComponent<Image>().raycastTarget = false;
    }

    void tweenOnUpdateCallBack(float newValue) => canvasGroup.alpha = newValue;

    //Start Animation of popup open
    public void ShowPopAnimation(GameObject Popup) => Popup.SetActive(true);
    //Close popup animtion
    public void closePopAnimation(GameObject Popup) => StartCoroutine(HidePopup(Popup));
    //Wait for time and deactive
    IEnumerator HidePopup(GameObject popup)
    {
        popup.GetComponent<Animator>().Play("PopupClose");
        yield return new WaitForSeconds(0.2f);
        popup.SetActive(false);
    }
}