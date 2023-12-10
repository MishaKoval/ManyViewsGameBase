namespace Core.UI.Windows
{
    public class LevelsWindow: SecondaryWindow<LevelsWindowIntent>
    {
    }
    public class LevelsWindowIntent : SecondaryWindowsIntent
    {
        public LevelsWindowIntent(TransitionAnimation transitionAnimation) : base(transitionAnimation)
        {
        }
    }
}