namespace Core.UI.Windows
{
    public class SettingsWindow : SecondaryWindow<SettingsWindowIntent>
    {
    }

    public class SettingsWindowIntent : SecondaryWindowsIntent
    {
        public SettingsWindowIntent(TransitionAnimation transitionAnimation) : base(transitionAnimation)
        {
        }
    }
}