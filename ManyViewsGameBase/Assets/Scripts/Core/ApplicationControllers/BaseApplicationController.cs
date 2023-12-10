using Zenject;

namespace Core.ApplicationControllers
{
    public class BaseApplicationController : IInitializable
    {
        protected BaseApplicationController()
        {
            
        }
        
        public void Initialize()
        {
            OnInitialize();
        }
        
        protected virtual void OnInitialize()
        {
        }
    }
}