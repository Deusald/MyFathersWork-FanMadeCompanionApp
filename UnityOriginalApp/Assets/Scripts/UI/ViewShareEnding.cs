using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

public class ViewShareEnding : UIView
{
    #region PUBLIC_VARS
    public static ViewShareEnding instance;

    //public Button closebtn;
    [HideInInspector]
    public TextMeshProUGUI headingText;
    [HideInInspector]
    public Image photoclip;
    //[HideInInspector]
    public List<Sprite> photoclipImages = new List<Sprite>();
    //[HideInInspector]
    public string[] unlockedText = new string[7];
    //[HideInInspector]
    public string[] reachedText = new string[7];
    //[HideInInspector]
    public string[] EndingText = new string[7];
    //[HideInInspector]
    public string[] endingScenarioText = new string[7];
    #endregion

    #region UNITY_CALLBACK
    private void Start() => instance = this;
    #endregion

    #region PUBLIC_METHODS
    public override void ShowAnimated() => base.ShowAnimated();
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide() => base.Hide();
    public override void Show() => base.Show();

    public void OpenSharePopupMenu()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        if (ViewGenerationEnding.instance.SaveEndings())
        {
            headingText.text = unlockedText[index] + " " +
                ViewGenerationEnding.instance.mainEnding.endingsDataList[ViewGenerationEnding.instance.mainEnding.endingsDataList.Count - 1].endingsTitle.Replace("<size=45>", "").Replace("</size>", "").Replace("<size=30>", "").Replace("<size=55>", "") + " " + EndingText[index] +
                "\n\n" + unlockedText[index] + " " + ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(storyname => (int)storyname.storyName == PlayerPrefs.GetInt("storyName", 0)).Count().ToString() + " " + endingScenarioText[index];
        }
        else
        {
            headingText.text = reachedText[index] + " " +
                ViewGenerationEnding.instance.mainEnding.endingsDataList[ViewGenerationEnding.instance.mainEnding.endingsDataList.Count - 1].endingsTitle.Replace("<size=45>", "").Replace("</size>", "").Replace("<size=30>", "").Replace("<size=55>", "") + " " + EndingText[index] +
                "\n\n" + unlockedText[index] + " " + ViewGenerationEnding.instance.mainEnding.endingsDataList.Where(storyname => (int)storyname.storyName == PlayerPrefs.GetInt("storyName", 0)).Count().ToString() + " " + endingScenarioText[index];
        }
        photoclip.sprite = photoclipImages[ViewGenerationEnding.StoryIndex];
        ShowAnimated();
    }

    public void CloseSharePopupMenubtn()
    {
        if (ViewEndings.instance.IsEndingAchievementPanelOpen == false)
        {
            Invoke(nameof(LateSceneLoading), 0.5f);
            ViewController.instance.ChangeView(ViewController.instance.mainMenu);
            HideAnimated();
            Hide();
        }
        else
        {
            Hide();
        }
    }

    public void LateSceneLoading() => SceneManager.LoadScene(0);

    public void OnSharebtnPress()
    {
        StartCoroutine(TakeScreenshotAndShare());
        Debug.Log("share button called");
    }

    public void OnAchievementSelect(string achievement, int StoryIndex)
    {
        headingText.text = achievement;
        photoclip.sprite = photoclipImages[StoryIndex];
        ShowAnimated();
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Unlocked Ending").SetText(headingText.text.Replace("</size>", "").Replace("\n", " ").Replace("<size=55>", "").Replace("<size=40>", "").Replace("<size=30>", "").Replace("<size=45>", "")).Share();

    }
    #endregion
}

public class EndingPassageId
{
    public string StoryId;
    public List<string> PassageId = new List<string>();
}