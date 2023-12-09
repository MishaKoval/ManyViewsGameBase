using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows
{
    public class MenuWindow : WindowWithIntent<MenuWindowIntent>
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button dailyBonusButton;
        [SerializeField] private Button levelsButton;

        protected override void OnOpening()
        {
            settingsButton.onClick.AddListener(OpenSettingWindow);
            shopButton.onClick.AddListener(OpenShopWindow);
            dailyBonusButton.onClick.AddListener(OpenDailyBonusWindow);
            levelsButton.onClick.AddListener(OpenLevelsWindow);
        }

        protected override void OnClosing()
        {
            settingsButton.onClick.RemoveListener(OpenSettingWindow);
            shopButton.onClick.RemoveListener(OpenShopWindow);
            dailyBonusButton.onClick.RemoveListener(OpenDailyBonusWindow);
            levelsButton.onClick.RemoveListener(OpenLevelsWindow);
        }

        private async void OpenSettingWindow()
        {
            var settingsWindow = OpenWindow<SettingsWindow, SettingsWindowIntent>(new SettingsWindowIntent());
            await settingsWindow.CloseTask;
        }

        private async void OpenLevelsWindow()
        {
            var levelsWindow = OpenWindow<LevelsWindow, LevelsWindowIntent>(new LevelsWindowIntent());
            await levelsWindow.CloseTask;
        }

        private async void OpenShopWindow()
        {
            var shopWindow = OpenWindow<ShopWindow, ShopWindowIntent>(new ShopWindowIntent());
            await shopWindow.CloseTask;
        }

        private async void OpenDailyBonusWindow()
        {
            var dailyBonusWindow = OpenWindow<DailyBonusWindow, DailyBonusIntent>(new DailyBonusIntent());
            await dailyBonusWindow.CloseTask;
        }

        private T OpenWindow<T, T1>(T1 intent, bool shouldClose = false)
            where T : WindowWithIntent<T1> where T1 : EmptyIntent
        {
            if (shouldClose)
            {
                Close();
            }
            return WindowsController.Open<T, T1>(intent);
        }
    }

    public class MenuWindowIntent : EmptyIntent
    {
        public MenuWindowIntent()
        {
        }
    }
}