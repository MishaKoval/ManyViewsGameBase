namespace Core.UI.Windows
{
    public class SettingsWindow : WindowWithIntent<SettingsWindowIntent>
    {
    }

    public class SettingsWindowIntent : EmptyIntent
    {
        public SettingsWindowIntent()
        {
        }
    }
}