using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cradle.Players;
using Cradle;
using Cradle.StoryFormats.Harlowe;
using TMPro;
using System;
using System.Linq;
using Febucci.UI;
namespace Cradle.Players
{
    public class PassageTracker : MonoBehaviour
    {
        public static PassageTracker instance;

        public static Action<AudioClip> s_OnPlayVO;
        public static Action s_OnStopVO;
        public static Action s_OnDataSave;

        [HideInInspector]
        public Story Story;
        //[HideInInspector]
        public List<string> genHubEPassageList = new List<string>();
        //[HideInInspector]
        public List<string> genHubMPassageList = new List<string>();
        //[HideInInspector]
        public List<string> genHubLPassageList = new List<string>();
        //[HideInInspector]
        public List<string> scoringPassageList = new List<string>();
        //[HideInInspector]
        public List<string> endingPassageList = new List<string>();
        //[HideInInspector]
        public List<string> ignorPassageNameList = new List<string>();
        //[HideInInspector]
        public List<string> genIntroPassageNameList = new List<string>();
        [HideInInspector]
        public TextAsset abortPassagesName;
        //[HideInInspector]
        public List<LocationIndicator> locationIndicators = new List<LocationIndicator>();
        [HideInInspector]
        public Image icon;
        [HideInInspector]
        public TextMeshProUGUI storyContentObject;
        [HideInInspector]
        public TextMeshProUGUI titleObject;
        public VOAudioFileScriptable VOAudioFile;
        public string passageName;
        public string currentPassageName;

        //[HideInInspector]
        public List<EndOfGenerationProgreess> progress = new List<EndOfGenerationProgreess>();
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            Story = TwineTMProPlayer.instance.Story;
            this.Story.OnPassageEnter += OnPassageStatus;
        }

        public void OnStoryChange()
        {
            this.Story.OnPassageEnter -= OnPassageStatus;
            Story = TwineTMProPlayer.instance.Story;
            this.Story.OnPassageEnter += OnPassageStatus;
        }

        void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TwineStoryPlayer.instance.GoToCurrentProgress(passageName);
            }
#endif
        }

        void OnDestroy()
        {
            if (!Application.isPlaying)
                return;

            if (this.Story != null)
            {
                this.Story.OnPassageEnter -= OnPassageStatus;
            }
        }
        void OnPassageStatus(StoryPassage StoryPassage)
        {
            string passageName = this.Story.CurrentPassage.Name.ToString();
            Debug.Log("passage : <color=red>" + passageName + "</color>");
            currentPassageName = passageName;
            CheckPassageName(passageName);
            //CheckProgress(passageName);
            ViewLogBook.TitleName = "";
            s_OnStopVO?.Invoke();
            if (passageName != "TITLE SCREEN") this.InvokeDelay(() => s_OnDataSave?.Invoke(), 0.2f);
            ViewGenerationEnding.instance.SetBorder(genIntroPassageNameList.Exists(i => i == passageName));
            this.InvokeDelay(() => OnPlayVOAudioFile(passageName), 0.1f);
        }

        public void CheckPassageName(string passageName)
        {
            if (passageName.Equals("Preparations-TCOD") || passageName.Equals("ScenarioBox-FOTU") || passageName.Equals("ATOW-Preparations"))
            {
                storyContentObject.gameObject.GetComponent<TextAnimatorPlayer>().useTypeWriter = true;
            }
            else
            {
                storyContentObject.gameObject.GetComponent<TextAnimatorPlayer>().useTypeWriter = false;
            }

            //string passageName = this.Story.CurrentPassage.Name.ToString();
            if (passageName.Equals("TCOD-NameEntryTownConfirm"))
            {
                ViewController.instance.ChangeView(ViewController.instance.villageIntro);
                return;
            }
            if (ignorPassageNameList.Contains(passageName))
            {

            }
            else if (passageName.Equals("GoToMainMenu"))
            {
                ViewController.instance.ChangeView(ViewController.instance.mainMenu);
            }
            else if (scoringPassageList.Contains(passageName))
            {
                CheckCurrentViewToClear();
                ViewController.instance.ChangeView(ViewController.instance.rankingPage);
            }
            else if (genHubEPassageList.Contains(passageName))
            {
                CheckCurrentViewToClear();
                ViewGeneration.instance.CheckGenerationBordar(0);
                ViewController.instance.ChangeView(ViewController.instance.generations);
            }
            else if (genHubMPassageList.Contains(passageName))
            {
                CheckCurrentViewToClear();
                ViewGeneration.instance.CheckGenerationBordar(1);
                ViewController.instance.ChangeView(ViewController.instance.generations);
            }
            else if (genHubLPassageList.Contains(passageName))
            {
                CheckCurrentViewToClear();
                ViewGeneration.instance.CheckGenerationBordar(2);
                ViewController.instance.ChangeView(ViewController.instance.generations);
            }
            else
            {
                if (ViewController.instance.currentView != ViewController.instance.generationEnding)
                {
                    CheckCurrentViewToClear();
                    ViewController.instance.ChangeView(ViewController.instance.generationEnding);
                }
            }
            if (endingPassageList.Contains(passageName))
            {
                Invoke(nameof(LateSaveEndings), 1.25f);
            }
        }

        /// <summary>
        /// set indicator icon in generation ending page
        /// </summary>
        /// <param name="titleName"></param>
        public void SetLocationIndicatorIcon(string titleName)
        {
            ViewLogBook.instance.SaveLogBookTitle(titleName);
            icon.sprite = locationIndicators.Where(location => location.titleName == titleName).Select(i => i.titleIcon).First();
        }

        /// <summary>
        /// return sprite to log bbok
        /// </summary>
        /// <param name="titleName"></param>
        /// <returns></returns>
        public Sprite ReturnIconSprite(string titleName)
        {
            for (int i = 0; i < locationIndicators.Count; i++)
                if (titleName == locationIndicators[i].titleName)
                    return locationIndicators[i].titleIcon;
            return null;
        }


        private void LateSaveEndings()
        {
            //ViewGenerationEnding.instance.SaveEndings();
            ViewGenerationEnding.instance.backBtn.interactable = false;
            ViewGenerationEnding.instance.forwardBtn.interactable = false;
        }

        /// <summary>
        /// check and clear current text content for switching panel
        /// </summary>
        public void CheckCurrentViewToClear()
        {
            if (ViewController.instance.currentView == ViewController.instance.generationEnding)
                ViewGenerationEnding.instance.DisableContent();
            else if (ViewController.instance.currentView == ViewController.instance.generations)
                ViewGeneration.instance.DisableContent();
        }

        public void CheckProgress(string passageName, string nextPassageName)
        {
            int index = progress.FindIndex(i => i.PassageName.FindIndex(x => x == passageName) > -1);

            if (index > -1)
            {
                //Debug.Log($"Index :<color=green> {index} </color>");
                EndOfGenerationProgreess egp = progress[index];
                ViewEndOfRound.instance.SetEndOfRound(egp.Details[PlayerPrefs.GetInt("language", 0)], egp.Progress, nextPassageName, egp.details2[PlayerPrefs.GetInt("language", 0)]);
            }
        }

        public void OnPlayVOAudioFile(string passageName)
        {
            int track = PlayerPrefs.GetInt("AudioTrack", 0);
            AudioData audioData = (track == 0) ? VOAudioFile.MaleAudioDatas.Find(i => i.PassageName == passageName) :
                VOAudioFile.FemaleAudioDatas.Find(i => i.PassageName == passageName);
            if (audioData != null)
                s_OnPlayVO?.Invoke(audioData.clip);
        }
    }
}
