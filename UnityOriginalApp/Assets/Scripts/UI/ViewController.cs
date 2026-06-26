using UnityEngine;
using System.Collections;

public class ViewController : MonoBehaviour
{
    #region VARS

    //Instance
    public static ViewController instance;


    //Current View
    internal UIView currentView;

    public UIView mainMenu, GamePlayerCounts, PlayerSelection, playerIntro, villageEntry, villageIntro, scenarios, generations, generationEnding,
        endings, rankingPage, popupMenu, shareEnding, itemObtain, logBook, endOfRound, endOfGeneration, itemObtainHub, help, biddingSystem, specialEvent, audioTrack,
        scoreEntry, tieBreaker;

    public Animator screenTransitionAnim;

    private bool waiting;

    #endregion

    #region UNITY_CALLBACKS

    void Awake()
    {
        instance = this;
        currentView = mainMenu;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }


    void Start()
    {
        mainMenu.Hide();
        GamePlayerCounts.Hide();
        PlayerSelection.Hide();
        villageEntry.Hide();
        villageIntro.Hide();
        scenarios.Hide();
        audioTrack.Hide();
        playerIntro.Hide();
        generations.Hide();
        generationEnding.Hide();
        endings.Hide();
        rankingPage.Hide();
        popupMenu.Hide();
        shareEnding.Hide();
        itemObtain.Hide();
        itemObtainHub.Hide();
        logBook.Hide();
        endOfRound.Hide();
        endOfGeneration.Hide();
        help.Hide();
        scoreEntry.Hide();
        tieBreaker.Hide();
        biddingSystem.Hide();
        specialEvent.Hide();
        mainMenu.Show();
    }
    #endregion

    #region PUBLIC_METHODS

    /// <summary>
    /// Changes the view.
    /// </summary>
    /// <param name="targetView">Target view.</param>
    public void ChangeView(UIView targetView)
    {
        if (!waiting)
        {
            StopCoroutine(nameof(WaitForSecond));
            StartCoroutine(nameof(WaitForSecond));
            if (currentView != null)
                currentView.HideAnimated();
            //StartCoroutine(ShowNextWindow(targetView));
            currentView = targetView;
            this.InvokeDelay(() =>
            {
                currentView.ShowAnimated();
            }, 1f);
        }
        currentView = targetView;
    }

    IEnumerator WaitForSecond()
    {
        waiting = true;
        yield return new WaitForSeconds(0.5f);
        waiting = false;
    }
    IEnumerator ShowNextWindow(UIView targetView)
    {
        yield return new WaitForSeconds(1f);
        currentView = targetView;
        currentView.ShowAnimated();
    }

    #endregion

    #region PRIVATE_METHODS


    #endregion

}

