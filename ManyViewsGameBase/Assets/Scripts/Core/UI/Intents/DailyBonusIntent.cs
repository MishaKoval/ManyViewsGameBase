using Core.UI.Windows.Base;
using Core.Utils;

namespace Core.UI.Intents
{
    public class DailyBonusIntent : SecondaryWindowsIntent
    {
        public DailyBonusIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
        }
    }
}