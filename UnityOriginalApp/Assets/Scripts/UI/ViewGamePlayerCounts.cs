using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ViewGamePlayerCounts : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewGamePlayerCounts instance;
    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public GameObject goBackConfirmationPanel;
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();

    #endregion


    #region UNITY_CALLBACKS

    void Start() => instance = this;

    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        if (clip != null)
            PlayBGSound(true);
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();

    }
    public override void Hide() => base.Hide();

    public void GoBackbtn()
    {
        ShowPopAnimation(goBackConfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
            reWritePanelText[i].UpdateButtonText(index);
    }

    public void HideGoBackbtn() => closePopAnimation(goBackConfirmationPanel);

    public void OnAcceptBtn() => ViewController.instance.ChangeView(ViewController.instance.playerIntro);

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    public void OnEnterPlayerCount(int playerCount)
    {
        GLOBALS.playerCount = playerCount;
        ViewPlayerNameEnter.instance.playerIndex = 0;
        ViewController.instance.ChangeView(ViewController.instance.playerIntro);

    }
    public void SetCurrentStoryPassage(string PassageName) => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);

    public void OnBackBtnPress() => ViewController.instance.ChangeView(ViewController.instance.mainMenu);

    #endregion

    #region PRIVATE_METHODS

    #endregion
}
