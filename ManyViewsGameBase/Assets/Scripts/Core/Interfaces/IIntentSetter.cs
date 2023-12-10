using Core.UI.Intents;

namespace Core.Interfaces
{
    public interface IIntentSetter<TIntent> where TIntent : EmptyIntent
    {
        TIntent Intent { get; }
        void SetIntent(TIntent intent);
    }
}