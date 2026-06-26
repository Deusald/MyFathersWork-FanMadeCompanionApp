using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLocalText : MonoBehaviour
{
    public static ButtonLocalText instance;
    //[HideInInspector]
    public List<string> buttonTextList = new List<string>();
    private TextMeshProUGUI text;
    //[HideInInspector]
    public bool isButton = false;

    private void Awake() => instance = this;

    void Start() => UpdateButtonText(PlayerPrefs.GetInt("language", 0));

    public void UpdateButtonText(int selectedLanIndex)
    {
        text = isButton ? transform.GetChild(0).GetComponent<TextMeshProUGUI>() : transform.GetComponent<TextMeshProUGUI>();
        text.text = buttonTextList[selectedLanIndex];
    }
}
