using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Febucci.UI;

public class ViewPopupPanel : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewPopupPanel instance;
    [HideInInspector]
    public TextMeshProUGUI popupMessageText;
    [HideInInspector]
    public TMP_InputField inputField;
    [HideInInspector]
    public TextMeshProUGUI storyContentObject;
    [HideInInspector]
    public Animator _animator;
    [HideInInspector]
    public bool isPopupOpen = false;

    public string passageName;
    public int valueNumber;
    public string valueString;
    bool isWaiting = false;

    #endregion
    #region PRIVATE_VARS
    private bool isNumber = true;

    #endregion

    #region UNITY_CALLBACKS


    void Start()
    {
        instance = this;
        inputField.text = "";
        valueNumber = -1;
        valueString = "";
    }
    #endregion

    #region PUBLIC_METHODS
    public override void ShowAnimated() => base.ShowAnimated();
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide()
    {
        base.Hide();
        isPopupOpen = false;
    }
    public override void Show()
    {
        base.Show();
        isPopupOpen = true;
        _animator.SetTrigger("OnEnable");
    }
    public void SetPopupData(string message) => popupMessageText.text = message;
    public void Clear() => inputField.text = "";

    public void OnGenerationBtn(string passageName, string promptMassage, string contentType, float time)
    {
        inputField.text = "";
        if (contentType == "number")
        {
            isNumber = true;
            inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        }
        else if (contentType == "string")
        {
            isNumber = false;
            inputField.contentType = TMP_InputField.ContentType.Name;
        }
        else if (contentType == "password")
        {
            isNumber = false;
            inputField.contentType = TMP_InputField.ContentType.Password;
        }

        popupMessageText.text = promptMassage;
        this.passageName = passageName;
        if (!isPopupOpen)
            Invoke(nameof(Show), time);
    }

    public void hidePopupManu()
    {
        if (inputField.text != "" && !isWaiting)
        {
            StopCoroutine(nameof(delayInAnimation));
            StartCoroutine(nameof(delayInAnimation));
            if (isNumber)
            {
                if (int.Parse(inputField.text) >= 0)
                {
                    isPopupOpen = false;
                    valueNumber = int.Parse(inputField.text);
                    //Debug.Log("if ==>" + valueNumber);
                    Invoke(nameof(Hide), 0.2f);
                    SetCurrentStoryPassage(passageName);
                }
            }
            else
            {
                isPopupOpen = false;
                valueString = inputField.text;
                //Debug.Log("else==>" + valueString);
                Invoke(nameof(Hide), 0.2f);
                SetCurrentStoryPassage(passageName);
            }
        }
    }

    IEnumerator delayInAnimation()
    {
        isWaiting = true;
        storyContentObject.gameObject.GetComponent<TextAnimatorPlayer>().enabled = false;
        yield return new WaitForSeconds(1);
        isWaiting = false;
        storyContentObject.gameObject.GetComponent<TextAnimatorPlayer>().enabled = true;
    }

    public void SetCurrentStoryPassage(string PassageName) => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);

    public string PassageValueString() => valueString;

    public int PassageValueNumber() => valueNumber;
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
