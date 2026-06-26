using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewGenerationTitle : UIView
{

    #region PUBLIC_VARS

    //Static Instace
    public static ViewGenerationTitle instance;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI generationText;
    public GameObject continueBtn;
    #endregion

    #region PRIVATE_VARS


    #endregion

    #region UNITY_CALLBACKS
 

    void Start()
    {
        instance = this;
    }
	#endregion

	#region PUBLIC_METHODS
	public override void ShowAnimated() => base.ShowAnimated();//SetScrollData();
	public override void HideAnimated() => base.HideAnimated();
	public override void Hide() => base.Hide();
	public void ShowContinueBtn() => continueBtn.SetActive(true);
	public void OnGenerationBtn() => ViewController.instance.ChangeView(ViewController.instance.mainMenu);
	public void SetGenerationTitle(string _title) => titleText.text = _title;
    
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
