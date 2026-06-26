using UnityEngine;
using UnityEngine.UI;
using Cradle.Players;
using TMPro;

public class CollapsPanel : MonoBehaviour
{
    [HideInInspector] public GameObject detailPanel;
    [HideInInspector] public Image btnImage;
    [HideInInspector] public Sprite dropDownSprite;
    [HideInInspector] public Sprite HideSprite;
    [HideInInspector] public TextMeshProUGUI titleText;
    [HideInInspector] public TextMeshProUGUI detailsText;
    public RectTransform detailsPanel1Rect;

    public void OnPressbtn()
    {
        detailPanel.SetActive(!detailPanel.activeSelf);
        btnImage.sprite = detailPanel.activeSelf ? HideSprite : dropDownSprite;
    }

    public void OnPressLink(string name) => TwineTMProPlayer.instance.DoLink(name);
}
