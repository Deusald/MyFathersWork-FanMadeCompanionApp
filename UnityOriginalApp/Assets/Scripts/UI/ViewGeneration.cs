using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ViewGeneration : UIView
{

    #region PUBLIC_VARS
    public static ViewGeneration instance;
    [HideInInspector]
    public TextMeshProUGUI titleText;
    [HideInInspector]
    public Image borderImg;
    [HideInInspector]
    public Sprite gen1, gen2, gen3;
    [HideInInspector]
    public TextMeshProUGUI contentText;
    [HideInInspector]
    public GameObject goBackConfirmationpanel, goForwardConfirmationPanel;
    [HideInInspector]
    public Slider progressBar;
    [HideInInspector]
    public List<ButtonLocalText> pauseMenuText = new List<ButtonLocalText>();
    [HideInInspector]
    public GameObject pausePopup;
    [HideInInspector]
    public GameObject collapsiblePrefab;
    [HideInInspector]
    public GameObject MainScrollViewContent;
    public List<HubData> hubPageData = new List<HubData>();
    List<GameObject> GeneratedPrefabList = new List<GameObject>();
    [HideInInspector]
    public Scrollbar MainScrollbar;
    #endregion
    #region PRIVATE_VARS


    #endregion

    #region UNITY_CALLBACKS


    void Start()
    {
        instance = this;
        progressBar.value = PlayerPrefs.GetFloat("Progress", 1);
    }
    #endregion

    #region PUBLIC_METHODS
    public override void ShowAnimated()
    {
        base.ShowAnimated();
        AudioClip clip = ViewGenerationEnding.instance.clip[ViewGenerationEnding.StoryIndex];
        if (clip != null && clip.name != SoundManager.Instance.MusicSource.clip.name)
            SoundManager.Instance.PlayMusic(clip);
    }
    public override void HideAnimated() => base.HideAnimated();

    public void CheckGenerationBordar(int Index)
    {
        switch (Index)
        {
            case 0:
                borderImg.sprite = gen1;
                break;
            case 1:
                borderImg.sprite = gen2;
                break;
            case 2:
                borderImg.sprite = gen3;
                break;
            default:
                borderImg.sprite = gen1;
                print("default");
                break;
        }
    }

    public override void Hide() => base.Hide();
    public void ChnageTitleOfGenerationPanel(string _Title) => titleText.text = _Title;

    public void OnGenerationEndingBtn()
    {
        ViewGenerationEnding.instance.ClearListatStartStory();
        if (Cradle.Players.TwineStoryPlayer.instance.switchToGeneration == false)
            Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress("Preface-TCOD");
        else
            Cradle.Players.TwineStoryPlayer.instance.GoToCurrentProgress(GLOBALS.currentPassageName);
        ViewController.instance.ChangeView(ViewController.instance.generationEnding);
    }

    public void GoBackBtn() => ShowPopAnimation(goBackConfirmationpanel);
    public void GoForwardBtn() => ShowPopAnimation(goForwardConfirmationPanel);

    IEnumerator DelayInteractable(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(1f);
        button.interactable = true;
    }

    public void HideBackbtn() => closePopAnimation(goBackConfirmationpanel);
    public void HideForwardbtn() => closePopAnimation(goForwardConfirmationPanel);

    public void DisableContent()
    {
        contentText.GetComponent<TextMeshProUGUI>().alpha = 0;
        titleText.GetComponent<TextMeshProUGUI>().alpha = 0;
        Invoke(nameof(EnableContent), 2f);
    }
    public void EnableContent() => contentText.GetComponent<TextMeshProUGUI>().alpha = titleText.GetComponent<TextMeshProUGUI>().alpha = 255;

    public void OnChangeProgressBar(float progress) => StartCoroutine(OnChangeValueOfProgress(progressBar.value, progress));

    public void OnFillData()
    {
        if (GeneratedPrefabList.Count > 0)
            foreach (GameObject prefab in GeneratedPrefabList)
                Destroy(prefab);
        //Debug.Log("Hub data Count : <color=red> "+ hubPageData.Count +"</color>");
        foreach (var data in hubPageData)
        {
            GameObject collapsPanel = Instantiate(collapsiblePrefab, MainScrollViewContent.transform);
            CollapsPanel prefabScript = collapsPanel.GetComponent<CollapsPanel>();
            prefabScript.titleText.SetText(data.titleName);
            prefabScript.detailsText.SetText(data.details);
            if (String.IsNullOrEmpty(data.titleName.ToString())) prefabScript.titleText.gameObject.SetActive(false);
            GeneratedPrefabList.Add(collapsPanel);
        }
        MainScrollbar.value = 1;
        hubPageData.Clear();
    }

    IEnumerator OnChangeValueOfProgress(float start, float finish)
    {
        float t = 0;
        while (t <= 1)
        {
            t += (Time.deltaTime * 2);
            progressBar.value = Mathf.Lerp(start, finish, t);
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnPauseOpen()
    {
        ShowPopAnimation(pausePopup);
        PauseMenuTextChanges();
        GraphicManager.instance.Quality();
    }
    public void OnPauseClose() => closePopAnimation(pausePopup);

    public void PauseMenuTextChanges()
    {
        int index = PlayerPrefs.GetInt("language", 0);
        for (int i = 0; i < pauseMenuText.Count; i++)
            pauseMenuText[i].UpdateButtonText(index);
    }

    public void GoToMainScreen()
    {
        ViewController.instance.ChangeView(ViewController.instance.mainMenu);
        OnPauseClose();
        Invoke(nameof(LateSceneLoading), 0.7f);
    }

    public void OnLogBookButtonPress()
    {
        ViewLogBook.IsHubPanel = true;
        ViewController.instance.ChangeView(ViewController.instance.logBook);
    }

    public void LateSceneLoading() => SceneManager.LoadScene(0);

    #endregion

    #region PRIVATE_METHODS

    #endregion
}
