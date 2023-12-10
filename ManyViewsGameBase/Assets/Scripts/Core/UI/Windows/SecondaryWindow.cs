using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows
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
            return Intent.transitionAnimation.WaitVignetteChange();
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
            Close();
            WindowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent(Intent.transitionAnimation));
        }
    }

    public class SecondaryWindowsIntent : EmptyIntent
    {
        public readonly TransitionAnimation transitionAnimation;
        
        public SecondaryWindowsIntent(TransitionAnimation transitionAnimation)
        {
            this.transitionAnimation = transitionAnimation;
        }
    }
}