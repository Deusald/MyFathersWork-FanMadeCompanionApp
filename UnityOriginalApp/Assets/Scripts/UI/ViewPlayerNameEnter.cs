using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class ViewPlayerNameEnter : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewPlayerNameEnter instance;
    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public Button btnAddPlayer;
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public TMP_InputField playerNameIF;
    [HideInInspector]
    public TextMeshProUGUI tooltipText, descriptionText;
    public int playerIndex = 0;
    [HideInInspector]
    public GameObject goBackconfirmationPanel;
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();

    #endregion


    #region UNITY_CALLBACKS
    void Start() => instance = this;
    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        CurrentPlayerTurn();
        EnableDisableContinueButton(playerNameIF);
        if (clip != null)
            PlayBGSound(true);
    }
    public override void HideAnimated()
    {
        base.HideAnimated();
        SoundManager.Instance.Stop();
    }
    public override void Hide() => base.Hide();

    public void OnAcceptBtn()
    {
        ViewController.instance.ChangeView(ViewController.instance.playerIntro);
        if (playerIndex < GLOBALS.playerCount)
            playerIndex += 1;
        else
            Debug.Log("no need to enter name");
    }

    public void GoBackbtn()
    {
        ShowPopAnimation(goBackconfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
        {
            reWritePanelText[i].UpdateButtonText(index);
        }
    }

    public void HideGoBackbtn() => closePopAnimation(goBackconfirmationPanel);

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    public void WhenClicked()
    {
        continueBtn.interactable = false;
        StartCoroutine(EnableButtonAfterDelay(btnAddPlayer, 2));
    }
    IEnumerator EnableButtonAfterDelay(Button button, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        continueBtn.interactable = true;
    }

    public void SetCurrentStoryPassage(string PassageName) => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);

    public void CurrentPlayerTurn()
    {
        playerNameIF.text = "";
        switch (playerIndex)
        {
            case 0:
                UpdateTooltiptexts("A");
                break;
            case 1:
                UpdateTooltiptexts("B");
                break;
            case 2:
                UpdateTooltiptexts("C");
                break;
            case 3:
                UpdateTooltiptexts("D");
                break;
            case 4:
                UpdateTooltiptexts("E");
                break;
            default:
                break;
        }
    }

    public void UpdateTooltiptexts(string PlayerName)
    {
        string tooltip = "";
        string description = "";
        switch (PlayerPrefs.GetInt("language", 0))
        {
            case 0:
                tooltip = "Carefully pass the storybook to Player " + PlayerName;
                description = "Player " + PlayerName + " - Please enter your given name:";
                break;
            case 1:
                tooltip = "Passez Precautionneusement le livret Histoire au joueur " + PlayerName;
                description = "Joueur " + PlayerName + "- Veuillez entrer votre prénom :";
                break;
          
        }

        tooltipText.text = tooltip;// Player A
        descriptionText.text = description;
    }

    public void CheckInputPlayerName(TMP_InputField Inf)
    {
        EnableDisableContinueButton(Inf);
        switch (playerIndex)
        {
            case 0:
                GLOBALS.nameA = Inf.text;
                if ((Inf.text == null) || (Inf.text == ""))
                    return;
                //SetCurrentStoryPassage("NameEntryA");
                break;
            case 1:
                GLOBALS.nameB = Inf.text;
                if ((Inf.text == null) || (Inf.text == ""))
                    return;
                //SetCurrentStoryPassage("NameEntryB");
                break;
            case 2:
                GLOBALS.nameC = Inf.text;
                if ((Inf.text == null) || (Inf.text == ""))
                    return;
                //SetCurrentStoryPassage("NameEntryC");
                break;
            case 3:
                GLOBALS.nameD = Inf.text;
                if ((Inf.text == null) || (Inf.text == ""))
                    return;
                //SetCurrentStoryPassage("NameEntryD");
                break;
            case 4:
                GLOBALS.nameE = Inf.text;
                if ((Inf.text == null) || (Inf.text == ""))
                    return;
                //SetCurrentStoryPassage("NameEntryE");
                break;
            default:
                print("Incorrect Player Index.");
                break;
        }
    }

    public void EnableDisableContinueButton(TMP_InputField Inf) => continueBtn.interactable = Inf.text.Length > 0;

    public void OnBackBtnPress()
    {
        if (playerIndex == 0)
        {
            ViewController.instance.ChangeView(ViewController.instance.GamePlayerCounts);
        }
        else
        {
            playerIndex = playerIndex - 1;
            ViewController.instance.ChangeView(ViewController.instance.PlayerSelection);
        }
    }

    public void OnValidateInputField(TMP_InputField field)
    {
        field.text = Regex.Replace(field.text, @" {2,}", " ");
    }

    #endregion

}
