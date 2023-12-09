using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows
{
    public class SecondaryWindow<T> : WindowWithIntent<T> where T : SecondaryWindowsIntent 
    {
        [SerializeField] protected Button backBtn;

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
            WindowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent());
        }
    }

    public class SecondaryWindowsIntent : EmptyIntent
    {
    }
}