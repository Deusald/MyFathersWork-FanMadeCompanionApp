using UnityEngine;
using TMPro;
using Cradle.Players;

public class ViewEndOfRound : UIView
{
    public static ViewEndOfRound instance;
    //[HideInInspector]
    public TextMeshProUGUI EndOFRoundbodyText;
    public TextMeshProUGUI EndOFRoundbodyText2;
    public ButtonLocalText body2text;
    public AudioClip clip;
    private string passageName = "";
    private readonly float progressMulti = 1 / 9f;

    private void Start() => instance = this;

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        ViewItemObtainHUB.isEndOfRoundOpen = gameObject.GetComponent<Canvas>().enabled;
        if (clip != null)
            SoundManager.Instance.OnOpenPopupPlayAudio(clip);
    }
    public override void HideAnimated()
    {
        ViewItemObtainHUB.isEndOfRoundOpen = false;
        base.HideAnimated();
    }

    public override void Hide()
    {
        ViewItemObtainHUB.isEndOfRoundOpen = false;
        base.Hide();
    }
    public override void Show() => base.Show();


    public void SetEndOfRound(string bodyText, int CompletedRound, string passageName, string bodyText2)
    {
        this.passageName = passageName;
        float process = -1;
        if (CompletedRound > 0)
            process = 1 - (progressMulti * (CompletedRound + 1));
        if (PlayerPrefs.GetFloat("Progress", (1 - progressMulti)) != process)
        {
            if (CompletedRound > 0)
                PlayerPrefs.SetFloat("Progress", process);
            EndOFRoundbodyText.SetText(bodyText);
            EndOFRoundbodyText2.SetText(bodyText2);
            Invoke(nameof(ShowAnimated), 0.25f);
        }
        else
        {
            Invoke(nameof(OnChangePassage), 0.1f);
        }
    }

    public void OnConfirmbtn()
    {
        float progress = PlayerPrefs.GetFloat("Progress", (1 - progressMulti));
        ViewGeneration.instance.OnChangeProgressBar(progress);
        ViewGenerationEnding.instance.OnChangeProgressBar(progress);
        ViewItemObtainHUB.isEndOfRoundOpen = false;
        ViewItemObtainHUB.instance.ShowAnimated();
        Invoke(nameof(Hide), 0.1f);
        Invoke(nameof(OnChangePassage), 0.5f);
    }

    public void OnChangePassage() => TwineStoryPlayer.instance.GoToCurrentProgress(passageName);
}