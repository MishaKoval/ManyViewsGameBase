using Core.Interfaces;
using Core.UI.Intents;
using Core.UI.Windows;
using Core.Utils;

namespace Core.ApplicationControllers
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ManyViewGameBaseApplicationController : BaseApplicationController
    {
        private readonly IWindowsController windowsController;
        private readonly TransitionAnimation transitionAnimation;
        private readonly SoundsManager soundsManager;
        private readonly PlayerPreferences playerPreferences;
        private readonly DaysStreak daysStreak;
        private readonly WalletController walletController;
        
        public ManyViewGameBaseApplicationController(IWindowsController windowsController,TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences,DaysStreak daysStreak, WalletController walletController)
        {
            this.windowsController = windowsController;
            this.transitionAnimation = transitionAnimation;
            this.soundsManager = soundsManager;
            this.playerPreferences = playerPreferences;
            this.daysStreak = daysStreak;
            this.walletController = walletController;
        }

        protected override void OnInitialize()
        {
            soundsManager.Init(playerPreferences.MusicEnabled,playerPreferences.MusicEnabled);
            windowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent(transitionAnimation,soundsManager,playerPreferences,daysStreak,walletController));
        }
    }
}