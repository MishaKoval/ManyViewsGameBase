using Core.Interfaces;
using Core.UI.Windows;

namespace Core.ApplicationControllers
{
    public class ManyViewGameBaseApplicationController : BaseApplicationController
    {
        private IWindowsController WindowsController { get; }

        private readonly TransitionAnimation transitionAnimation;
        
        public ManyViewGameBaseApplicationController(IWindowsController windowsController,TransitionAnimation transitionAnimation)
        {
            WindowsController = windowsController;
            this.transitionAnimation = transitionAnimation;
        }

        protected override void OnInitialize()
        {
            WindowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent(transitionAnimation));
        }
    }
}