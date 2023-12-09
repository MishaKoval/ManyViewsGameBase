using Zenject;

namespace Core.ApplicationControllers
{
    public class BaseApplicationController : IInitializable
    {
        public BaseApplicationController()
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