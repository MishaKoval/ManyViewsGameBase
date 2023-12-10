using System.Threading.Tasks;
using Core.UI.Intents;
using Core.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows.Base
{
    public class SecondaryWindow<T> : WindowWithIntent<T> where T : SecondaryWindowsIntent 
    {
        [SerializeField] protected Button backBtn;

        protected override Task AnimateClosing()
        {
            return Task.CompletedTask;
        }

        protected override Task AnimateOpening()
        {
            return Intent.TransitionAnimation.WaitVignetteChange();
        }

        protected override void OnOpening()
        {
            backBtn.onClick.AddListener(BackToMenu);
        }

        protected override void OnClosing()
        {
            backBtn.onClick.RemoveListener(BackToMenu);
        }

        private void BackToMenu()
        {
            Intent.SoundsManager.PlayButtonClickSound();
            Close();
            WindowsController.Open<MenuWindow, MenuWindowIntent>((MenuWindowIntent)Intent.ParentIntent);
        }
    }

    public class SecondaryWindowsIntent : EmptyIntent
    {
        public TransitionAnimation TransitionAnimation { get; }
        public SoundsManager SoundsManager { get; }
        public EmptyIntent ParentIntent { get; }

        protected SecondaryWindowsIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent parentIntent)
        {
            TransitionAnimation = transitionAnimation;
            SoundsManager = soundsManager;
            ParentIntent = parentIntent;
        }
    }
}