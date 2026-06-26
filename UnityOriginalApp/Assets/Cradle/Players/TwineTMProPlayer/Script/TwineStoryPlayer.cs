using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cradle;
using TMPro;
using Cradle.StoryFormats.Harlowe;
using System;

namespace Cradle.Players
{
    public class TwineStoryPlayer : MonoBehaviour
    {
        public static TwineStoryPlayer instance;
        public string currentpassageName;
        public List<string> storyPassageList = new List<string>();
        public List<string> abortPassageList = new List<string>();
        Story story;
        public int currentPassageIndex;
        public bool StartStory = true;
        public bool switchToGeneration = false;
        public Button genHubbackBtn, genHubforwardBtn;
        public bool isBackPressed = false;
        public string previousPassage = "";

        public static Action s_OnPressGoBack;

        private void Awake() => instance = this;

        void Start()
        {
            OnSetAbortPassagesNameInList();
            this.story = TwineTMProPlayer.instance.Story;
            this.story.OnPassageEnter += PrintStoryPassageName;
            if (StartStory) story.Begin();
        }

        private void OnDestroy() => this.story.OnPassageEnter -= PrintStoryPassageName;

        void PrintStoryPassageName(StoryPassage StoryPassage)
        {
            ViewGenerationEnding.instance.backBtn.interactable = false;
            genHubbackBtn.interactable = false;
            this.InvokeDelay(() =>
            {
                string previousPassage = PlayerPrefs.GetString("PreviousPassageName", "");
                //Debug.Log(previousPassage + " == " + story.CurrentPassage.Name);
                if (previousPassage == "" || previousPassage == story.CurrentPassage.Name)
                {
                    ViewGenerationEnding.instance.backBtn.interactable = false;
                    genHubbackBtn.interactable = false;
                }
                else
                {
                    ViewGenerationEnding.instance.backBtn.interactable = true;
                    genHubbackBtn.interactable = true;
                }
                if ((story.CurrentPassage.Name == "Preparations-TCOD" || story.CurrentPassage.Name == "ScenarioBox-FOTU" || story.CurrentPassage.Name == "ATOW-Preparations") && previousPassage == "")
                {
                    ViewGenerationEnding.instance.backBtn.interactable = true;
                    genHubbackBtn.interactable = true;
                }
            }, 0.25f);
            //currentpassageName = story.CurrentPassage.Name;
            //if (!storyPassageList.Contains(currentpassageName) && abortPassageList.FindIndex(i => i == currentpassageName) == -1 && currentpassageName != "TITLE SCREEN")
            //{
            //    if (isBackPressed)
            //    {
            //        currentPassageIndex++;
            //        storyPassageList.Insert(currentPassageIndex, currentpassageName);
            //        if (currentPassageIndex < storyPassageList.Count)
            //        {
            //            storyPassageList.RemoveRange(currentPassageIndex + 1, storyPassageList.Count - (currentPassageIndex + 1));
            //        }
            //        CheckForwardBackwordStatus(currentPassageIndex);
            //    }
            //    else
            //    {
            //        if (storyPassageList.Count > 0 && currentPassageIndex >= 0 && currentPassageIndex != storyPassageList.Count - 1)
            //        {
            //            string p = storyPassageList[currentPassageIndex];
            //            Debug.Log("passage p ::: " + p);
            //            storyPassageList.RemoveAt(currentPassageIndex);
            //            storyPassageList.Add(p);
            //        }
            //        storyPassageList.Add(currentpassageName);
            //        currentPassageIndex = storyPassageList.Count - 1;
            //        CheckForwardBackwordStatus(currentPassageIndex);
            //        isBackPressed = false;
            //    }
            //}
            //else
            //{
            //    int passage_index = storyPassageList.FindIndex(i => i == currentpassageName);
            //    if (passage_index > -1) { CheckForwardBackwordStatus(passage_index); currentPassageIndex = passage_index; }
            //}
        }

