using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cradle.Players;

public class ViewEndOfGeneration : UIView
{
    [HideInInspector] public AudioClip clip;
    [HideInInspector] public TextMeshProUGUI RuleText;
    public TextMeshProUGUI titleText;
    public ButtonLocalText endOfGeneration;
    private string Passagename = "";
    private float progressMulti = 1 / 9f;
    private string PassageName = "";
    public static Action<string, int> S_OnEndOfGeneration;
    public static Action<string, int, string, string> S_OnSetSpecialSetup;

    void OnEnable()
    {
        S_OnEndOfGeneration += OnEndOfGeneration;
        S_OnSetSpecialSetup += OnSetSpecialSetup;
    }

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        if (clip != null) SoundManager.Instance.OnOpenPopupPlayAudio(clip);
    }

    public override void Hide() => base.Hide();

    public void OnEndOfGeneration(string ruleDetails, int Progress)
    {
        float process = 1 - (progressMulti * (Progress + 1));
        PassageName = "";
        if (PlayerPrefs.GetFloat("Progress", (1 - progressMulti)) != process)
        {
            titleText.text = endOfGeneration.buttonTextList[PlayerPrefs.GetInt("language", 0)];
            if (Progress > -1)
                PlayerPrefs.SetFloat("Progress", process);
            RuleText.text = ruleDetails;
            Invoke(nameof(ShowAnimated), 0.1f);
        }
    }

    public void OnSetSpecialSetup(string titleName, int completedRound, string passageName, string bodyText)
    {
        PassageName = passageName;
        float process = 1 - (progressMulti * (completedRound + 1));
        if (PlayerPrefs.GetFloat("Progress", (1 - progressMulti)) != process)
        {
            titleText.text = titleName;
            if (completedRound > -1)
                PlayerPrefs.SetFloat("Progress", process);
            RuleText.text = bodyText;
            Invoke(nameof(ShowAnimated), 0.1f);
        }
        else
        {
            this.InvokeDelay(() => TwineStoryPlayer.instance.GoToCurrentProgress(passageName), 0.1f);
        }
    }

    public void OnConfirmBtn()
    {
        float progress = PlayerPrefs.GetFloat("Progress", 0.667f);
        ViewGeneration.instance.OnChangeProgressBar(progress);
        ViewGenerationEnding.instance.OnChangeProgressBar(progress);
        if (!String.IsNullOrEmpty(PassageName) || PassageName != "")
        {
            this.InvokeDelay(() => TwineStoryPlayer.instance.GoToCurrentProgress(PassageName), 0.5f);
        }
        Invoke(nameof(Hide), 0.2f);
    }

    void OnDisable()
    {
        S_OnEndOfGeneration -= OnEndOfGeneration;
        S_OnSetSpecialSetup -= OnSetSpecialSetup;
    }
}
