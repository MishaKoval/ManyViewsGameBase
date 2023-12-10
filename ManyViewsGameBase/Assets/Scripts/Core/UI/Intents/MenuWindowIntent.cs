using Core.Utils;

namespace Core.UI.Intents
{
    public class MenuWindowIntent : EmptyIntent
    {
        public TransitionAnimation TransitionAnimation { get; }
        public SoundsManager SoundsManager { get; }
        public PlayerPreferences PlayerPreferences { get; }
        public DaysStreak DaysStreak { get; }
        public WalletController WalletController { get; }

        public MenuWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences, DaysStreak daysStreak, WalletController walletController)
        {
            TransitionAnimation = transitionAnimation;
            SoundsManager = soundsManager;
            PlayerPreferences = playerPreferences;
            DaysStreak = daysStreak;
            this.WalletController = walletController;
        }
    }
}