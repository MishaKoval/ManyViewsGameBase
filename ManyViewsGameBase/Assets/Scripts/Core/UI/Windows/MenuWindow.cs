namespace Core.UI.Windows
{
    public class MenuWindow : WindowWithIntent<MenuWindowIntent>
    {
    }

    public class MenuWindowIntent : EmptyIntent
    {
        public MenuWindowIntent()
        {
        }
    }
}