using Core.UI.Windows.Base;
using Core.Utils;

namespace Core.UI.Intents
{
    public class LevelsWindowIntent : SecondaryWindowsIntent
    {
        public LevelsWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
        }
    }
}