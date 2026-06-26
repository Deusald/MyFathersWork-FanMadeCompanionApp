using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cradle.Players;
public class ViewPlayerIntro : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewPlayerIntro instance;
    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public Button btnAddPlayer;
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public Button continueBtn2;
    [HideInInspector]
    public Animator playerIntroAnim;
    [HideInInspector]
    public Animator PlayerNameIntro;
    [HideInInspector]
    public List<TextMeshProUGUI> playerNameTextList = new List<TextMeshProUGUI>();
    [HideInInspector]
    public TMP_Text IntroPanelText;
    [HideInInspector]
    public TextMeshProUGUI playerIntroText;
    //[HideInInspector]
    public string[] introText1 = new string[7];
    //[HideInInspector]
    public string[] introText2 = new string[7];
    //[HideInInspector]
    public string[] introText3 = new string[7];
    //[HideInInspector]
    public string[] introText4 = new string[7];
    //[HideInInspector]
    public string[] introText5 = new string[7];
    //[HideInInspector]
    public string[] introPanelText1 = new string[7];
    //[HideInInspector]
    public string[] introPanelText2 = new string[7];
    //[HideInInspector]
    public List<Numbers> LanguageWiseNumberWord = new List<Numbers>();
    #endregion


    #region UNITY_CALLBACKS
    void Start() => instance = this;
    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        if (clip != null)
            PlayBGSound(true);
        if (ViewPlayerNameEnter.instance.playerIndex == 0)
            AnimatePlayerNameIntro();
        else
            AssignPlayerNamesAfterAnim();
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();
        Invoke(nameof(LateHidePlayerAnimation), 2f);
    }
    public void LateHidePlayerAnimation()
    {
        playerIntroAnim.gameObject.SetActive(false);
        PlayerNameIntro.Play("PlayerNameIntroRev");
    }

    public override void Hide() => base.Hide();

    public void OnContinueBtn()
    {
        if (ViewPlayerNameEnter.instance.playerIndex < GLOBALS.playerCount)
        {
            ViewController.instance.ChangeView(ViewController.instance.PlayerSelection);
            Debug.Log("Switch to player name enter");
        }
        else
        {
            Debug.Log("Switch to Village");
            ViewController.instance.ChangeView(ViewController.instance.villageEntry);
        }
    }

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    public void AnimatePlayerNameIntro()
    {
        playerIntroAnim.gameObject.SetActive(true);
        PlayerNameIntro.gameObject.SetActive(false);
        //IntroPanelText.text = "As siblings of an influential family of Eastern European descent, the \n" +
        //GetWords(GLOBALS.playerCount) + " of us have received a not - insignificant portion of our family's estate. \n Before we begin, let us make this historical fiction more engaging by providing our names.";
        IntroPanelText.text = introPanelText1[PlayerPrefs.GetInt("language", 0)] + " " + GetWord(GLOBALS.playerCount) + " " + introPanelText2[PlayerPrefs.GetInt("language", 0)];
        playerIntroAnim.Play("PlayerIntro");
    }
    public void SetCurrentStoryPassage(string PassageName) => TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);

    IEnumerator LateAssignName(TextMeshProUGUI TxtInput, string _playerName, float delay)
    {
        yield return new WaitForSeconds(delay);
        TxtInput.text = _playerName;
    }
    public void AssignPlayerNamesAfterAnim()
    {
        PlayerNameIntro.gameObject.SetActive(true);
        playerIntroAnim.gameObject.SetActive(false);
        PlayerNameIntro.Play("PlayerNameIntro");
        int _playerCount = ViewPlayerNameEnter.instance.playerIndex - 1;
        switch (_playerCount)
        {
            case 0:
                //playerIntroText.text= "Our warmest regards.";
                playerIntroText.text = introText1[PlayerPrefs.GetInt("language", 0)];
                StartCoroutine(LateAssignName(playerNameTextList[0], GLOBALS.nameA/*.ToUpper()*/, 0));
                break;
            case 1:
                //playerIntroText.text = "Please enjoy your experience.";
                playerIntroText.text = introText2[PlayerPrefs.GetInt("language", 0)];
                StartCoroutine(LateAssignName(playerNameTextList[0], GLOBALS.nameB/*.ToUpper()*/, 0));
                break;
            case 2:
                //playerIntroText.text = "May your name live in infamy.";
                playerIntroText.text = introText3[PlayerPrefs.GetInt("language", 0)];
                StartCoroutine(LateAssignName(playerNameTextList[0], GLOBALS.nameC/*.ToUpper()*/, 0));
                break;
            case 3:
                //playerIntroText.text = "Be sure to leave your mark on the world.";
                playerIntroText.text = introText4[PlayerPrefs.GetInt("language", 0)];
                StartCoroutine(LateAssignName(playerNameTextList[0], GLOBALS.nameD/*.ToUpper()*/, 0));
                break;
            case 4:
                //playerIntroText.text = "Be sure to leave your mark on the world.";
                playerIntroText.text = introText5[PlayerPrefs.GetInt("language", 0)];
                StartCoroutine(LateAssignName(playerNameTextList[0], GLOBALS.nameE/*.ToUpper()*/, 0));
                break;
            default:
                print("Incorrect Player Count.");
                break;
        }
    }

    public string GetWord(int number)
    {
        return LanguageWiseNumberWord[PlayerPrefs.GetInt("language", 0)].numbers[number - 2];
    }

    #endregion
}

[System.Serializable]
public class Numbers
{
    public string[] numbers = new string[4];
}