using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cradle;
using Cradle.StoryFormats.Harlowe;

namespace Cradle.Players
{
	[ExecuteInEditMode]
	public class TwineTextPlayer : MonoBehaviour
	{
		public static TwineTextPlayer instane;
		public Story Story;
		public RectTransform Container;
		public Button LinkTemplate;
		public TextMeshProUGUI WordTemplate;
		public RectTransform LineBreakTemplate;
		public bool StartStory = true;
		public bool AutoDisplay = true;
		public bool ShowNamedLinks = true;
		string Passage_Text = "";
		public List<string> PassageTextList = new List<string>();
		static Regex rx_splitText = new Regex(@"(\s+|[^\s]+)");

        private void Awake()
        {
			instane = this;
		}
        void Start()
		{
			if (!Application.isPlaying)
				return;

			LinkTemplate.gameObject.SetActive(false);
			((RectTransform)LinkTemplate.transform).SetParent(null);
			LinkTemplate.transform.hideFlags = HideFlags.HideInHierarchy;

			WordTemplate.gameObject.SetActive(false);
			WordTemplate.rectTransform.SetParent(null);
			WordTemplate.rectTransform.hideFlags = HideFlags.HideInHierarchy;

			LineBreakTemplate.gameObject.SetActive(false);
			LineBreakTemplate.SetParent(null);
			LineBreakTemplate.hideFlags = HideFlags.HideInHierarchy;

			if (this.Story == null)
				this.Story = this.GetComponent<Story>();
			if (this.Story == null)
			{
				Debug.LogError("Text player does not have a story to play. Add a story script to the text player game object, or assign the Story variable of the text player.");
				return;
			}

			this.Story.OnPassageEnter += Story_OnPassageEnter;
			this.Story.OnOutput += Story_OnOutput;
			this.Story.OnOutputRemoved += Story_OnOutputRemoved;

			//if (StartStory)
			//	this.Story.Begin();
		}

		void OnDestroy()
		{
			if (!Application.isPlaying)
				return;

			if (this.Story != null)
			{
				this.Story.OnPassageEnter -= Story_OnPassageEnter;
				this.Story.OnOutput -= Story_OnOutput;
			}
		}

		// .....................
		// Clicks

#if UNITY_EDITOR
		void Update()
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

#region Public Methods
        public void Clear()
		{
			for (int i = 0; i < Container.childCount; i++)
				GameObject.Destroy(Container.GetChild(i).gameObject);
			Container.DetachChildren();
		}

		void Story_OnPassageEnter(StoryPassage passage)
		{
            PassageTextList.Clear();
            //PassageTextList.Add(Story.CurrentPassage.Name);

            Clear();
            ResetContentScrollRect();
        }
        float _y = 0;
		float _yOffset = 100;
		/// <summary>
		/// reset scroll view to vector 0 for top view.
		/// </summary>
		public void ResetContentScrollRect()
		{
            Container.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Container.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            Invoke("RestHeightAfterText", 0.1f);
        }
		/// <summary>
		/// added offset to bottom of the scrollview  
		/// </summary>
        public void RestHeightAfterText()
        {
            _y = Container.GetComponent<RectTransform>().sizeDelta.y + _yOffset;
            Container.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            Container.GetComponent<RectTransform>().sizeDelta = new Vector2(0, _y);
        }
		
		void Story_OnOutput(StoryOutput output)
		{
			if (!this.AutoDisplay)
				return;

			DisplayOutput(output);
			
		}

		void Story_OnOutputRemoved(StoryOutput outputThatWasRemoved)
		{
			// Remove all elements related to this output
			foreach (var elem in Container.GetComponentsInChildren<TwineTextElement>()
				.Where(e => e.SourceOutput == outputThatWasRemoved))
			{
				elem.transform.SetParent(null);
				GameObject.Destroy(elem.gameObject);
			}
		}
       
