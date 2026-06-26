using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewScoreEntry : UIView
{
    #region VARIABLES
    public static ViewScoreEntry instance;

    public static Action S_OnUpdateGlobleVariable;

    [SerializeField] private List<ScoreObject> scoreObjects = new List<ScoreObject>();

    public List<ScoreData> ScoreDatas = new List<ScoreData>();
    public Button continueButton;
    #endregion

    #region UNITY_CALLBACK
    void Start() => instance = this;
    #endregion

    #region METHODS
    public override void ShowAnimated()
    {
        S_OnUpdateGlobleVariable?.Invoke();
        OnPrepare();
        base.ShowAnimated();
    }

    public override void HideAnimated() => base.HideAnimated();

    /// <summary>
    /// set perticular player wise score 
    /// </summary>
    /// <param name="playerIndex"></param>
    public void OnSetScore(int playerIndex)
    {
        if (int.TryParse(scoreObjects[playerIndex].score.text, out int scr))
            ScoreDatas[playerIndex].score = scr;
        OnCheckContinueButtonEnbled();
    }

    /// <summary>
    /// this method Attached in continue button's event
    /// check tie break or not
    /// if not than go to ranking panel
    /// otherwise go to tie break panel
    /// </summary>
    public void OnContinueButton()
    {
        List<ScoreData> temp = ScoreDatas.OrderByDescending(i => i.score).ToList();
        int scr = temp[0].score;
        List<ScoreData> highScoreData = temp.FindAll(i => i.score == scr);
        if (highScoreData.Count == 1)
        {
            ViewRankingPage.instance.playerRankList = temp.Select(i => i.playerName).ToList();
            ViewController.instance.ChangeView(ViewController.instance.rankingPage);
            ViewRankingPage.isFamilyWinner = false;
            ViewRankingPage.numberOfWinner = 0;
        }
        else
        {
            ViewTieBreaker.instance.OnTieBreaker1(highScoreData);
            ViewController.instance.ChangeView(ViewController.instance.tieBreaker);
        }
    }

    /// <summary>
    /// preapre data of score panel
    /// player count wise score enter in input field
    /// </summary>
    void OnPrepare()
    {
        foreach (GameObject obj in scoreObjects.Select(i => i.objectHolder)) obj.SetActive(false);
        ScoreDatas.Clear();
        for (int i = 0; i < GLOBALS.playerCount; i++)
        {
            ScoreObject scoreObject = scoreObjects[i];
            scoreObject.objectHolder.SetActive(true);
            scoreObject.playerName.text = GetPlayerName(i);
            scoreObject.score.text = "";
            ScoreDatas.Add(new ScoreData(i, GetPlayerName(i), 0));
        }
        continueButton.interactable = false;
    }

    /// <summary>
    /// check all input fiels are not null and value are gater than zero
    /// if value are gater than 0 than button interactable false otherwise true
    /// </summary>
    void OnCheckContinueButtonEnbled()
    {
        for (int i = 0; i < GLOBALS.playerCount; i++)
        {
            if (scoreObjects[i].score.text == "" || int.Parse(scoreObjects[i].score.text) < 0)
            {
                continueButton.interactable = false;
                return;
            }
        }
        continueButton.interactable = true;
    }

    /// <summary>
    /// return player name
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    string GetPlayerName(int _index)
    {
        switch (_index)
        {
            case 0:
                return GLOBALS.nameA;
            case 1:
                return GLOBALS.nameB;
            case 2:
                return GLOBALS.nameC;
            case 3:
                return GLOBALS.nameD;
            default:
                return "";
        }
    }
    #endregion
}

[Serializable]
public class ScoreObject
{
    public GameObject objectHolder;
    public TextMeshProUGUI playerName;
    public TMP_InputField score;
}

[Serializable]
public class ScoreData
{
    public int playerIndex;
    public string playerName;
    public int score;

    public ScoreData() { }

    public ScoreData(int _index, string name, int scr)
    {
        playerIndex = _index;
        playerName = name;
        score = scr;
    }
}