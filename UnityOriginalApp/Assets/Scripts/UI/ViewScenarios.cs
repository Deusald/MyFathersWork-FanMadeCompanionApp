using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ViewScenarios : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewScenarios instance;
    [HideInInspector]
    public TextMeshProUGUI scenarioInfoText;
    [HideInInspector]
    public GameObject goBackConfirmationPanel;
    [HideInInspector]
    public string[] playerText = new string[7];
    [HideInInspector]
    public string[] chooseText = new string[7];
    [HideInInspector]
    public List<ButtonLocalText> reWritePanelText = new List<ButtonLocalText>();

    #endregion


    #region UNITY_CALLBACKS
    void Start()
    {
        instance = this;
    }
    #endregion 

    #region PUBLIC_METHODS

    public override void ShowAnimated()
    {
        SetScenarioText();
        base.ShowAnimated();
    }
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide() => base.Hide();
    public void OnBackBtnPress() => ViewController.instance.ChangeView(ViewController.instance.villageIntro);

    public void GoBackbtn()
    {
        ShowPopAnimation(goBackConfirmationPanel);
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < reWritePanelText.Count; i++)
            reWritePanelText[i].UpdateButtonText(index);
    }

    public void HideGoBackbtn() => closePopAnimation(goBackConfirmationPanel);

    public void SetScenarioText()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        scenarioInfoText.text = chooseText[index] + " " + GLOBALS.playerCount + " " + playerText[index];
    }
    public void onScenariosBtn() => ViewController.instance.ChangeView(ViewController.instance.generationEnding);
    public void GotoScenarios(int _sIndex)
    {
        Debug.Log("Scenario index : " + _sIndex.ToString());
        ViewGenerationEnding.instance.OnChangeBackground(_sIndex);
        ViewGenerationEnding.instance.ClearListatStartStory();
        Cradle.Players.TwineStoryPlayer.instance.GoToScenarios(_sIndex);
    }

    #endregion

    #region PRIVATE_METHODS

    #endregion
}
