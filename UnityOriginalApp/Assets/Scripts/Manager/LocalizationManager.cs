using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    [HideInInspector] public TMP_Dropdown Languages;
    [HideInInspector] public List<ButtonLocalText> buttonLocalList = new List<ButtonLocalText>();
    [HideInInspector] public bool isLanguageChange = false;

    private void Awake() => instance = this;


    public void Start()
    {
        int _lanIndex = PlayerPrefs.GetInt("language", 0);
        Languages.SetValueWithoutNotify(_lanIndex);
        //for (int i = 0; i < buttonLocalList.Count; i++)
        //    buttonLocalList[i].UpdateButtonText(_lanIndex);
    }

    /// <summary>
    /// store language number in player prefabs
    /// </summary>
    /// <param name="lan"></param>
    public void SetLanguageName(TextMeshProUGUI lan)
    {

        Debug.Log("Language Index ==>" + lan.text.ToString());
        int lanIndex = 0;
        switch (lan.text.ToString())
        {
            case "English":
                lanIndex = 0;
                break;
            case "français":
                lanIndex = 1;
                break;
            default:
                Debug.Log("Not Channges in languages");
                break;
        }
        isLanguageChange = true;

        PlayerPrefs.SetInt("language", lanIndex);
    }

    public void ChangeLanguageWiseText()
    {
        //if (isLanguageChange)
        //{
        //    int _lanIndex = PlayerPrefs.GetInt("language", 0);
        //    for (int i = 0; i < buttonLocalList.Count; i++)
        //        buttonLocalList[i].UpdateButtonText(_lanIndex);
        //}
    }
}