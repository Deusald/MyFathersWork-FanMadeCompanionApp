using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Cradle.Players;
using System.Linq;
using System;

public class ViewGenerationEnding : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewGenerationEnding instance;
    [HideInInspector]
    public AudioClip[] clip = new AudioClip[3];
    [HideInInspector]
    public GameObject continueBtn;
    [HideInInspector]
    public Button backBtn, forwardBtn;
    [HideInInspector]
    public TextMeshProUGUI title;
    [HideInInspector]
    public TextMeshProUGUI content;
    [HideInInspector]
    public GameObject pausePopup;
    [Header("EndingsData")]
    public MainEnding mainEnding;
    [HideInInspector]
    public GameObject goBackConfirmationPanel, goForwardConfirmationPanel;
    EndingsData endings = new EndingsData();
    [HideInInspector]
    public List<ButtonLocalText> pauseMenuText = new List<ButtonLocalText>();
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();
    [HideInInspector]
    public Slider progressBar;
    [HideInInspector]
    public Image border;
    //[HideInInspector]
    public Sprite introBorder, eventBorder;
    [HideInInspector]
    public Scrollbar endingScrollBar;
    [HideInInspector]
    public Image backgroundImage;
    [HideInInspector]
    public List<Sprite> backgroundSprites = new List<Sprite>();

    public static int StoryIndex => PlayerPrefs.GetInt("storyName", 0);

    private IEnumerator ScrollerPageCoroutine = null;

    public static Action<float> S_OnScroll;
    #endregion
    #region PRIVATE_VARS


    #endregion

    #region UNITY_CALLBACKS


    void Start()
    {
        instance = this;
        if (PlayerPrefs.HasKey("GameEndingsData"))
            DataManager.instance.LoadEndings();
        progressBar.value = PlayerPrefs.GetFloat("Progress", 1);
        OnChangeBackground(PlayerPrefs.GetInt("storyName", 0));
    }

    void OnEnable() => S_OnScroll += OnScrollStart;

    void OnDisable() => S_OnScroll -= OnScrollStart;

    #endregion

    #region PUBLIC_METHODS
    public override void ShowAnimated()
    {
        base.ShowAnimated();

        if (clip != null && clip[StoryIndex].name != SoundManager.Instance.MusicSource.clip.name)
            SoundManager.Instance.PlayMusic(clip[StoryIndex]);
    }

    public void SetGenerationEndingTitle(string _title) => title.text = _title;

    public override void HideAnimated()
    {
        base.HideAnimated();
        //SoundManager.Instance.StopMusic();
    }
    public override void Hide() => base.Hide();

    public void OnGenerationEndingContinueBtn()
    {
        DataManager.instance.StopAutoSave();
        PlayerPrefs.DeleteKey("GameData");
        PlayerPrefs.DeleteKey("currentPassage");
        PlayerPrefs.DeleteKey("LogBookTitle");
        PlayerPrefs.DeleteKey("Progress");
        ViewGeneration.instance.OnChangeProgressBar(8 / 9f);
        //OnChangeProgressBar(8 / 9f);
        ViewPlayerNameEnter.instance.playerIndex = 0;
        ViewMainMenu.instance.continueBtn.interactable = false;
    }
    public void LateSceneLoading() => SceneManager.LoadScene(0);
    public void OnGenerationEndingSaveBtn()
        => ViewController.instance.ChangeView(ViewController.instance.mainMenu);

    public void OnGenerationChange()
    {
        ViewController.instance.ChangeView(ViewController.instance.generations);
        Cradle.Players.TwineStoryPlayer.instance.switchToGeneration = true;
    }
    public void EnableDisableContinueBtn(bool status)
    {
        continueBtn.SetActive(status);
        if (status)
        {
            SoundManager.Instance.EndGameAudioSource.Play();
            SoundManager.Instance.MusicSource.Stop();
        }
        else
        {
            SoundManager.Instance.EndGameAudioSource.Stop();
        }
    }

    public void ClearListatStartStory()
    {
        Cradle.Players.TwineStoryPlayer.instance.storyPassageList.Clear();
        Cradle.Players.TwineStoryPlayer.instance.currentPassageIndex = 0;
    }

    public void OnChangeBackground(int index) => backgroundImage.sprite = backgroundSprites[index];

    public bool SaveEndings()
    {
        int titleIndex = mainEnding.endingsDataList.FindIndex(i => i.endingsTitle.Equals(title.text.Replace("</size>", "").Replace("<size=45>", "").Replace("<size=30>", "-").Replace("\n", "")));
        if (titleIndex < 0)
        {
            int index = mainEnding.endingsDataList.Count;
            endings = new EndingsData(index, title.text.Replace("</size>", "").Replace("<size=45>", "").Replace("<size=30>", "-").Replace("\n", ""), (StoryName)PlayerPrefs.GetInt("storyName", 0));
            //mainEnding.endingsDataList.RemoveAt(titleIndex);
            mainEnding.endingsDataList.Add(endings);
            DataManager.instance.SaveEndings();
            return true;
        }
        else
        {
            //mainEnding.endingsDataList.RemoveAt(titleIndex);
            //int index = mainEnding.endingsDataList.Count;
            //endings = new EndingsData(index, title.text.Replace("</size>", "").Replace("<size=45>", "").Replace("<size=30>", "-").Replace("\n", ""), (StoryName)PlayerPrefs.GetInt("storyName", 0));
            //mainEnding.endingsDataList.Add(endings);
            //DataManager.instance.SaveEndings();
            return false;
        }
    }
    public void GoBackBtn()
    {
        ShowPopAnimation(goBackConfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
            reWritePanelText[i].UpdateButtonText(index);
    }

    public void GoForwardBtn() => ShowPopAnimation(goForwardConfirmationPanel);

    public void HideBackbtn() => closePopAnimation(goBackConfirmationPanel);

    public void HideForwardbtn() => closePopAnimation(goForwardConfirmationPanel);

    public void GoToMainScreen()
    {
        ViewController.instance.ChangeView(ViewController.instance.mainMenu);
        OnPauseClose();
        Invoke(nameof(LateSceneLoading), 0.7f);
    }
    public void OnPauseOpen()
    {
        ShowPopAnimation(pausePopup);
        PauseMenuTextChanges();
        GraphicManager.instance.Quality();
    }
    public void OnPauseClose() => closePopAnimation(pausePopup);
    public void DisableContent()
    {
        content.GetComponent<TextMeshProUGUI>().alpha = 0;
        title.GetComponent<TextMeshProUGUI>().alpha = 0;
        Invoke(nameof(EnableContent), 2f);
    }
    public void EnableContent()
    {
        content.GetComponent<TextMeshProUGUI>().alpha = 255;
        title.GetComponent<TextMeshProUGUI>().alpha = 255;
    }

    public void OnLogBookButtonPress()
    {
        ViewLogBook.IsHubPanel = false;
        ViewController.instance.ChangeView(ViewController.instance.logBook);
    }

    public void PauseMenuTextChanges()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < pauseMenuText.Count; i++)
            pauseMenuText[i].UpdateButtonText(index);
    }

    public void OnChangeProgressBar(float progress) => StartCoroutine(OnChangeValueOfProgress(progressBar.value, progress));

    IEnumerator OnChangeValueOfProgress(float start, float finish)
    {
        float t = 0;
        while (t <= 1)
        {
            t += (Time.deltaTime * 2);
            progressBar.value = Mathf.Lerp(start, finish, t);
            yield return new WaitForFixedUpdate();
        }
    }

    public void SetBorder(bool isIntro)
    {
        border.sprite = isIntro ? introBorder : eventBorder;
        //if (isIntro) StartCoroutine(nameof(StartAutoScroll));
    }

    void OnScrollStart(float duration)
    {
        if (ScrollerPageCoroutine != null)
            StopCoroutine(ScrollerPageCoroutine);
        ScrollerPageCoroutine = StartAutoScroll(duration);
        StartCoroutine(ScrollerPageCoroutine);
    }

    IEnumerator StartAutoScroll(float duration)
    {
        endingScrollBar.value = 1;
        yield return new WaitForSeconds(7.5f);
        float valueToLerp;
        float timeElapsed = 0;
        float time = duration - 3;
        while (timeElapsed < time)
        {
            if (SoundManager.Instance.VOSource.isPlaying)
            {
                valueToLerp = Mathf.Lerp(1, 0, timeElapsed / time);
                if (Mathf.Abs(valueToLerp - endingScrollBar.value) >= 0.05f)
                    break;
                endingScrollBar.value = valueToLerp;
                timeElapsed += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        valueToLerp = 0;
        endingScrollBar.value = valueToLerp;

    }

    #endregion

    #region PRIVATE_METHODS

    #endregion
}
