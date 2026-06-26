using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Cradle;
using Cradle.StoryFormats.Harlowe;
using System.Text;
using TMPro;

namespace Cradle.Players
{
    [ExecuteInEditMode]
    public class TwineTMProPlayer : MonoBehaviour
    {
        public static TwineTMProPlayer instance;

        public List<LanguageWiseStory> StoryList = new List<LanguageWiseStory>();
        public Story Story;
        public TextMeshProUGUI TextUI;
        public TextMeshProUGUI TextUIGeneration;
        public TextMeshProUGUI title;
        public TextMeshProUGUI titleGeneration;

        public TwineTMProStyleSheet StyleSheet, styleSheetHub;
        public Button LinkTemplate;
        public bool StartStory = true;
        public bool ShowNamedLinks = true;
        public bool CollapseLineBreaks = true;
        private string previousPassageName = "";
        private string tempSetupText = "";
        public List<string> setupText = new List<string>();
        private void Awake()
        {
            instance = this;
            foreach (LanguageWiseStory ls in StoryList)
                ls.OnDisableStory();
            int storyNum = PlayerPrefs.GetInt("storyName", 0);
            this.Story = storyNum == (int)StoryName.TheCostofDisease ? StoryList[PlayerPrefs.GetInt("language", 0)].TheCostOfDisease :
                    storyNum == (int)StoryName.FearofUnknown ? StoryList[PlayerPrefs.GetInt("language", 0)].FearOfUnknown : StoryList[PlayerPrefs.GetInt("language", 0)].ATimeOfWar;
            this.Story.enabled = true;
        }

        void Start() => Invoke(nameof(Delay), 0.1f);

        public void OnChangeStory(StoryName name)
        {
            this.Story.OnStateChanged -= Story_OnStateChanged;
            this.Story.enabled = false;
            this.Story = name == StoryName.TheCostofDisease ? StoryList[PlayerPrefs.GetInt("language", 0)].TheCostOfDisease :
                name == StoryName.FearofUnknown ? StoryList[PlayerPrefs.GetInt("language", 0)].FearOfUnknown : StoryList[PlayerPrefs.GetInt("language", 0)].ATimeOfWar;
            this.Story.enabled = true;
            LinkTemplate.gameObject.SetActive(false);
            ((RectTransform)LinkTemplate.transform).SetParent(null);
            LinkTemplate.transform.hideFlags = HideFlags.HideInHierarchy;

            this.Story.OnStateChanged += Story_OnStateChanged;

            if (StartStory)
                this.Story.Begin();
            RefreshText();
        }

        void Delay()
        {
            if (!Application.isPlaying)
                return;

            LinkTemplate.gameObject.SetActive(false);
            ((RectTransform)LinkTemplate.transform).SetParent(null);
            LinkTemplate.transform.hideFlags = HideFlags.HideInHierarchy;

            int storyNum = PlayerPrefs.GetInt("storyName", 0);
            if (this.Story == null)
                this.Story = storyNum == (int)StoryName.TheCostofDisease ? StoryList[PlayerPrefs.GetInt("language", 0)].TheCostOfDisease :
                    storyNum == (int)StoryName.FearofUnknown ? StoryList[PlayerPrefs.GetInt("language", 0)].FearOfUnknown : StoryList[PlayerPrefs.GetInt("language", 0)].ATimeOfWar;
            if (this.Story == null)
            {
                Debug.LogError("Text player does not have a story to play. Add a story script to the text player game object, or assign the Story variable of the text player.");
                this.enabled = false;
                return;
            }

            if (this.TextUI == null)
                this.TextUI = GetComponent<TMPro.TextMeshProUGUI>();
            if (this.TextUI == null)
            {
                Debug.LogError("Text player is missing a reference to TextUI.");
                this.enabled = false;
                return;
            }

            this.Story.OnStateChanged += Story_OnStateChanged;

            if (StartStory)
                this.Story.Begin();
            RefreshText();
        }

        void OnDestroy()
        {
            if (!Application.isPlaying)
                return;

            if (this.Story != null)
                this.Story.OnStateChanged -= Story_OnStateChanged;
        }

        // .....................
        // Clicks

#if UNITY_EDITOR
        void OnValidate()
        {
            if (Application.isPlaying)
                return;

            // In edit mode, disable autoplay on the story if the text player will be starting the story
            if (this.StartStory)
            {
                foreach (Story story in this.GetComponents<Story>())
                    story.AutoPlay = false;
            }
        }
#endif

