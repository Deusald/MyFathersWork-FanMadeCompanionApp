using UnityEngine;

namespace Febucci.UI.Examples
{
    [AddComponentMenu("")]
    public class DefaultEffectsExample : MonoBehaviour
    {
        public TextAnimatorPlayer textAnimatorPlayer;

        private void Awake()
        {
            UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
        }

        private void Start()
        {
            const char quote = '"';
            //builds the text with all the default tags
            string builtText = "<b>You can add effects by using <color=red>rich text tags</color>.</b>" +
                $"\nExample: writing {quote}<noparse><shake>I'm cold</shake></noparse>{quote} will result in {quote}<shake>I'm cold</shake>{quote}." +
                $"\n\n Effects that animate through time are called {quote}<color=red>Behaviors</color>{quote}, and the default tags are: ";
            for (int i = 0; i < TAnimTags.defaultBehaviors.Length; i++)
            {
                builtText += EffectsTesting.AddEffect(TAnimTags.defaultBehaviors[i]);
            }

            builtText += $"\n\n<b>Effects that animate letters while they appear on screen are called {quote}<color=red>Appearances</color>{quote} and the default tags are</b>: ";

            for (int i = 0; i < TAnimTags.defaultAppearances.Length; i++)
            {
                builtText += EffectsTesting.AddAppearanceEffect(TAnimTags.defaultAppearances[i]);
            }

            //shows the text dynamically (typewriter like)
            textAnimatorPlayer.ShowText(builtText);

        }
    }

}