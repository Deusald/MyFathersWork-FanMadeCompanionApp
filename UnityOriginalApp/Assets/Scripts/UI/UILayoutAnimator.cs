using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this scr
/// </summary>

public enum AnimationSide
{
    Left,
    Right,
    Top,
    Buttom
};

[RequireComponent(typeof(CanvasGroup))]
public class UILayoutAnimator : MonoBehaviour
{
    //Side of Animation 
    public AnimationSide animationSide;

    //Offset
    [Range(0.01f, 1f)]
    public float StartPosition = 0.01f;

    //Animation Timeing
    //[Range(0.5f,5)]
    private float AnimationTimeing = 2f;

    //Animation type
    public iTween.EaseType easeType = iTween.EaseType.easeInOutQuart;

    //Canvas reference
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }


    public void PlayLayoutAnimation()
    {
        canvasGroup.alpha = 0;
        if (animationSide == AnimationSide.Left)
        {
            float xPos = rectTransform.position.x;
            rectTransform.position += Vector3.left * StartPosition;
            iTween.MoveTo(this.gameObject, iTween.Hash("x", xPos, "time", AnimationTimeing, "easeType", easeType));

        }
        else if (animationSide == AnimationSide.Right)
        {
            float xPos = rectTransform.position.x;
            rectTransform.position += Vector3.right * StartPosition;
            iTween.MoveTo(this.gameObject, iTween.Hash("x", xPos, "time", AnimationTimeing, "easeType", easeType));

        }
        else if (animationSide == AnimationSide.Top)
        {
            float yPos = rectTransform.position.y;
            rectTransform.position += Vector3.up * StartPosition;
            iTween.MoveTo(this.gameObject, iTween.Hash("y", yPos, "time", AnimationTimeing, "easeType", easeType));
        }
        else if (animationSide == AnimationSide.Buttom)
        {
            float yPos = rectTransform.position.y;
            rectTransform.position += Vector3.down * StartPosition;
            iTween.MoveTo(this.gameObject, iTween.Hash("y", yPos, "time", AnimationTimeing, "easeType", easeType));
        }

        iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", AnimationTimeing,
               "onupdatetarget", gameObject, "onupdate", "tweenOnUpdateCallBack", "easetype", iTween.EaseType.linear));
    }
    void tweenOnUpdateCallBack(float newValue)
    {
        canvasGroup.alpha = newValue;
    }
}
