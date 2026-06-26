using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Linq;

public class ViewTieBreaker : UIView
{
    public static ViewTieBreaker instance;

    [SerializeField] GameObject tieBreaker1;
    [SerializeField] GameObject tieBreaker2;
    [SerializeField] List<TieBreaker1Object> tieBreaker1Objects = new List<TieBreaker1Object>();
    [SerializeField] List<ScoreObject> tieBreaker2Objects = new List<ScoreObject>();
    List<ScoreData> tieBreake1HighScoreData = new List<ScoreData>();
    List<ScoreData> tieBreake2HighScoreData = new List<ScoreData>();
    [SerializeField] Button continueButton;
    bool iswaiting = false;

    public static bool isTieBreaker1 = true;

    void Start() => instance = this;

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        iswaiting = false;
    }
    public override void HideAnimated() => base.HideAnimated();

    /// <summary>
    /// prepare tie breaker 1 panel
    /// </summary>
    /// <param name="highScoreData"></param>
    public void OnTieBreaker1(List<ScoreData> highScoreData)
    {
        isTieBreaker1 = true;
        //continueButton.interactable = false;
        tieBreake1HighScoreData = highScoreData;
        foreach (GameObject obj in tieBreaker1Objects.Select(i => i.objectHolder)) obj.SetActive(false);
        for (int i = 0; i < highScoreData.Count; i++)
        {
            TieBreaker1Object tieObjects = tieBreaker1Objects[i];
            tieObjects.playerName.text = highScoreData[i].playerName;
            tieObjects.MasterWorkCheckBox.isOn = false;
            tieObjects.objectHolder.SetActive(true);
        }

        tieBreaker1.SetActive(isTieBreaker1);
        tieBreaker2.SetActive(!isTieBreaker1);
    }

    /// <summary>
    /// prepare tie breaker 2 panel
    /// </summary>
    public void OnTieBreaker2()
    {
        isTieBreaker1 = false;
        continueButton.interactable = false;
        foreach (GameObject obj in tieBreaker2Objects.Select(i => i.objectHolder)) obj.SetActive(false);
        for (int i = 0; i < tieBreake2HighScoreData.Count; i++)
        {
            ScoreObject tieObjects = tieBreaker2Objects[i];
            tieObjects.playerName.text = tieBreake2HighScoreData[i].playerName;
            tieObjects.score.text = "";
            tieObjects.objectHolder.SetActive(true);
        }

        tieBreaker1.SetActive(isTieBreaker1);
        tieBreaker2.SetActive(!isTieBreaker1);
    }

    /// <summary>
    /// set player index wise score
    /// </summary>
    /// <param name="_index"></param>
    public void OnTie2ScoreData(int _index)
    {
        if (int.TryParse(tieBreaker2Objects[_index].score.text, out int scr))
            ViewScoreEntry.instance.ScoreDatas[tieBreake2HighScoreData[_index].playerIndex].score += scr;
        OnCheckTie2ContinueButtonEnabled();
    }

    /// <summary>
    /// check tie breaker 1 or 2
    /// if tie breaker 1 than check how many player completed masterwork, if two or more completed masterwork than go to tie breaker 2
    /// if tie breaker 2 than check high score of the player scores, if two or more high score are same than all player (the family) are winner otherwise perticular player are winner
    /// </summary>
    public void OnContinueButton()
    {
        if (!iswaiting)
        {
            iswaiting = true;
            this.InvokeDelay(() => iswaiting = false, 0.5f);
            if (isTieBreaker1)
            {
                tieBreake2HighScoreData.Clear();
                for (int i = 0; i < tieBreake1HighScoreData.Count; i++)
                {
                    if (tieBreaker1Objects[i].MasterWorkCheckBox.isOn)
                    {
                        tieBreake2HighScoreData.Add(tieBreake1HighScoreData[i]);
                    }
                }
                if (tieBreake2HighScoreData.Count == 0)
                {
                    ViewRankingPage.isFamilyWinner = true;
                    int tempHighScore = ViewScoreEntry.instance.ScoreDatas.Max(scoreData => scoreData.score);
                    ViewRankingPage.numberOfWinner = ViewScoreEntry.instance.ScoreDatas.Where(scoredata => scoredata.score == tempHighScore).Count() - 1;
                    List<ScoreData> temp = ViewScoreEntry.instance.ScoreDatas.OrderByDescending(i => i.score).ToList();
                    ViewRankingPage.instance.playerRankList = temp.Select(i => i.playerName).ToList();
                    ViewController.instance.ChangeView(ViewController.instance.rankingPage);
                }
                else if (tieBreake2HighScoreData.Count == 1)
                {
                    ViewScoreEntry.instance.ScoreDatas[tieBreake2HighScoreData[0].playerIndex].score += 1;
                    List<ScoreData> temp = ViewScoreEntry.instance.ScoreDatas.OrderByDescending(i => i.score).ToList();
                    ViewRankingPage.instance.playerRankList = temp.Select(i => i.playerName).ToList();
                    ViewRankingPage.isFamilyWinner = false;
                    ViewRankingPage.numberOfWinner = 0;
                    ViewController.instance.ChangeView(ViewController.instance.rankingPage);
                }
                else
                {
                    ViewController.instance.ChangeView(ViewController.instance.tieBreaker);
                    OnTieBreaker2();
                }
            }
            else
            {
                List<ScoreData> temp = ViewScoreEntry.instance.ScoreDatas.OrderByDescending(i => i.score).ToList();
                int scr = temp[0].score;
                int highScoreDataCount = temp.Where(i => i.score == scr).Count();
                ViewRankingPage.isFamilyWinner = highScoreDataCount > 1;
                ViewRankingPage.numberOfWinner = highScoreDataCount - 1;
                ViewRankingPage.instance.playerRankList = temp.Select(i => i.playerName).ToList();
                ViewController.instance.ChangeView(ViewController.instance.rankingPage);
            }
        }
    }

    /// <summary>
    /// check one or more select masterwork check box
    /// if no selected master work than continue button interactable false otherwise true
    /// </summary>
    public void OnCheckTie1ContinueButtonEnabled()
    {
        for (int i = 0; i < tieBreake1HighScoreData.Count; i++)
        {
            if (tieBreaker1Objects[i].MasterWorkCheckBox.isOn == true)
            {
                continueButton.interactable = true;
                return;
            }
        }
        continueButton.interactable = false;
    }

    /// <summary>
    /// check player entered score in perticular input field
    /// if no than continue button interactable false otherwise true
    /// </summary>
    void OnCheckTie2ContinueButtonEnabled()
    {
        for (int i = 0; i < tieBreake2HighScoreData.Count; i++)
        {
            if (tieBreaker2Objects[i].score.text == "" || int.Parse(tieBreaker2Objects[i].score.text) < 0)
            {
                continueButton.interactable = false;
                return;
            }
        }
        continueButton.interactable = true;
    }
}

[Serializable]
public class TieBreaker1Object
{
    public GameObject objectHolder;
    public TextMeshProUGUI playerName;
    public Toggle MasterWorkCheckBox;
}
