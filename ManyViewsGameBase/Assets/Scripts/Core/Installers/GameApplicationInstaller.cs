using Core.ApplicationControllers;
using Core.UI.Windows;
using UnityEngine;

namespace Core.Installers
{
    class GameApplicationInstaller : ApplicationInstaller
    {
        [SerializeField] private TransitionAnimation transitionAnimation;
        
        protected override void BindClasses()
        {
            Container.BindInterfacesTo<ManyViewGameBaseApplicationController>().AsSingle().WithArguments(transitionAnimation);
        }
    }
}