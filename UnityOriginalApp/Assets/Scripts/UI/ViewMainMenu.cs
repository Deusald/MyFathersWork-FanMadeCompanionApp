using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// Hold and manage ui part of main menu
/// </summary>

public class ViewMainMenu : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewMainMenu instance;
    [HideInInspector]
    public AudioClip clip;
    public AudioClip welcomeClip;
    [HideInInspector]
    public GameObject SettingObj, rewriteObj;
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public TextMeshProUGUI continueText, newgameText, settingText, endingsText;
    [HideInInspector]
    public List<string> ignorPassageNameList = new List<string>();
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();

    [Tooltip("Voice Track")]
    [HideInInspector]
    public TextMeshProUGUI voiceTrackText;
    [HideInInspector]
    public List<VoiceTrack> voiceTrackLocalization = new List<VoiceTrack>();
    VoiceTrack VOTrackText => voiceTrackLocalization[PlayerPrefs.GetInt("language", 0)];
    int VOTrackNum
    {
        get => PlayerPrefs.GetInt("AudioTrack", 0);
        set => PlayerPrefs.SetInt("AudioTrack", value);
    }

    #endregion
    #region PRIVATE_VARS


    #endregion

    #region UNITY_CALLBACKS


    IEnumerator Start()
    {
        //PlayerPrefs.DeleteAll();
        instance = this;
        ChackContinueButtonStatus();
        yield return new WaitForSeconds(0.2f);
        SoundManager.Instance.PlayOneTime(welcomeClip);
    }
    #endregion

    #region PUBLIC_METHODS
    public override void ShowAnimated()
    {
        base.ShowAnimated();
        if (clip != null)
            PlayBGSound(true);
        ChackContinueButtonStatus();
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();
    }
    public override void Hide() => base.Hide();

    public override void Show()
    {
        base.Show();
        if (clip != null)
            PlayBGSound(true);
    }

    /// <summary>
    /// check data is null or not
    /// if data is not null than show rewrite panel
    /// </summary>
    public void CheckNewGameBtn()
    {
        if (continueBtn.interactable)
        {
            ShowPopAnimation(rewriteObj);
            int index = PlayerPrefs.GetInt("language", 0);
            for (int i = 0; i < reWritePanelText.Count; i++)
                reWritePanelText[i].UpdateButtonText(index);
        }
        else
            OnNewGameBtn();
    }

    /// <summary>
    /// set default data at new game
    /// </summary>
    public void OnNewGameBtn()
    {
        DataManager.instance.LoadDefaultDataAtNewGame();
        //DataManager.instance.StartAutoSave();
        ViewPlayerNameEnter.instance.playerIndex = 0;
        PlayerPrefs.DeleteKey("LogBookTitle");
        PlayerPrefs.DeleteKey("Progress");
        ViewGeneration.instance.OnChangeProgressBar(8 / 9f);
        ViewGenerationEnding.instance.OnChangeProgressBar(8 / 9f);
        ViewLogBook.instance.logBookTitle.logBookTitlelist.Clear();
        GlobleVariablesReset();
        ViewController.instance.ChangeView(ViewController.instance.audioTrack);
    }

    public void GlobleVariablesReset() => GLOBALS.nameA = GLOBALS.nameB = GLOBALS.nameC = GLOBALS.nameD = GLOBALS.nameE = "";

    /// <summary>
    /// when press continue button
    /// </summary>
    public void OnContinueGameBtn()
    {
        if (PlayerPrefs.HasKey("currentPassage"))
        {
            string passageName = PlayerPrefs.GetString("currentPassage");
            if (!ignorPassageNameList.Contains(passageName))
            {
                Cradle.Players.TwineStoryPlayer.instance.storyPassageList.Clear();
                Cradle.Players.TwineStoryPlayer.instance.currentPassageIndex = 0;
                DataManager.instance.LoadDataFromJson();
                DataManager.instance.StartAutoSave();
                ViewPlayerNameEnter.instance.playerIndex = 0;
            }
        }
    }

    public void OnEndingsBtn() => ViewController.instance.ChangeView(ViewController.instance.endings);

    public void OnSetttingClick()
    {
        //LocalizationManager.instance.isLanguageChange = false;
        ShowPopAnimation(SettingObj);
        voiceTrackText.text = VOTrackNum == 1 ? VOTrackText.female : VOTrackText.male;
        //GraphicManager.instance.Quality();
    }
    public void OnSettingClose()
    {
        if (LocalizationManager.instance.isLanguageChange)
        {
            Debug.Log("reload called.");
            DataManager.instance.LoadDefaultDataAtNewGame();
            //DataManager.instance.StartAutoSave();
            ViewPlayerNameEnter.instance.playerIndex = 0;
            PlayerPrefs.DeleteKey("LogBookTitle");
            PlayerPrefs.DeleteKey("Progress");
            ViewGeneration.instance.OnChangeProgressBar(8 / 9f);
            ViewGenerationEnding.instance.OnChangeProgressBar(8 / 9f);
            ViewLogBook.instance.logBookTitle.logBookTitlelist.Clear();
            PlayerPrefs.DeleteKey("GameEndingsData");
            GlobleVariablesReset();
            Invoke(nameof(LoadScene), 0.3f);
        }
        closePopAnimation(SettingObj);
    }
    public void ShowRewritePopup() => ShowPopAnimation(rewriteObj);
    public void HideRewritePopup() => closePopAnimation(rewriteObj);

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayMusic(clip);
        else
            SoundManager.Instance.StopMusic();
    }

    /// <summary>
    /// continue button interactable
    /// </summary>
    public void ChackContinueButtonStatus()
    {
        continueBtn.interactable = DataManager.instance.IsGameDataSaved();
        if (PlayerPrefs.HasKey("currentPassage"))
        {
            string passageName = PlayerPrefs.GetString("currentPassage");
            if (!ignorPassageNameList.Contains(passageName))
            {
                continueBtn.interactable = true;
            }
            else
            {
                continueBtn.interactable = false;
                Color col = continueText.color;
                col.a = 0.62f;
                continueText.color = col;
            }
        }
        else
        {
            continueBtn.interactable = false;
            Color col = continueText.color;
            col.a = 0.62f;
            continueText.color = col;
        }
    }

    public void OnChangeVoiceTrack()
    {
        VOTrackNum = VOTrackNum == 0 ? 1 : 0;
        voiceTrackText.text = VOTrackNum == 1 ? VOTrackText.female : VOTrackText.male;
        ViewAudioTrack.instace.OnChangeToggleButton(VOTrackNum == 1);
    }

    public void OnHelpbtn() => ViewHelp.instance.OnOpenHelp();

    #endregion

    #region PRIVATE_METHODS

    void LoadScene() => SceneManager.LoadScene(0);

    #endregion
}

[System.Serializable]
public class VoiceTrack
{
    public string male;
    public string female;
}

[System.Serializable]
public class AchievementData
{
    public List<string> Achievement = new List<string>();
}