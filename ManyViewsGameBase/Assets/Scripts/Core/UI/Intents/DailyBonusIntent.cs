using Core.UI.Windows.Base;
using Core.Utils;

namespace Core.UI.Intents
{
    public class DailyBonusIntent : SecondaryWindowsIntent
    {
        public DaysStreak DaysStreak { get; }

        public DailyBonusIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,DaysStreak daysStreak,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
            DaysStreak = daysStreak;
        }
    }
}