        public void GoBack()
        {
            //int tempIndex = storyPassageList.FindIndex(i => i == currentpassageName);
            //currentPassageIndex = tempIndex > -1 ? tempIndex : currentPassageIndex;
            previousPassage = PlayerPrefs.GetString("PreviousPassageName", "");
            if (story.CurrentPassage.Name == "Preparations-TCOD" || story.CurrentPassage.Name == "ScenarioBox-FOTU" || story.CurrentPassage.Name == "ATOW-Preparations")
            {
                ViewController.instance.ChangeView(ViewController.instance.scenarios);
            }
            else if (previousPassage != "")
            {
                s_OnPressGoBack?.Invoke();
                GoToCurrentProgress(previousPassage);
                //currentPassageIndex--;
                //isBackPressed = true;
                //previousPassage = storyPassageList[currentPassageIndex];
                //GoToCurrentProgress(storyPassageList[currentPassageIndex]);
            }
            //CheckForwardBackwordStatus(currentPassageIndex);
        }
        public void GoForward()
        {
            currentPassageIndex = storyPassageList.FindIndex(i => i == currentpassageName);
            if (currentPassageIndex < storyPassageList.Count - 1)
            {
                currentPassageIndex++;
                GoToCurrentProgress(storyPassageList[currentPassageIndex]);
                if (currentPassageIndex == storyPassageList.Count)
                    isBackPressed = false;
            }
            CheckForwardBackwordStatus(currentPassageIndex);
        }

        public void CheckForwardBackwordStatus(int currentIndex)
        {
            if (currentIndex < 1)
            {
                ViewGenerationEnding.instance.backBtn.interactable = false;
                genHubbackBtn.interactable = false;
            }
            else
            {
                StartCoroutine(DelayInteractable(ViewGenerationEnding.instance.backBtn));
                StartCoroutine(DelayInteractable(genHubbackBtn));
            }

            if (story.CurrentPassage.Name == "Preparations-TCOD" || story.CurrentPassage.Name == "ScenarioBox-FOTU" || story.CurrentPassage.Name == "ATOW-Preparations")
            {
                StartCoroutine(DelayInteractable(ViewGenerationEnding.instance.backBtn));
                StartCoroutine(DelayInteractable(genHubbackBtn));
            }

            if (currentIndex < storyPassageList.Count - 1)
            {
                StartCoroutine(DelayInteractable(ViewGenerationEnding.instance.forwardBtn));
                StartCoroutine(DelayInteractable(genHubforwardBtn));
            }
            else
            {
                ViewGenerationEnding.instance.forwardBtn.interactable = false;
                genHubforwardBtn.interactable = false;
            }
        }

        IEnumerator DelayInteractable(Button button)
        {
            button.interactable = false;
            yield return new WaitForSeconds(1f);
            button.interactable = true;
        }

        public void GoToCurrentProgress(string passageName)
        {
            //Debug.Log("GoToCurrentPassageName ==> " + passageName);
            this.story.GoTo(passageName);
        }

        public void GoToScenarios(int _SIndex)
        {

            DataManager.instance.StartAutoSave();
            switch (_SIndex)
            {
                case 0:
                    PlayerPrefs.SetInt("storyName", (int)StoryName.TheCostofDisease);
                    TwineTMProPlayer.instance.OnChangeStory(StoryName.TheCostofDisease);
                    GLOBALS.generationTitle = "<size=155>I</size>" + "ndustry Forever";
                    OnChange();
                    story.GoTo("Preparations-TCOD");
                    break;
                case 1:
                    PlayerPrefs.SetInt("storyName", (int)StoryName.FearofUnknown);
                    TwineTMProPlayer.instance.OnChangeStory(StoryName.FearofUnknown);
                    GLOBALS.generationTitle = "<size=155>F</size>" + "ear and Politics";
                    OnChange();
                    story.GoTo("ScenarioBox-FOTU");
                    break;
                case 2:
                    PlayerPrefs.SetInt("storyName", (int)StoryName.ATimeofWar);
                    TwineTMProPlayer.instance.OnChangeStory(StoryName.ATimeofWar);
                    GLOBALS.generationTitle = "<size=155>A</size>" + " Time of War";
                    OnChange();
                    story.GoTo("ATOW-Preparations");
                    break;
                case 3:
                    PlayerPrefs.SetInt("storyName", (int)StoryName.TheCostofDisease);
                    TwineTMProPlayer.instance.OnChangeStory(StoryName.TheCostofDisease);
                    GLOBALS.generationTitle = "<size=155>T</size>" + "he Cost of Disease";
                    OnChange();
                    story.GoTo("Preparations-TCOD");
                    break;
                default:
                    print("Incorrect Scenario.");
                    break;

                    void OnChange()
                    {
                        storyPassageList.Clear();
                        currentPassageIndex = 0;
                        this.story.OnPassageEnter -= PrintStoryPassageName;
                        PassageTracker.instance.OnStoryChange();
                        this.story = TwineTMProPlayer.instance.Story;
                        this.story.OnPassageEnter += PrintStoryPassageName;
                    }
            }
        }
        public void OnSetAbortPassagesNameInList() => abortPassageList = PassageTracker.instance.abortPassagesName.ToString().Split('\n').ToList();
    }
}