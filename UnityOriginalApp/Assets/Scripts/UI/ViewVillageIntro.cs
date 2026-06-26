using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewVillageIntro : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewVillageIntro instance;
    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public TextMeshProUGUI descriptionText;
    [HideInInspector]
    public GameObject goBackConfirmationPanel;
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();
    //[HideInInspector]
    public string[] villageIntro1 = new string[7];
    //[HideInInspector]
    public string[] villageIntro2 = new string[7];
    [HideInInspector]
    public Animator _animator;
    #endregion


    #region UNITY_CALLBACKS
    void Start()
    {
        instance = this;

    }
    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        SetDescriptionText();
        if (clip != null)
            PlayBGSound(true);
    }
    public void SetDescriptionText()
    {
        descriptionText.text = villageIntro1[PlayerPrefs.GetInt("language", 0)] + ", <B>" + GLOBALS.townName + "</B> " + villageIntro2[PlayerPrefs.GetInt("language", 0)];
        _animator.SetTrigger("start");
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();

    }
    public override void Hide() => base.Hide();

    public void OnAcceptBtn() => ViewController.instance.ChangeView(ViewController.instance.scenarios);

    public void GoBackbtn()
    {
        ShowPopAnimation(goBackConfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
            reWritePanelText[i].UpdateButtonText(index);
    }

    public void HideGoBackbtn() => closePopAnimation(goBackConfirmationPanel);

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    //public void SetCurrentStoryPassage(string PassageName) => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);

    public void OnBackBtnPress() => ViewController.instance.ChangeView(ViewController.instance.villageEntry);

    #endregion
}
