using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ViewEndingPage : UIView
{
    #region PUBLIC_VARS

    //Static Instace
    public static ViewEndingPage instance;
    
    #endregion
    #region PRIVATE_VARS
    public TextMeshProUGUI playerNameText ;

	#endregion

	#region UNITY_CALLBACKS

	void Start() => instance = this;

	#endregion

	#region PUBLIC_METHODS
	public override void ShowAnimated()
    {
        SetPlayerName();
        base.ShowAnimated();
    }
	public override void HideAnimated() => base.HideAnimated();
	public override void Hide() => base.Hide();

	public void SetPlayerName()
    {
        GLOBALS.winnerName = PlayerPrefs.GetString("Winner");
        playerNameText.text = GLOBALS.nameA;
    }

    #endregion
}