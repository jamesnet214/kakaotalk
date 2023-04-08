using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kakao.Login.UI.Units
{
    public class KakaoWebView : WebView2
    {
        public static readonly DependencyProperty LoginCompletedCommandProperty =
        DependencyProperty.Register("LoginCompletedCommand", typeof(ICommand), typeof(KakaoWebView), new PropertyMetadata(null));

        public ICommand LoginCompletedCommand
        {
            get => (ICommand)GetValue(LoginCompletedCommandProperty);
            set => SetValue(LoginCompletedCommandProperty, value);
        }

        public KakaoWebView()
        {
            WebMessageReceived += KakaoWebView_WebMessageReceived;
        }

        private void KakaoWebView_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            string userEmail = e.TryGetWebMessageAsString();
            LoginCompletedCommand.Execute(userEmail);
        }
    }
}
