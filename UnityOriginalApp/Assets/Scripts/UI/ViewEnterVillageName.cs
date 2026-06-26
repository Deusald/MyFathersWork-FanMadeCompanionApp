using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class ViewEnterVillageName : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewEnterVillageName instance;
    [HideInInspector]
    public AudioClip clip;
    [HideInInspector]
    public Button continueBtn;
    [HideInInspector]
    public TMP_InputField VillageNameIF;
    [HideInInspector]
    public GameObject goBackConfirmationPanel;
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();

    #endregion


    #region UNITY_CALLBACKS
    void Start()
        => instance = this;
    #endregion

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        EnableDisableContinueButton(VillageNameIF);
        base.ShowAnimated();
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
        //SetCurrentStoryPassage("NameEntryTownConfirm");
        ViewController.instance.ChangeView(ViewController.instance.villageIntro);
    }

    public void GoBackbtn()
    {
        ShowPopAnimation(goBackConfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
            reWritePanelText[i].UpdateButtonText(index);
    }

    public void HideGoBackbtn() => closePopAnimation(goBackConfirmationPanel);

    public void PlayBGSound(bool status)
    {
        if (status == true)
            SoundManager.Instance.PlayOneTime(clip);
        else
            SoundManager.Instance.Stop();
    }

    IEnumerator EnableButtonAfterDelay(Button button, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
    }
    public void OnEnterVillageName(TMP_InputField Inf)
    {
        GLOBALS.townName = Inf.text;
        if ((Inf.text == null) || (Inf.text == ""))
            return;
        EnableDisableContinueButton(Inf);
    }

    public void EnableDisableContinueButton(TMP_InputField Inf) => continueBtn.interactable = Inf.text.Length > 0;

    public void SetCurrentStoryPassage(string PassageName)
        => Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(PassageName);


    public void OnBackBtnPress()
    {
        ViewPlayerNameEnter.instance.playerIndex = GLOBALS.playerCount - 1;
        ViewController.instance.ChangeView(ViewController.instance.PlayerSelection);
    }

    public void OnValidateInputField(TMP_InputField field)
    {
        field.text = Regex.Replace(field.text, @" {2,}", " ");
    }

    #endregion

    #region PRIVATE_METHODS

    #endregion
}
