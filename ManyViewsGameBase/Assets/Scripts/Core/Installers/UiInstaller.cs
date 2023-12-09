using Core.UI;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private Transform uiRoot;
        [SerializeField] private WindowBase[] registeredWindows;
    
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WindowsController>().AsSingle().WithArguments(uiRoot, registeredWindows);
        }
    }
}