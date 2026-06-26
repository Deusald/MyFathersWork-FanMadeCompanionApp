using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cradle.Players;
using System;

public class ViewItemObtain : UIView
{
    #region PUBLIC_VARS
    public static ViewItemObtain instance;

    public static Action<int, int, Action<string>> s_OnSetIconSpriteName;

    [HideInInspector]
    public TextMeshProUGUI titleText;
    [HideInInspector]
    public TextMeshProUGUI detailText;
    [HideInInspector]
    public Image ItemICon;
    [SerializeField]
    public AudioClip clip;
    public static string SetupPassagename = "";
    [HideInInspector]
    public Button continueBtn;

    private int LanguageIndex => PlayerPrefs.GetInt("language", 0);
    private int StoryIndex => PlayerPrefs.GetInt("storyName", 0);
    bool ispressed = true;
    #endregion

    #region UNITY_CALLBACK

    private void Start() => instance = this;
    #endregion

    #region PUBLIC_METHOD
    public override void ShowAnimated()
    {
        base.ShowAnimated();
        ispressed = true;
        if (clip != null)
            SoundManager.Instance.OnOpenPopupPlayAudio(clip);
    }
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide()
    {
        ispressed = true;
        titleText.SetText("");
        detailText.SetText("");
        base.Hide();
    }

    public override void Show() => base.Show();

    public void ShowItemObtsInPopup(string titleName, string detail)
        => this.InvokeDelay(() =>
        {
            titleText.text = titleName;
            detailText.text = detail;
            string setupImageName = "";
            Action<string> setupImageCallBack = (string name) => setupImageName = name;
            s_OnSetIconSpriteName?.Invoke(LanguageIndex, StoryIndex, setupImageCallBack);
            if (setupImageName == "") setupImageName = "MFWlogo";
            ItemICon.sprite = Resources.Load<Sprite>("setupImages/" + setupImageName);
            Invoke(nameof(ShowAnimated), 0.1f);
        }, 0.25f);

    /// <summary>
    /// hide popup menu
    /// </summary>
    public void HideItemObtain()
    {
        if (ispressed)
        {
            ispressed = false;
            this.InvokeDelay(() =>
            {
                TwineStoryPlayer.instance.GoToCurrentProgress(SetupPassagename);
                Hide();
            }, 0.3f);
        }
    }

    #endregion

    #region PRIVATE_METHODS
    #endregion
}