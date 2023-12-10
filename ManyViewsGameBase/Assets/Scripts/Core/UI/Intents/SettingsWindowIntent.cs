using Core.UI.Windows.Base;
using Core.Utils;

namespace Core.UI.Intents
{
    public class SettingsWindowIntent : SecondaryWindowsIntent
    {
        public PlayerPreferences PlayerPreferences { get; }

        public SettingsWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences,EmptyIntent emptyIntent) : base(transitionAnimation,soundsManager,emptyIntent)
        {
            PlayerPreferences = playerPreferences;
        }
    }
}