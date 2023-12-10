namespace Core.UI.Windows
{
    public class DailyBonusWindow : SecondaryWindow<DailyBonusIntent>
    {
    }

    public class DailyBonusIntent : SecondaryWindowsIntent
    {
        public DailyBonusIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,EmptyIntent intent) : base(transitionAnimation,soundsManager,intent)
        {
        }
    }
}