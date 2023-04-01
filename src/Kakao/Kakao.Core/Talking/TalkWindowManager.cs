using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Talking
{
    public class TalkWindowManager
    {
        private Dictionary<int, JamesWindow> _windows;
        public event EventHandler WindowCountChanged;

        public TalkWindowManager()
        {
            _windows = new();
        }

        public List<KeyValuePair<int, JamesWindow>> GetAllWindows()
        {
            return _windows.ToList();
        }

        public T ResolveWindow<T>(int id) where T : JamesWindow, new()
        {
            if (_windows.ContainsKey(id))
            {
                return (T)_windows[id];
            }
            else
            {
                var window = new T();
                window.Closed += (s, e) => UnregisterWindow(id);
                _windows.Add(id, window);

                WindowCountChanged?.Invoke(this, EventArgs.Empty);

                return window;
            }
        }

        private void UnregisterWindow(int id)
        {
            _windows.Remove(id);
            WindowCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