        public void Clear()
        {
            TextUI.SetText(string.Empty);
            TextUIGeneration.SetText(string.Empty);

        }

        void Story_OnStateChanged(StoryState state)
        {
            if (!state.In(StoryState.Idle, StoryState.Paused))
                return;

            RefreshText();
        }
        string doubleTitleString;
        public void RefreshText()
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder titleString = new StringBuilder(); //for the title name
            StringBuilder setupString = new StringBuilder(); //for setup string
            StringBuilder setupStringEvnt = new StringBuilder(); // for setup in event pages
            StringBuilder hubTitle = new StringBuilder(); // for hub pag titles
            StringBuilder hubDetails = new StringBuilder(); // for hub page details

            StyleGroup CheckSetupStyleEvnt = null;
            StyleGroup CheckSetupStyle = null;
            StyleGroup checkHubTitle = null;
            StyleGroup checkHubDetails = null;
            Stack<StyleGroup> _styleGroups = new Stack<StyleGroup>();

            string currentpassageName = this.Story.CurrentPassage.Name.ToString();
            bool isTitle = false;
            bool isSetup = false;
            bool isSetupEvnt = false;
            bool isHubTitle = false;
            bool isHubDetails = false;
            int lineBreaks = 0;
            for (int i = 0; i < Story.Output.Count; i++)
            {
                StoryOutput output = Story.Output[i];
                if (this.StyleSheet != null)
                {
                    // check title or not
                    if (isTitle)
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, builder);
                            isTitle = false;
                        }
                    }
                    // for setup text
                    else if (isSetup)
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            if (CheckSetupStyle == _styleGroups.Peek())
                            {
                                isSetup = false;
                            }
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, setupString);
                        }
                    }
                    // for setup event text
                    else if (isSetupEvnt)
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            if (CheckSetupStyleEvnt == _styleGroups.Peek())
                            {
                                isSetupEvnt = false;
                            }
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, setupStringEvnt);
                        }
                    }
                    // hub page title
                    else if (isHubTitle)
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            if (checkHubTitle == _styleGroups.Peek())
                            {
                                isHubTitle = false;
                            }
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, hubTitle);
                        }
                    }
                    else if (isHubDetails)
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            if (checkHubDetails == _styleGroups.Peek())
                            {
                                isHubDetails = false;
                            }
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, hubDetails);
                        }
                        if (!isHubDetails)
                        {
                            ViewGeneration.instance.hubPageData.Add(new HubData(hubTitle.ToString(), hubDetails.ToString()));
                            //Debug.Log("Hub Title : " + hubTitle.ToString());
                            hubTitle.Clear();
                            hubDetails.Clear();
                        }
                    }
                    else
                    {
                        while (_styleGroups.Count > 0 && !output.BelongsToStyleGroup(_styleGroups.Peek()))
                        {
                            FormatStyle(_styleGroups.Pop().Style, StyleFormatType.Suffix, builder);
                        }
                    }
                }

                if (output is StoryText)
                {
                    //check title or not
                    if (isTitle)
                    {
                        if (this.StyleSheet != null)
                            titleString.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            titleString.Append(output.Text);
                    }
                    else if (isSetup) //for setup text
                    {
                        if (this.StyleSheet != null)
                            setupString.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            setupString.Append(output.Text);
                    }
                    else if (isSetupEvnt) //for setup event text
                    {
                        if (this.StyleSheet != null)
                            setupStringEvnt.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            setupStringEvnt.Append(output.Text);
                    }
                    else if (isHubTitle)
                    {
                        if (this.StyleSheet != null)
                            hubTitle.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            hubTitle.Append(output.Text);
                    }
                    else if (isHubDetails)
                    {
                        if (this.StyleSheet != null)
                            hubDetails.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            hubDetails.Append(output.Text);
                    }
                    else
                    {
                        if (this.StyleSheet != null)
                            builder.AppendFormat(Unescape(this.StyleSheet.Text), output.Text);
                        else
                            builder.Append(output.Text);
                    }

                }

                if (output is StoryLink link)
                {
                    if (PassageTracker.instance.genHubEPassageList.Contains(Story.CurrentPassage.Name)
                        || PassageTracker.instance.genHubMPassageList.Contains(Story.CurrentPassage.Name)
                        || PassageTracker.instance.genHubLPassageList.Contains(Story.CurrentPassage.Name))
                    {
                        if (this.ShowNamedLinks || !link.IsNamed)
                        {
                            if (isHubDetails)
                            {
                                hubDetails.AppendFormat(
                                        this.StyleSheet != null ? Unescape(this.styleSheetHub.Link) : TwineTMProStyleSheet.DefaultLink,
                                        TwineTMProLinkHandler.Escape(link.Name),
                                        link.Text);
                            }
                            else
                            {
                                builder.AppendFormat(
                                    this.styleSheetHub != null ? Unescape(this.styleSheetHub.Link) : TwineTMProStyleSheet.DefaultLink,
                                    TwineTMProLinkHandler.Escape(link.Name),
                                    link.Text);
                            }
                        }
                    }
                    else
                    {
                        if (this.ShowNamedLinks || !link.IsNamed)
                        {
                            builder.AppendFormat(
                                this.StyleSheet != null ? Unescape(this.StyleSheet.Link) : TwineTMProStyleSheet.DefaultLink,
                                TwineTMProLinkHandler.Escape(link.Name),
                                link.Text);
                        }
                    }
                }

                if (output is LineBreak)
                {
                    if (!CollapseLineBreaks || lineBreaks < 2)
                    {
                        if (isHubDetails)
                        {
                            if (isSetup)
                            {
                                setupString.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            else if (isSetupEvnt)
                            {
                                setupStringEvnt.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            else
                            {
                                hubDetails.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            lineBreaks++;
                        }
                        else
                        {
                            if (isSetup)
                            {
                                setupString.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            else if (isSetupEvnt)
                            {
                                setupStringEvnt.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            else
                            {
                                builder.Append(this.StyleSheet != null ? Unescape(this.StyleSheet.LineBreak) : TwineTMProStyleSheet.DefaultLineBreak);
                            }
                            lineBreaks++;
                        }
                    }
                }
                else
                    lineBreaks = 0;

                //chech prefix style
                if (this.StyleSheet != null && output is StyleGroup)
                {
                    var styleGroup = (StyleGroup)output;
                    string s = i + styleGroup.ToString();
                    //check title or not
                    if (s == "1(style-group:  bold='True')")
                    {
                        FormatStyle(styleGroup.Style, StyleFormatType.Prefix, builder);
                        isTitle = true;
                    }
                    else
                    {
                        //for setup text
                        if (isSetupEvnt)
                        {
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, setupStringEvnt);
                        }
                        else if (styleGroup.ToString() == "(style-group:  setupStyleEvnt='True')")
                        {
                            CheckSetupStyleEvnt = styleGroup;
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, setupStringEvnt);
                            isSetupEvnt = true;
                        }
                        else if (isSetup)
                        {
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, setupString);
                        }
                        else if (styleGroup.ToString() == "(style-group:  setupStyle='True')")
                        {
                            CheckSetupStyle = styleGroup;
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, setupString);
                            isSetup = true;
                        }
                        else if (isHubTitle)
                        {
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, hubTitle);
                        }
                        else if (styleGroup.ToString() == "(style-group:  hubTitle='True')")
                        {
                            checkHubTitle = styleGroup;
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, hubTitle);
                            isHubTitle = true;
                        }
                        else if (isHubDetails)
                        {
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, hubDetails);
                        }
                        else if (styleGroup.ToString() == "(style-group:  hubDetails='True')")
                        {
                            checkHubDetails = styleGroup;
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, hubDetails);
                            isHubDetails = true;
                        }
                        else
                        {
                            FormatStyle(styleGroup.Style, StyleFormatType.Prefix, builder);
                        }
                    }
                    _styleGroups.Push(styleGroup);
                }
            }
            if (titleString.ToString() == "A Time of War : A Memoir Across Three Generations" || titleString.ToString() == "Time Machine - Publication?" || titleString.ToString() == "\"April Fools Day\" - Journal Entry - 1882")
            {
                titleGeneration.text = "<size=45>" + titleString + "</size>".ToString();
            }
            else if (titleString.ToString().Contains(":")) //for generation instrodution
            {
                string title = titleString.ToString().Replace("<b>", "");
                title = title.Replace("</b>", "");
                string[] s = title.Split(':');
                doubleTitleString = "<size=45>" + s[1] + "</size>" + "\n<size=30>" + s[0] + "</size>".ToString();
                //ViewGenerationEnding.instance.SetBorder(true);
            }
            else if (titleString.ToString().Contains("-")) //for early/middle/late year
            {
                string title = titleString.ToString().Replace("<b>", "");
                title = title.Replace("</b>", "");
                string[] s = title.Split('-');
                doubleTitleString = "<size=45>" + s[0].Replace("Re emerges", "Re-emerges") + "</size>" + "\n<size=30>" + s[1] + "</size>".ToString();

            }
            if (titleString.ToString().Length > 50) //for the title
            {
                titleString.Append(builder);
                ViewGenerationEnding.instance.SetGenerationEndingTitle("");
                titleGeneration.text = "";
                TextUI.text = Regex.Replace(titleString.ToString(), @"\n{3,}", "\n\n");
                TextUIGeneration.SetText(titleString);
            }
            else
            {
                if (doubleTitleString != null)
                {
                    ViewGenerationEnding.instance.SetGenerationEndingTitle(doubleTitleString);
                    titleGeneration.text = doubleTitleString;
                    doubleTitleString = null;
                }
                else
                {
                    ViewLogBook.instance.SaveLogBookTitle(titleString.ToString());
                    if (titleString.ToString() == "Preparations" || titleString.ToString() == "Preparativos")
                    {
                        ViewGenerationEnding.instance.SetGenerationEndingTitle("<size=55>" + titleString + "</size>".ToString());
                        titleGeneration.text = "<size=55>" + titleString + "</size>".ToString();
                    }
                    else
                    {
                        ViewGenerationEnding.instance.SetGenerationEndingTitle("<size=45>" + titleString + "</size>".ToString());
                        titleGeneration.text = "<size=45>" + titleString + "</size>".ToString();
                    }
                    //ViewGenerationEnding.instance.SetBorder(false);
                }

                TextUI.text = Regex.Replace(builder.ToString(), @"\n{3,}", "\n\n").Replace("<b></b>\n", "").Replace("<b>\n</b>", "").Trim();
                //TextUIGeneration.text = Regex.Replace(builder.ToString(), @"\n{3,}", "\n");
            }

            if (ViewGeneration.instance.hubPageData.Count > 0)
                ViewGeneration.instance.OnFillData();

            //for the setup text
            if (setupString.ToString().Length > 1 && previousPassageName != currentpassageName)
            {
                if (currentpassageName != "Barventures")
                    previousPassageName = currentpassageName;
                else
                {
                    if (tempSetupText == setupString.ToString().Replace("Special Setup", "").Replace("<size=30><b></b>", "").Replace("<size=30>", "").Trim())
                    {
                        goto down;
                    }
                }

                string s = setupString.ToString().Replace("SETUP", "").Replace("<size=30><b></b>", "").Trim();
                tempSetupText = s;
                ViewItemObtainHUB.instance.SetupItemObtain(setupText[PlayerPrefs.GetInt("language", 0)], s, 1f);
            down:;
            }
            if (setupStringEvnt.ToString().Length > 1)
            {
                previousPassageName = currentpassageName;

                string s = setupStringEvnt.ToString().Replace("SETUP", "").Replace("<size=30><b></b>", "").Replace("<size=30>", "").Trim();
                ViewItemObtain.instance.ShowItemObtsInPopup(setupText[PlayerPrefs.GetInt("language", 0)], s);
            }
            TextUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }

        void FormatStyle(Style style, StyleFormatType formatType, StringBuilder builder)
        {
            if (this.StyleSheet == null)
                return;

            foreach (var entry in style)
            {
                TwineTMProStyle styleFormat = StyleSheet.Styles
                    .Where((System.Func<TwineTMProStyle, bool>)(f => (bool)(f.MatchingKeys.Contains(entry.Key) &&
                        (
                            string.IsNullOrEmpty(f.MatchingValuesRegex) ||
                            CheckRegex(f, entry.Value)
                        )))).FirstOrDefault();

                if (styleFormat == null)
                    continue;

                string format = formatType == StyleFormatType.Prefix ?
                    styleFormat.Prefix :
                    styleFormat.Suffix;

                if (format == null)
                    continue;

                builder.AppendFormat(Unescape(format), entry.Value);
            }
        }

        private static bool CheckRegex(TwineTMProStyle f, object value) => Regex.IsMatch(System.Convert.ToString(value), f.MatchingValuesRegex);

        enum StyleFormatType
        {
            Prefix,
            Suffix
        }

        string Unescape(string format) => Regex.Unescape(format);

        public void DoLink(string linkName) => this.Story.DoLink(linkName);
    }
}


[System.Serializable]
public class LanguageWiseStory
{
    public Story TheCostOfDisease;
    public Story FearOfUnknown;
    public Story ATimeOfWar;

    public void OnDisableStory()
    {
        TheCostOfDisease.enabled = false;
        FearOfUnknown.enabled = false;
        ATimeOfWar.enabled = false;
    }
}
