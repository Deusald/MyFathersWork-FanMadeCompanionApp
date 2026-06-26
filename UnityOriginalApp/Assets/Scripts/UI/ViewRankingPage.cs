using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewRankingPage : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewRankingPage instance;

    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public List<string> playerRankList = new List<string>();
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public List<TextMeshProUGUI> playerRankTextList = new List<TextMeshProUGUI>();
    [HideInInspector]
    public List<TextMeshProUGUI> playerNameTextList = new List<TextMeshProUGUI>();
    public List<Image> crownImage = new List<Image>();
    public static bool isFamilyWinner = false;
    public static int numberOfWinner = 0;

    public readonly Color transparent = new Color();

    #endregion


    #region UNITY_CALLBACKS
    void Start() => instance = this;
    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        SetPlayersName();
        base.ShowAnimated();
        if (clip != null)
            PlayBGSound(true);
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();
    }

    public void SetPlayersName()
    {
        for (int i = 0; i < playerNameTextList.Count; i++)
        {
            playerNameTextList[i].alpha = 0;
            playerRankTextList[i].alpha = 0;
        }
        for (int i = 0; i < playerRankList.Count; i++)
        {
            playerNameTextList[i].text = playerRankList[i];
            playerNameTextList[i].alpha = 255;
            playerRankTextList[i].alpha = 255;
        }
        foreach (Image obj in crownImage) obj.color = new Color(1, 1, 1, 0);
        if (isFamilyWinner && numberOfWinner > 0)
        {
            for (int i = 0; i < numberOfWinner; i++)
                crownImage[i].color = new Color(1, 1, 1, 1);
        }
        GLOBALS.winnerName = isFamilyWinner ? "The family" : playerRankList[0];

    }
    public override void Hide() => base.Hide();
    public void OnContinueBtn()
    {
        Debug.Log("Switch to Main menu");
        SetCurrentStoryPassage("VarEndingsPassage");
    }

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    public void SetCurrentStoryPassage(string PassageName) => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
