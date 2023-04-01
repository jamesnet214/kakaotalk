using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Talk.UI.Views
{
    public class TalkWindow : JamesWindow
    {
        public TalkWindow()
        {
            Closing += TalkWindow_Closing;
        }

        private void TalkWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (window.Content == null)
            //{
            //    window.Title = data.Name;
            //    window.Width = 360;
            //    window.Height = 500;
            //    window.Content = new TalkContent();
            //}
            //window.Show();
        }
    }
}
