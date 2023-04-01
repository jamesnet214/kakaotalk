using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kakao.Core.Talkings
{
    public class TalkWindowManager
    {
        public event EventHandler WindowCountChanged;
        private readonly Dictionary<int, JamesWindow> _windows;

        public TalkWindowManager()
        {
            _windows = new Dictionary<int, JamesWindow>();
        }

        public void UnregisterWindow(int key)
        {
            if (_windows.ContainsKey(key))
            {
                _windows.Remove(key);
                OnWindowCountChanged();
            }
        }

        public JamesWindow GetWindow(int key)
        {
            return _windows.ContainsKey(key) ? _windows[key] : null;
        }

        public List<KeyValuePair<int, JamesWindow>> GetAllWindows()
        {
            return _windows.ToList();
        }

        public T ResolveWindow<T>(int key) where T : JamesWindow, new()
        {
            if (_windows.ContainsKey(key))
            {
                return (T)_windows[key];
            }
            else
            {
                try
                {
                    var window = new T();
                    window.Closed += (sender, e) => UnregisterWindow(key);
                    _windows.Add(key, window);
                    OnWindowCountChanged();
                    return window;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Unable to resolve the window of type {typeof(T).FullName}.", ex);
                }
            }
        }

        protected virtual void OnWindowCountChanged()
        {
            WindowCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public void CloseAll()
        {
            foreach(KeyValuePair<int, JamesWindow> kvp in _windows) 
            {
                kvp.Value.Close();
            }
        }
    }
}
