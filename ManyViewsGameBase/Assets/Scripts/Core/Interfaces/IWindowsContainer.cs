using System.Collections.Generic;
using Core.UI.Windows.Base;

namespace Core.Interfaces
{
    public interface IWindowsContainer
    {
        IList<WindowBase> OpenedWindows { get; }
        void OnCloseWindow(WindowBase window);
    }
}