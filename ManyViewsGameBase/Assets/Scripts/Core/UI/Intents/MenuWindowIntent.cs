using Core.Utils;

namespace Core.UI.Intents
{
    public class MenuWindowIntent : EmptyIntent
    {
        public TransitionAnimation TransitionAnimation { get; }
        public SoundsManager SoundsManager { get; }
        public PlayerPreferences PlayerPreferences { get; }

        public MenuWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences)
        {
            TransitionAnimation = transitionAnimation;
            SoundsManager = soundsManager;
            PlayerPreferences = playerPreferences;
        }
    }
}