        public void DisplayOutput(StoryOutput output)
		{
			Passage_Text = "";
            // Deternine where to place this output in the hierarchy - right after the last UI element associated with the previous output, if exists
            TwineTextElement last = Container.GetComponentsInChildren<TwineTextElement>()
				.Where(elem => elem.SourceOutput.Index < output.Index)
				.OrderBy(elem => elem.SourceOutput.Index)
				.LastOrDefault();
			int uiInsertIndex = last == null ? -1 : last.transform.GetSiblingIndex() + 1;

			// Temporary hack to allow other scripts to change the templates based on the output's Style property
			SendMessage("Twine_BeforeDisplayOutput", output, SendMessageOptions.DontRequireReceiver);
			//Debug.Log("story style"+output.)

			if (output is StoryText)
			{

					var text = (StoryText)output;
				 
				if (!string.IsNullOrEmpty(text.Text))
				{
					foreach (Match m in rx_splitText.Matches(text.Text))
					{
						string word = m.Value;
						TextMeshProUGUI uiWord = (TextMeshProUGUI)Instantiate(WordTemplate);
						uiWord.gameObject.SetActive(true);
						uiWord.text = word;
						uiWord.name = word;
						Passage_Text = Passage_Text + word;
						AddToUI(uiWord.rectTransform, output, uiInsertIndex);
						if (uiInsertIndex >= 0)
							uiInsertIndex++;
					}
						 
				}
				//            Debug.Log("abc---------" + abc);
				if (Passage_Text.ToCharArray().Length > 1)
				{
					PassageTextList.Add(Passage_Text);
				}
			}
			else if (output is StoryLink)
			{
				var link = (StoryLink)output;
				if (!ShowNamedLinks && link.IsNamed)
					return;

				Button uiLink = (Button)Instantiate(LinkTemplate);
				uiLink.gameObject.SetActive(true);
				uiLink.name = "[[" + link.Text + "]]";

				TextMeshProUGUI uiLinkText = uiLink.GetComponentInChildren<TextMeshProUGUI>();
				uiLinkText.text = link.Text;
				uiLink.onClick.AddListener(() =>
				{
					this.Story.DoLink(link);
                    SoundManager.Instance.PlayAudioSource(SoundManager.Instance.ClickSource);  // normal click sound for all buttons
				});
				SetCustomClickSound(link.Text, uiLink); // spacial sound button sound for bank and mayor
				 
                //var br1 = (RectTransform)Instantiate(LineBreakTemplate);
                //br1.gameObject.SetActive(true);
                //br1.gameObject.name = "(br)";
                //AddToUI(br1, output, uiInsertIndex);
                //uiInsertIndex = uiInsertIndex + 1;
                AddToUI((RectTransform)uiLink.transform, output, uiInsertIndex);
                var br2 = (RectTransform)Instantiate(LineBreakTemplate);
                br2.gameObject.SetActive(true);
                br2.gameObject.name = "(br)";
                uiInsertIndex = uiInsertIndex + 1;
                AddToUI(br2, output, uiInsertIndex);

            }
			else if (output is LineBreak)
			{
				var br = (RectTransform)Instantiate(LineBreakTemplate);
				br.gameObject.SetActive(true);
				br.gameObject.name = "(br)";
				AddToUI(br, output, uiInsertIndex);
			}
			else if (output is StyleGroup)
			{
				// Add an empty indicator to later positioning
				var groupMarker = new GameObject();
				groupMarker.name = output.ToString();
				AddToUI(groupMarker.AddComponent<RectTransform>(), output, uiInsertIndex);
			}
			 
			
		}

		void AddToUI(RectTransform rect, StoryOutput output, int index)
		{
			rect.SetParent(Container);
			if (index >= 0)
				rect.SetSiblingIndex(index);

			var elem = rect.gameObject.AddComponent<TwineTextElement>();
			elem.SourceOutput = output;
		}

		public void SetCustomClickSound(string text, Button uiLink)
		{
			if (text != null && text != "")
			{
				if (text.Contains("bank") || text.Contains("library")|| text.Contains("Bank") || text.Contains("Library"))
				{
					uiLink.onClick.AddListener(() =>
					{
						SoundManager.Instance.ClickSource.volume = 0;
						Invoke("ClickSoundSourceEnable", 2f);
						SoundManager.Instance.PlayAudioSource(SoundManager.Instance.BankLibrarySource);
					});
				}
				else  
				{
					if (GLOBALS.nameA != null && GLOBALS.nameA != "")
					{
						if (text.Contains(GLOBALS.nameA)){
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						} 
					}

					if (GLOBALS.nameB != null && GLOBALS.nameB != "")
					{
						if (text.Contains(GLOBALS.nameB))
						{
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						}
					}
					if (GLOBALS.nameB != null && GLOBALS.nameB != "")
					{
						if (text.Contains(GLOBALS.nameB))
						{
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						}
					}
					if (GLOBALS.nameC != null && GLOBALS.nameC != "")
					{
						if (text.Contains(GLOBALS.nameC))
						{
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						}
					}
					if (GLOBALS.nameD != null && GLOBALS.nameD != "")
					{
						if (text.Contains(GLOBALS.nameD))
						{
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						}
					}
					if (GLOBALS.nameE != null && GLOBALS.nameE != "")
					{
						if (text.Contains(GLOBALS.nameE))
						{
							uiLink.onClick.AddListener(() =>
							{
								SoundManager.Instance.ClickSource.volume = 0;
								Invoke("ClickSoundSourceEnable", 2f);
								SoundManager.Instance.PlayAudioSource(SoundManager.Instance.MayorSource);
							});

						}
					}

					
				}
			}

		}
		public void ClickSoundSourceEnable()
		{
			SoundManager.Instance.ClickSource.volume = 1;
		}
	}
    #endregion
}