using UnityEngine;

namespace Febucci.UI.Examples
{
    //Prevents this example to show up in the inspector
    [AddComponentMenu("")]
    public class EventExample : MonoBehaviour
    {
        public TextAnimatorPlayer textAnimatorPlayer;


        public Camera cam;


        int lastBGIndex;
        public Color[] bgColors;

        private void Awake()
        {
            UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
            textAnimatorPlayer.textAnimator.onEvent += OnEvent;
        }

        void OnEvent(string message)
        {
            switch (message)
            {
                case "bg":
                    cam.backgroundColor = bgColors[lastBGIndex];
                    lastBGIndex++;
                    if (lastBGIndex >= bgColors.Length)
                    {
                        lastBGIndex = 0;
                    }
                    break;
            }
        }
    }
}