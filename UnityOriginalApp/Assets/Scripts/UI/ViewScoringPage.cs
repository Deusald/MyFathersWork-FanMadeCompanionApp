using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScoringPage : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewScoringPage instance;


	#endregion
	#region PRIVATE_VARS


	#endregion

	#region UNITY_CALLBACKS


	void Start() => instance = this;
	#endregion

	#region PUBLIC_METHODS
	public override void ShowAnimated() => base.ShowAnimated();
	public override void HideAnimated() => base.HideAnimated();
	public override void Hide() => base.Hide();
	public void OnScoringPageContinueBtn() => ViewController.instance.ChangeView(ViewController.instance.endings);

	#endregion

	#region PRIVATE_METHODS

	#endregion
}
