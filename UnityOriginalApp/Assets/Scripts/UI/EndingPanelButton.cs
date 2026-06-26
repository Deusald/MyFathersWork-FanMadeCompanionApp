using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingPanelButton : MonoBehaviour
{
    //[HideInInspector]
    public int btnIndex;
    //[HideInInspector]
    public Button button;
    //[HideInInspector]
    public Image image;
    //[HideInInspector]
    public TextMeshProUGUI text;
    //[HideInInspector]
    public Image ScenarioImage;
    public int _storyIndex { get; set; }
    private void OnEnable()
    {
        button.onClick.AddListener(OnPressSharing);
    }

    public void OnPressSharing()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        if (/*ViewEndings.IsAchievement &&*/ btnIndex < ViewGenerationEnding.instance.mainEnding.endingsDataList.Count && btnIndex > -1)
        {
            string ts = ViewGenerationEnding.instance.mainEnding.endingsDataList[btnIndex].endingsTitle.Replace("<size=45>", "").Replace("</size>", "");
            string s;
            if (Regex.IsMatch(ts, "^(The|A|An)"))
                s = "<size=40>" + ViewEndings.instance.ihaveUnckedText[index].Replace(" the", "") + "\n" + ViewGenerationEnding.instance.mainEnding.endingsDataList[btnIndex].endingsTitle + "\n" + ViewEndings.instance.endingText[index] + "</size>";
            else
                s = "<size=40>" + ViewEndings.instance.ihaveUnckedText[index] + "\n" + ViewGenerationEnding.instance.mainEnding.endingsDataList[btnIndex].endingsTitle + "\n" + ViewEndings.instance.endingText[index] + "</size>";
            int storyIndex = (int)ViewGenerationEnding.instance.mainEnding.endingsDataList[btnIndex].storyName;
            ViewShareEnding.instance.OnAchievementSelect(s, storyIndex);
        }
        else if (btnIndex == -2)
        {
            ViewShareEnding.instance.OnAchievementSelect(text.text, _storyIndex);
        }
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}
