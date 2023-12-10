using Core.Interfaces;
using Core.UI;
using Core.UI.Windows;

namespace Core.ApplicationControllers
{
    public class ManyViewGameBaseApplicationController : BaseApplicationController
    {
        private readonly IWindowsController windowsController;
        private readonly TransitionAnimation transitionAnimation;
        private readonly SoundsManager soundsManager;
        private readonly PlayerPreferences playerPreferences;
        
        public ManyViewGameBaseApplicationController(IWindowsController windowsController,TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences)
        {
            this.windowsController = windowsController;
            this.transitionAnimation = transitionAnimation;
            this.soundsManager = soundsManager;
            this.playerPreferences = playerPreferences;
        }

        protected override void OnInitialize()
        {
            soundsManager.Init(playerPreferences.MusicEnabled,playerPreferences.MusicEnabled);
            windowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent(transitionAnimation,soundsManager,playerPreferences));
        }
    }
}