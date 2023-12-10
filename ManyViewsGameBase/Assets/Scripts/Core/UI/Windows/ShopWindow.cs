namespace Core.UI.Windows
{
    public class ShopWindow : SecondaryWindow<ShopWindowIntent>
    {
    }

    public class ShopWindowIntent : SecondaryWindowsIntent
    {
        public ShopWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
        }
    }
}