using Core.Interfaces;
using Core.UI.Windows;

namespace Core.ApplicationControllers
{
    public class ManuViewGameBaseApplicationController : BaseApplicationController
    {
        private IWindowsController WindowsController { get; }
        
        public ManuViewGameBaseApplicationController(IWindowsController windowsController)
        {
            WindowsController = windowsController;
        }

        protected override void OnInitialize()
        {
            WindowsController.Open<MenuWindow, MenuWindowIntent>(new MenuWindowIntent());
        }
    }
}