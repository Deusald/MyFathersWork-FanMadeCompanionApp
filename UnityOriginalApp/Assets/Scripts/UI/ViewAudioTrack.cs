using System.Collections;
using System.Collections.Generic;
using Cradle.Players;
using UnityEngine;
using UnityEngine.UI;

public class ViewAudioTrack : UIView
{
    public static ViewAudioTrack instace;

    public Toggle maleToggle;
    public Toggle femaleToggle;
    [HideInInspector]
    public List<string> storyPreparationPassageName = new List<string>();

    private void Start()
    {
        instace = this;
    }

    public override void ShowAnimated()
    {
        base.ShowAnimated();
        OnChangeToggleButton(PlayerPrefs.GetInt("AudioTrack", 0) == 1);
    }

    public void OnChangeToggleButton(bool isfemale)
    {
        if (isfemale) femaleToggle.isOn = true;
        else maleToggle.isOn = true;
    }

    public void OnContinueBtn()
    {
        PlayerPrefs.SetInt("AudioTrack", maleToggle.isOn ? 0 : 1);
        ViewController.instance.ChangeView(ViewController.instance.GamePlayerCounts);
    }
}
