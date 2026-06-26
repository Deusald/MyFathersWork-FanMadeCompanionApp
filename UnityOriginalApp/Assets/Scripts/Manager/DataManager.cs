using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cradle;
using Cradle.Players;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public static Action<MainData, int, int> s_OnStoryDataSave;
    public static Action<int, int> s_OnLoadDataDefault;
    public static Action<int, int, Action<MainData>> s_SaveDataOfStoryFile;

    public List<EndingsData> AllEndings = new List<EndingsData>();

    void Awake()
    {
        instance = this;
        LoadJsonData();
    }

    private void OnEnable()
    {
        PassageTracker.s_OnDataSave += SaveDataFromStroy;
        TwineStoryPlayer.s_OnPressGoBack += LoadPreviousData;
    }

    private void OnDisable()
    {
        PassageTracker.s_OnDataSave -= SaveDataFromStroy;
        TwineStoryPlayer.s_OnPressGoBack -= LoadPreviousData;
    }

    [SerializeField] public TheCostOfDiseaseData theCostOfDisease;
    void LoadJsonData()
    {
        var jsonData = Resources.Load<TextAsset>("TheCostOfDisease_ItemObtain");
        theCostOfDisease = JsonUtility.FromJson<TheCostOfDiseaseData>(jsonData.ToString());
    }

    public void StartAutoSave()
    {
        //InvokeRepeating(nameof(SaveDataFromStroy), 0f, 5f);
    }

    public void StopAutoSave()
    {
        //CancelInvoke("SaveDataFromStroy");
    }

    /// <summary>
    /// save data in json
    /// </summary>
    public void SaveDataFromStroy()
    {
        string data = SaveDataOfStoryFile();
        //Debug.Log("Save data.......");
        string currentPassageName = PassageTracker.instance.currentPassageName;
        //Debug.Log($"<color=green>{currentPassageName} === {PlayerPrefs.GetString("PreviousPassageName", "")}</color>");
        //save previous data
        if (!TwineStoryPlayer.instance.abortPassageList.Contains(currentPassageName))
        {
            if (PlayerPrefs.GetString("PreviousPassageName", "") != currentPassageName && currentPassageName != PlayerPrefs.GetString("currentPassage", "") && currentPassageName != "TITLE SCREEN")
            {
                //Debug.Log("Current data json:- " + data);
                //Debug.Log("Previous Data :-- " + PlayerPrefs.GetString("GameData"));
                PlayerPrefs.SetString("PreviousGameData", PlayerPrefs.GetString("GameData"));
                PlayerPrefs.SetString("PreviousPassageName", PlayerPrefs.GetString("currentPassage", ""));
            }
            //save current data
            PlayerPrefs.SetString("GameData", data);
            PlayerPrefs.SetString("currentPassage", currentPassageName);
        }
    }

    /// <summary>
    /// return data of specific language twine file data
    /// </summary>
    /// <returns></returns>
    public string SaveDataOfStoryFile()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        int storyIndex = PlayerPrefs.GetInt("storyName", 0);
        MainData tempData = null;
        Action<MainData> mainDataCallback = (MainData data) => tempData = data;
        s_SaveDataOfStoryFile?.Invoke(index, storyIndex, mainDataCallback);
        return JsonUtility.ToJson(tempData);
    }

    /// <summary>
    /// load data from json
    /// </summary>
    public void LoadDataFromJson()
    {
        s_OnStoryDataSave?.Invoke(JsonUtility.FromJson<MainData>(PlayerPrefs.GetString("GameData")), PlayerPrefs.GetInt("language", 0), PlayerPrefs.GetInt("storyName", 0));
        string passageName = PlayerPrefs.GetString("currentPassage");
        Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(passageName);
    }

    /// <summary>
    /// load all defalt data 
    /// </summary>
    public void LoadDefaultDataAtNewGame()
    {
        s_OnLoadDataDefault?.Invoke(PlayerPrefs.GetInt("language", 0), PlayerPrefs.GetInt("storyName", 0));
        if (PlayerPrefs.HasKey("GameData"))
        {
            PlayerPrefs.DeleteKey("GameData");
            PlayerPrefs.DeleteKey("currentPassage");
            PlayerPrefs.DeleteKey("PreviousGameData");
            PlayerPrefs.DeleteKey("PreviousPassageName");
        }
    }

    /// <summary>
    /// load previous data
    /// </summary>
    public void LoadPreviousData()
    {
        s_OnStoryDataSave?.Invoke(JsonUtility.FromJson<MainData>(PlayerPrefs.GetString("PreviousGameData")), PlayerPrefs.GetInt("language", 0), PlayerPrefs.GetInt("storyName", 0));
    }

    public void SaveEndings()
        => PlayerPrefs.SetString("GameEndingsData", JsonUtility.ToJson(ViewGenerationEnding.instance.mainEnding));

    public void LoadEndings() =>
        ViewGenerationEnding.instance.mainEnding = JsonUtility.FromJson<MainEnding>(PlayerPrefs.GetString("GameEndingsData"));
    //=> ViewGenerationEnding.instance.mainEnding.endingsDataList = AllEndings.OrderBy(ending => Guid.NewGuid()).ToList();

    public void SaveLogBookData()
        => PlayerPrefs.SetString("LogBookTitle", JsonUtility.ToJson(ViewLogBook.instance.logBookTitle));

    public void LoadLogBookDataFromJSON()
       => ViewLogBook.instance.logBookTitle = JsonUtility.FromJson<LogBookTitle>(PlayerPrefs.GetString("LogBookTitle"));

    public bool IsGameDataSaved() => PlayerPrefs.HasKey("GameData");
}

[Serializable]
public enum Languages
{
    English,
    French
}