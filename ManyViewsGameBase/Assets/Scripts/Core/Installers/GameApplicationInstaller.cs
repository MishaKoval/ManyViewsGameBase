using Core.ApplicationControllers;

namespace Core.Installers
{
    class GameApplicationInstaller : ApplicationInstaller
    {
        protected override void BindClasses()
        {
            Container.BindInterfacesTo<ManuViewGameBaseApplicationController>().AsSingle();
        }
    }
}