using Core.UI.Windows.Base;
using Core.Utils;

namespace Core.UI.Intents
{
    public class ShopWindowIntent : SecondaryWindowsIntent
    {
        public ShopWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
        }
    }
}