using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

/// <summary>
/// log book script
/// </summary>
public class ViewLogBook : UIView
{
    #region PUBLIC_VARS
    public static ViewLogBook instance;
    [HideInInspector]
    public Button nextButton, PreviousButton;
    [HideInInspector]
    public List<L_Book> LogBook_UI_List = new List<L_Book>();
    [HideInInspector]
    public List<Button> journalSetupBtn = new List<Button>();
    public LogBookTitle logBookTitle;
    LogBookTitleData bookTitledata = new LogBookTitleData();
    public List<string> LoadAllTitle = new List<string>();
    public static string TitleName { get; set; }
    public static bool IsHubPanel { get; set; }
    private readonly int maxLogdataInPage = 6;
    private int page_No;
    private int index;
    #endregion

    #region UNITY_CALLBACK
    private void Start()
    {
        instance = this;
        if (PlayerPrefs.HasKey("LogBookTitle"))
            DataManager.instance.LoadLogBookDataFromJSON();

        LoadAllTitle = CSVtoData.instance.LoadAllTitle();
    }
    #endregion

    #region PUBLIC_METHOD
    public override void ShowAnimated()
    {
        base.ShowAnimated();
        index = logBookTitle.logBookTitlelist.Count;
        if (logBookTitle.logBookTitlelist.Count > 0 && logBookTitle.logBookTitlelist[index - 1].logBookTitle == TitleName) index -= 1;
        page_No = 1;
        ClearUIText();
        if (index > 0)
        {
            if (index > maxLogdataInPage)
            {
                SetDataInUI(0, maxLogdataInPage);
                nextButton.interactable = true;
            }
            else
            {
                SetDataInUI(0, index);
                nextButton.interactable = false;
            }
        }
        else
            nextButton.interactable = false;
        PreviousButton.interactable = false;
    }
    public override void HideAnimated() => base.HideAnimated();
    public override void Hide() => base.Hide();

    /// <summary>
    /// store log book title in list
    /// </summary>
    /// <param name="title"></param>
    public void SaveLogBookTitle(string title)
    {
        TitleName = title;

        if (title != null && LoadAllTitle.Contains(title))
        {
            int isTitleExist = 0;
            int _index = logBookTitle.logBookTitlelist.Count;
            bookTitledata = new LogBookTitleData(_index, title);
            //for (int i = 0; i < _index; i++)
            //	if (logBookTitle.logBookTitlelist[i].logBookTitle.Contains(title))
            //		isTitleExist++;

            isTitleExist = logBookTitle.logBookTitlelist.Where(i => i.logBookTitle.Contains(title)).Count();


            if (isTitleExist == 0)
            {
                logBookTitle.logBookTitlelist.Add(bookTitledata);
                DataManager.instance.SaveLogBookData();
            }
        }
    }

    /// <summary>
    /// adding text in text ui
    /// </summary>
    /// <param name="min_index"></param>
    /// <param name="max_index"></param>
    public void SetDataInUI(int min_index, int max_index)
    {
        int x = 0;
        ClearUIText();
        int lanIndex = 3 * PlayerPrefs.GetInt("language", 0); //language index 
        for (int i = min_index; i < max_index; i++)
        {
            string s = CSVtoData.instance.GetString(logBookTitle.logBookTitlelist[i].logBookTitle);
            if (s != null)
            {
                string[] splitedata = s.Split(',');
                if (splitedata[0] == "Financial Woes")
                    splitedata[lanIndex + 2] = splitedata[lanIndex + 2].Replace("Xvillage", GLOBALS.townName);
                LogBook_UI_List[x].title.SetText(splitedata[lanIndex + 0]);
                LogBook_UI_List[x].location.SetText(splitedata[lanIndex + 1]);
                LogBook_UI_List[x].details.SetText(splitedata[lanIndex + 2]);
                LogBook_UI_List[x].Icon.enabled = true;
                LogBook_UI_List[x].Icon.sprite = Cradle.Players.PassageTracker.instance.ReturnIconSprite(splitedata[0]);
                journalSetupBtn[x].interactable = true;
                x++;
            }
        }
    }

    /// <summary>
    /// clear text in text ui
    /// </summary>
    public void ClearUIText()
    {
        for (int i = 0; i < maxLogdataInPage; i++)
        {
            LogBook_UI_List[i].title.SetText("");
            LogBook_UI_List[i].location.SetText("");
            LogBook_UI_List[i].details.SetText("");
            LogBook_UI_List[i].scrollbar.value = 1;
            LogBook_UI_List[i].Icon.enabled = false;
            journalSetupBtn[i].interactable = false;
        }
    }

    /// <summary>
    /// next page open when press next button
    /// </summary>
    public void OnNextButtonPress()
    {
        if (page_No * maxLogdataInPage < index)
        {
            page_No++;
            if (page_No * maxLogdataInPage < index)
                SetDataInUI((page_No - 1) * maxLogdataInPage, page_No * maxLogdataInPage);
            else
            {
                SetDataInUI((page_No - 1) * maxLogdataInPage, index);
                nextButton.interactable = false;
            }
            PreviousButton.interactable = true;
        }
        else
            nextButton.interactable = false;
    }

    /// <summary>
    /// previous page open when press previous button
    /// </summary>
    public void OnPreviousButtonPress()
    {
        page_No--;
        if (page_No > 0)
        {
            SetDataInUI((page_No - 1) * maxLogdataInPage, page_No * maxLogdataInPage);
            if (page_No == 1)
                PreviousButton.interactable = false;
        }
        else
            PreviousButton.interactable = false;
        nextButton.interactable = true;
    }

    /// <summary>
    /// go to generation ending page
    /// </summary>
    public void OnGoToGenerationEnding()
        => ViewController.instance.ChangeView(IsHubPanel ? ViewController.instance.generations : ViewController.instance.generationEnding);

    public void OnSetUpbtn(int x)
    {
        ViewItemObtainHUB.instance.SetupItemObtain("Setup", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", 0);
    }

    #endregion
}
