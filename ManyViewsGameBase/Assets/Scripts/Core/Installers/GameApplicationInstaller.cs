using Core.ApplicationControllers;
using Core.UI;
using Core.UI.Windows;

namespace Core.Installers
{
    class GameApplicationInstaller : ApplicationInstaller
    {
        protected override void BindClasses()
        {
            Container.Bind<PlayerPreferences>().AsSingle();
            Container.Bind<SoundsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TransitionAnimation>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ManyViewGameBaseApplicationController>().AsSingle();
        }
    }
}