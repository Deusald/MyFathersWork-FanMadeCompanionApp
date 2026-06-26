using System.Collections;
using UnityEngine;

public class ViewHelp : UIView
{
    public static ViewHelp instance;
    [HideInInspector]
    public GameObject endOfRoundPanel;
    [HideInInspector]
    public GameObject storyActionsPanel;
    public AudioClip clip;

    public override void Hide() => base.Hide();
    public override void Show() => base.Show();

    public void OnOpenHelp()
    {
        ViewController.instance.ChangeView(ViewController.instance.help);
        SoundManager.Instance.PlayMusic(clip);
    }

    private IEnumerator Start()
    {
        instance = this;
        yield return new WaitForSeconds(1);
        endOfRoundPanel.SetActive(false);
        storyActionsPanel.SetActive(false);
    }

    public void OnPressBackBtn()
        => ViewController.instance.ChangeView(ViewController.instance.mainMenu);
}
