using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using UnityEngine;

namespace Core.UI
{
    public class WindowsController : IWindowsController, IWindowsContainer
    {
        private readonly Transform uiRoot;
        private readonly Dictionary<Type, WindowBase> registeredWindows;
        private readonly List<WindowBase> openedWindows = new List<WindowBase>();
        private readonly Dictionary<Type, WindowBase> cachedWindows = new Dictionary<Type, WindowBase>();

        public IList<WindowBase> OpenedWindows => openedWindows;
        public WindowBase LastClosedWindow { get; private set; }

        public event Action<WindowBase> WindowOpened;

        public WindowsController(Transform uiRoot, WindowBase[] registeredWindows)
        {
            this.uiRoot = uiRoot;

            this.registeredWindows = new Dictionary<Type, WindowBase>(registeredWindows.Length);
            foreach (var window in registeredWindows)
            {
                RegisterWindow(window);
            }
        }

        public void RegisterWindow(WindowBase window)
        {
            var windowType = window.GetType();
            registeredWindows.TryAdd(windowType, window);
        }

        public TWindow Open<TWindow, TIntent>(TIntent intent) where TWindow : WindowWithIntent<TIntent> where TIntent : EmptyIntent
        {
            var window = GetWindow<TWindow>();
            ((IIntentSetter<TIntent>)window).SetIntent(intent);
            OpenWindow(window);
            return (TWindow)window;
        }

        public TWindow Open<TWindow>() where TWindow : WindowBase
        {
            var window = GetWindow<TWindow>();
            OpenWindow(window);
            return (TWindow)window;
        }

        private void OpenWindow(WindowBase window)
        {
            var lastOpenedWindow = openedWindows.LastOrDefault();
            if (lastOpenedWindow != null)
            {
                lastOpenedWindow.Suspend();
            }
            
            if (openedWindows.Contains(window))
            {
                window.Push();
                window.Resume();
            }
            else
            {
                window.Open();
                openedWindows.Add(window);
            }
            
            WindowOpened?.Invoke(window);
        }

        private WindowBase GetWindow<TWindow>() where TWindow : WindowBase
        {
            var windowType = typeof(TWindow);
            if (registeredWindows.TryGetValue(windowType, out var windowBase))
            {
                if (cachedWindows.TryGetValue(windowType, out var cachedWindow))
                {
                    return cachedWindow;
                }

                var window = UnityEngine.Object.Instantiate(windowBase, uiRoot);
                ((IWindowsControllerContainer)window).SetWindowsController(this);
                cachedWindows[windowType] = window;
                return window;
            }

            throw new Exception($"Window {windowType.Name} is not registered!");
        }

        public void OnCloseWindow(WindowBase window)
        {
            LastClosedWindow = window;
            
            if (openedWindows.Contains(window))
            {
                openedWindows.Remove(window);
            }

            var nextOpenedWindow = openedWindows.LastOrDefault();
            if (nextOpenedWindow != null)
            {
                nextOpenedWindow.Push();
                nextOpenedWindow.Resume();
            }

            var type = window.GetType();

            if (window.IsNeedCache || !cachedWindows.ContainsKey(type))
            {
                return;
            }
            
            cachedWindows.Remove(type);
            UnityEngine.Object.Destroy(window.gameObject, 1f);
        }
    }
}