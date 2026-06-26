using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;
using System;

public class ViewItemObtainHUB : UIView
{
    #region PUBLIC_VARS
    public static ViewItemObtainHUB instance;

    [HideInInspector]
    public TextMeshProUGUI titleText;
    [HideInInspector]
    public TextMeshProUGUI detailText;
    [HideInInspector]
    public Image ItemIcon;
    [HideInInspector]
    public AudioClip clip;
    public static bool isEndOfRoundOpen = false;
    [HideInInspector]
    public Button continueBtn;

    private int LanguageIndex => PlayerPrefs.GetInt("language", 0);
    private int StoryIndex => PlayerPrefs.GetInt("storyName", 0);

    #endregion

    #region UNITY_CALLBACK
    private void Start() => instance = this;
    #endregion

    #region PUBLIC_METHOD
    public override void ShowAnimated()
    {
        if (!isEndOfRoundOpen && titleText.text != "" && detailText.text != "")
        {
            base.ShowAnimated();
            if (clip != null) SoundManager.Instance.OnOpenPopupPlayAudio(clip);
        }
    }
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide()
    {
        titleText.SetText("");
        detailText.SetText("");
        base.Hide();
    }
    public override void Show() => base.Show();

    /// <summary>
    /// Set text in obtaian item
    /// </summary>
    /// <param name="title"></param>
    /// <param name="detail"></param>
    /// <param name="time"></param>
    public void SetupItemObtain(string title, string detail, float time)
    {
        titleText.SetText(title);
        detailText.SetText(detail);
        string setupImageName = "";
        Action<string> setupImageCallBack = (string name) => setupImageName = name;
        ViewItemObtain.s_OnSetIconSpriteName?.Invoke(LanguageIndex, StoryIndex, setupImageCallBack);
        if (setupImageName == "") setupImageName = "MFWlogo";
        ItemIcon.sprite = Resources.Load<Sprite>("setupImages/" + setupImageName);
        Invoke(nameof(ShowAnimated), time);
    }

    /// <summary>
    /// hide popup menu
    /// </summary>
    public void HideItemObtain() => Invoke(nameof(Hide), 0.3f);
    #endregion
}
