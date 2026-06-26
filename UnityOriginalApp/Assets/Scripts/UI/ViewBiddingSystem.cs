using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewBiddingSystem : UIView
{
    #region VARIABLES
    public static ViewBiddingSystem instance;
    public GameObject revealObject;
    public Button revealButton;
    public TextMeshProUGUI revealText;
    [HideInInspector] public AudioClip clip;
    [HideInInspector] public AudioClip revealClip;
    [HideInInspector] public TextMeshProUGUI startButtonText, stopButtonText, details;
    [HideInInspector] public List<BiddingDetails> startbuttontextlist = new List<BiddingDetails>();
    [HideInInspector] public List<BiddingDetails> stopbuttontextlist = new List<BiddingDetails>();
    [HideInInspector] public List<BiddingDetails> detailstextlist = new List<BiddingDetails>();
    public static string passageName = "";
    #endregion

    #region UNITY_CALLBACK
    private void Start() => instance = this;
    #endregion

    #region PUBLIC_METHODS
    public override void Hide() => base.Hide();

    public void OnShowBidding(string passage, BiddingSystem biddingSystem) => this.InvokeDelay(() =>
    {
        passageName = passage;
        int lanIndex = PlayerPrefs.GetInt("language", 0);
        (startButtonText.text, stopButtonText.text, details.text) =
            (biddingSystem == BiddingSystem.Voting) ? (startbuttontextlist[lanIndex].voting, stopbuttontextlist[lanIndex].voting, detailstextlist[lanIndex].voting) :
            (startbuttontextlist[lanIndex].bidding, stopbuttontextlist[lanIndex].bidding, detailstextlist[lanIndex].bidding);
        base.ShowAnimated();
        if (clip != null) SoundManager.Instance.OnOpenPopupPlayAudio(clip);
    }, 0.1f);

    public void OnStartBidding() => StartCoroutine(OnBiddingStart());

    public void OnBidComplete()
    {
        Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(passageName);
        Hide();
    }

    IEnumerator OnBiddingStart()
    {
        revealObject.gameObject.SetActive(true);
        if (revealClip != null) SoundManager.Instance.OnOpenPopupPlayAudio(revealClip);
        revealButton.interactable = false;
        for (int i = 3; i > 0; i--)
        {
            revealText.SetText(i.ToString());
            yield return new WaitForSeconds(1f);
        }
        revealText.text = "reveal";
        revealButton.interactable = true;
    }
    #endregion
}

public enum BiddingSystem
{
    Bidding,
    Voting
}

[System.Serializable]
public class BiddingDetails
{
    public string bidding;
    public string voting;
}