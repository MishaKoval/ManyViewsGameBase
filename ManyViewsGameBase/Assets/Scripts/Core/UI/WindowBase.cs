using System.Threading.Tasks;
using Core.Interfaces;
using UnityEngine;

namespace Core.UI
{
    public abstract class WindowBase : MonoBehaviour, IWindowsControllerContainer
    {
        [SerializeField] protected GameObject content;
        [SerializeField] private bool isNeedCache = true;
        
        protected bool closeResult = false;
        private bool isOpened;
        private TaskCompletionSource<bool> openTaskSource;
        
        public Task<bool> CloseTask => openTaskSource?.Task ?? Task.FromResult(closeResult);
        public bool IsNeedCache => isNeedCache;
        public IWindowsController WindowsController { get; private set; }

        

        public async void Open()
        {
            if (isOpened)
            {
                return;
            }
            
            OnOpening();
            await AnimateOpening();
            OpenInternal();
            OnOpened();
        }
        
        public async void Close()
        {
            if(!isOpened)
            {
                return;
            }
            
            OnClosing();
            await AnimateClosing();
            CloseInternal();
            OnClosed();
        }
        
        public void Push()
        {
            transform.SetAsLastSibling();
        }
        
        public virtual void Suspend()
        {
        }

        public virtual void Resume()
        {
        }
        
        void IWindowsControllerContainer.SetWindowsController(IWindowsController windowsController)
        {
            WindowsController = windowsController;
        }
        
        protected virtual void OnOpening() { }
        protected virtual void OnClosing() { }
        protected virtual void OnOpened() { }
        protected virtual void OnClosed() { }
        protected virtual Task AnimateOpening() => Task.CompletedTask;
        protected virtual Task AnimateClosing() => Task.CompletedTask;
        
        private void OpenInternal()
        {
            content.SetActive(true);
            openTaskSource = new TaskCompletionSource<bool>();
            isOpened = true;
        }
        
        private void CloseInternal()
        {
            content.SetActive(false);
            isOpened = false;
            ((IWindowsContainer)WindowsController).OnCloseWindow(this);
            openTaskSource.SetResult(closeResult);
        }
    }
}