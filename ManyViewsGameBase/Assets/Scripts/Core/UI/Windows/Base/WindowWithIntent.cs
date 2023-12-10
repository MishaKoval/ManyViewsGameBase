using Core.Interfaces;
using Core.UI.Intents;

namespace Core.UI.Windows.Base
{
    public abstract class WindowWithIntent<TIntent> : WindowBase, IIntentSetter<TIntent> where TIntent : EmptyIntent
    {
        public TIntent Intent { get; private set; }

        void IIntentSetter<TIntent>.SetIntent(TIntent intent)
        {
            Intent = intent;
        }
    }
}