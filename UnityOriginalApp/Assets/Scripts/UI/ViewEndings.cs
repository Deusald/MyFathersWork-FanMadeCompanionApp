using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;

public class ViewEndings : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewEndings instance;
    [HideInInspector]
    public Scrollbar Scrollbar;
    [HideInInspector]
    public Image achievementbuttonImg, endingbuttonImg;
    [HideInInspector] public TextMeshProUGUI achievementFont, endingFont;
    [HideInInspector] public GameObject endingPrefab;
    [HideInInspector] public Transform endingParent;
    [HideInInspector]
    public Sprite endingSprite1, endingSprite2;
    [HideInInspector]
    public Sprite theCostOfDisease, aTimeOfWar, theFearOfUnknown;
    [HideInInspector]
    public List<GameObject> endingsNameList = new List<GameObject>();
    [HideInInspector]
    public TextMeshProUGUI endingTracker, AchievementTracker;
    [HideInInspector]
    public static bool IsAchievement = false;
    [HideInInspector]
    public bool IsEndingAchievementPanelOpen = false;
    //[HideInInspector]
    public string[] endingText = new string[7];
    //[HideInInspector]
    public string[] unlockedText = new string[7];
    //[HideInInspector]
    public string[] ihaveUnckedText = new string[7];
    //[HideInInspector]
    public string[] endingUnlockedText = new string[7];
    //[HideInInspector]
    public string[] achievementUnlockedText = new string[7];
    //[HideInInspector]
    public List<string> TotalAchievements = new List<string>();
    //[HideInInspector]
    public List<string> specialAchievement = new List<string>();
    //[HideInInspector]
    public List<string> storyNameList = new List<string>();

    public List<AchievementData> AchivementsLanguageWise = new List<AchievementData>();

    public List<AchievementData> specialAchievementLanguageWise = new List<AchievementData>();

    public List<AchievementData> storyNameLanguageWise = new List<AchievementData>();
    #endregion
    #region PRIVATE_VARS


    #endregion

    #region UNITY_CALLBACKS

    void Start() => instance = this;

    #endregion


    #region PUBLIC_METHODS
    public override void ShowAnimated()
    {
        IsEndingAchievementPanelOpen = true;
        base.ShowAnimated();
        //if (ViewGenerationEnding.instance.mainEnding.endingsDataList.Count > 0)
        endingTracker.text = ViewGenerationEnding.instance.mainEnding.endingsDataList.Count + endingUnlockedText[PlayerPrefs.GetInt("language", 0)];
        int springtimeIndex = ViewGenerationEnding.instance.mainEnding.endingsDataList.FindIndex(end => end.endingsTitle.Contains("Springtime"));
        int foreverIndex = ViewGenerationEnding.instance.mainEnding.endingsDataList.FindIndex(end => end.endingsTitle.Contains("Forever"));
        List<string> _TotalAchievements = AchivementsLanguageWise[PlayerPrefs.GetInt("language", 0)].Achievement;
        if (springtimeIndex > -1)
        {
            //int _achievementIndex = TotalAchievements.FindIndex(achievement => achievement.Contains("Springtime"));
            //if (_achievementIndex > -1) ViewEndings.instance.TotalAchievements[_achievementIndex] = ViewGenerationEnding.instance.mainEnding.endingsDataList[springtimeIndex].endingsTitle;
            int _achievementIndex = _TotalAchievements.FindIndex(achievement => achievement.Contains("Springtime"));
            if (_achievementIndex > -1) _TotalAchievements[_achievementIndex] = ViewGenerationEnding.instance.mainEnding.endingsDataList[springtimeIndex].endingsTitle;

        }
        if (foreverIndex > -1)
        {
            int _achievementIndex = _TotalAchievements.FindIndex(achievement => achievement.Contains("Forever"));
            if (_achievementIndex > -1)
                _TotalAchievements[_achievementIndex] = ViewGenerationEnding.instance.mainEnding.endingsDataList[foreverIndex].endingsTitle;
        }
        SetAchievementData();
        Scrollbar.GetComponent<Scrollbar>().value = 1;
    }

    public override void HideAnimated() => base.HideAnimated();
    public override void Hide() => base.Hide();

    public void SetEndingData()
    {
        IsAchievement = false;
        endingTracker.enabled = true;
        AchievementTracker.enabled = false;
        endingbuttonImg.color = Color.white;
        endingFont.color = Color.white;
        achievementbuttonImg.color = new Color32(168, 168, 168, 255);
        achievementFont.color = new Color32(168, 168, 168, 255);
        int addedtitleIndex = 0;
        if (ViewGenerationEnding.instance.mainEnding.endingsDataList.Count() > 0)
        {
            List<EndingsData> mainEnding = ViewGenerationEnding.instance.mainEnding.endingsDataList.OrderBy(endingdata => (int)endingdata.storyName).ToList();
            int storyindex = -1;
            for (int j = 0; j < mainEnding.Count; j++)
            {
                if (storyindex != (int)mainEnding[j].storyName)
                {
                    string storyname = "<align=\"center\"><size=60>" + storyNameLanguageWise[PlayerPrefs.GetInt("language", 0)].Achievement[(int)mainEnding[j].storyName] + "</align></size>";
                    EndingPanelButton endStoryTitle = endingsNameList[j + addedtitleIndex].GetComponent<EndingPanelButton>();
                    endStoryTitle.text.text = storyname;
                    endStoryTitle.btnIndex = -1;
                    endStoryTitle.ScenarioImage.sprite = null;
                    endStoryTitle.ScenarioImage.color = new Color32(6, 18, 33, 100);
                    RectTransform rect = endingsNameList[j + addedtitleIndex].GetComponent<RectTransform>();
                    rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y / 2);
                    endStoryTitle.ScenarioImage.enabled = true;
                    addedtitleIndex++;
                }
                storyindex = (int)mainEnding[j].storyName;
                string s = mainEnding[j].endingsTitle;
                EndingPanelButton end = endingsNameList[j + addedtitleIndex].GetComponent<EndingPanelButton>();
                end.text.text = s;
                end.btnIndex = mainEnding[j].index;
                end.ScenarioImage.sprite = GetScenarioSprite(mainEnding[j].storyName);
                end.ScenarioImage.enabled = true;
                //endingsNameList[j].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = s;
            }
        }

        int minIndexToDestroy = ViewGenerationEnding.instance.mainEnding.endingsDataList.Count + addedtitleIndex > 5 ?
            ViewGenerationEnding.instance.mainEnding.endingsDataList.Count + addedtitleIndex : 5;
        for (int index = minIndexToDestroy; index < endingsNameList.Count; index++)
            Destroy(endingsNameList[index]);
        if (minIndexToDestroy == 5)
        {
            for (int x = ViewGenerationEnding.instance.mainEnding.endingsDataList.Count + addedtitleIndex; x < 5; x++)
                endingsNameList[x].GetComponent<EndingPanelButton>().text.text = "";
        }
        endingsNameList.RemoveRange(minIndexToDestroy, endingsNameList.Count - minIndexToDestroy);
        Scrollbar.GetComponent<Scrollbar>().value = 1;
    }

    public void SetAchievementData()
    {
        IsAchievement = true;
        endingTracker.enabled = false;
        AchievementTracker.enabled = true;
        endingbuttonImg.color = new Color32(168, 168, 168, 255);
        endingFont.color = new Color32(168, 168, 168, 255);
        achievementbuttonImg.color = Color.white;
        achievementFont.color = Color.white;
        int index = PlayerPrefs.GetInt("language", 0);
        if (endingsNameList.Count > 0)
        {
            foreach (GameObject g in endingsNameList) Destroy(g);
            endingsNameList.Clear();
        }
        List<string> _TotalAchievements = AchivementsLanguageWise[PlayerPrefs.GetInt("language", 0)].Achievement;
        if (_TotalAchievements.Count > 0)
        {
            for (int j = 0; j < _TotalAchievements.Count; j++)
            {
                GameObject g = Instantiate(endingPrefab, endingParent);
                EndingPanelButton end = g.GetComponent<EndingPanelButton>();
                end.image.sprite = j % 2 == 0 ? endingSprite1 : endingSprite2;
                //end.ScenarioImage.sprite = GetScenarioSprite(ViewGenerationEnding.instance.mainEnding.endingsDataList[j].storyName);
                end.ScenarioImage.enabled = false;
                string s = _TotalAchievements[j];
                if (Regex.IsMatch(s, "^(The|A|An)"))
                    end.text.text = "<size=45>" + unlockedText[index].Replace(" the", "") + " " + s + " " + endingText[index] + "</size>";
                else
                    end.text.text = "<size=45>" + unlockedText[index] + " " + s + " " + endingText[index] + "</size>";
                end.btnIndex = ViewGenerationEnding.instance.mainEnding.endingsDataList.FindIndex(endingdata => endingdata.endingsTitle == s);
                if (end.btnIndex == -1)
                    end.text.text = "<color=grey>" + end.text.text + "</color>";
                endingsNameList.Add(g);
                //endingsNameList[j].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<size=45>" + unlockedText[index] + " " + ViewGenerationEnding.instance.mainEnding.endingsDataList[j].endingsTitle.Replace("<size=55>", "").Replace("</size>", "") + " " + endingText[index] + "</size>";
            }
        }
        int unlockedAchievementCount = 0;
        List<string> _specialAchievement = specialAchievementLanguageWise[PlayerPrefs.GetInt("language", 0)].Achievement;
        for (int i = 0; i < _specialAchievement.Count; i++)
        {
            GameObject g = Instantiate(endingPrefab, endingParent);
            EndingPanelButton end = g.GetComponent<EndingPanelButton>();
            end.image.sprite = i % 2 == 0 ? endingSprite1 : endingSprite2;
            end.btnIndex = -1;
            end._storyIndex = i % 3;
            if (GetSpecialAchievementComplete(i))
            {
                end.btnIndex = -2;
                end.text.text = _specialAchievement[i];
                unlockedAchievementCount++;
            }
            else
            {
                end.text.text = "<color=grey>" + _specialAchievement[i] + "</color>";
            }

            end.ScenarioImage.enabled = false;
            endingsNameList.Add(g);
        }
        Scrollbar.GetComponent<Scrollbar>().value = 1;
        unlockedAchievementCount += ViewGenerationEnding.instance.mainEnding.endingsDataList.Count;
        AchievementTracker.text = unlockedAchievementCount + achievementUnlockedText[PlayerPrefs.GetInt("language", 0)];
        bool GetSpecialAchievementComplete(int x)
        {
            switch (x)
            {
                case 0:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.TheCostofDisease).Count() > 0;
                case 1:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.FearofUnknown).Count() > 0; ;
                case 2:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.ATimeofWar).Count() > 0;
                case 3:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.TheCostofDisease).Count() > 7;
                case 4:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.FearofUnknown).Count() > 7;
                case 5:
                    return ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(endingdata => endingdata.storyName == StoryName.ATimeofWar).Count() > 7;
                default:
                    return false;
            }
        }
    }

    public Sprite GetScenarioSprite(StoryName storyName)
    {
        return storyName == StoryName.ATimeofWar ? aTimeOfWar : storyName == StoryName.FearofUnknown ? theFearOfUnknown : theCostOfDisease;
    }

    //public void OnPressSharing(int x)
    //{
    //    Debug.Log(x);
    //    int index = PlayerPrefs.GetInt("language", 0);
    //    if (IsAchievement && x < ViewGenerationEnding.instance.mainEnding.endingsDataList.Count)
    //    {
    //        string s = "<size=40>" + ihaveUnckedText[index] + "\n" + ViewGenerationEnding.instance.mainEnding.endingsDataList[x].endingsTitle + "\n" + endingText[index] + "</size>";
    //        ViewShareEnding.instance.OnAchievementSelect(s);
    //    }
    //}

    public void OnGoToMainMenu()
    {
        IsAchievement = false;
        IsEndingAchievementPanelOpen = false;
        if (endingsNameList.Count > 0)
        {
            foreach (GameObject g in endingsNameList) Destroy(g);
            endingsNameList.Clear();
        }
        ViewController.instance.ChangeView(ViewController.instance.mainMenu);
    }


    #endregion

    #region PRIVATE_METHODS

    #endregion
}
