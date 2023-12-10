using Core.ApplicationControllers;
using Core.Utils;

namespace Core.Installers
{
    class GameApplicationInstaller : ApplicationInstaller
    {
        protected override void BindClasses()
        {
            Container.Bind<PlayerPreferences>().AsSingle();
            Container.Bind<WalletController>().AsSingle();
            Container.Bind<DaysStreak>().AsSingle();
            Container.Bind<SoundsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TransitionAnimation>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ManyViewGameBaseApplicationController>().AsSingle();
        }
    }
}