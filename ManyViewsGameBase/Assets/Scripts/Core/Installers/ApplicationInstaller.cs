using Core.ApplicationControllers;
using Zenject;

namespace Core.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindClasses();
        }
        
        protected virtual void BindClasses()
        {
            Container.BindInterfacesAndSelfTo<BaseApplicationController>().AsSingle();
        }
    }
}