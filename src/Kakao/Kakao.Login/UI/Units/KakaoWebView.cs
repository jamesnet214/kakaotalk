using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebView2 = Microsoft.Web.WebView2.Wpf.WebView2;

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

            // WebView2 컨트롤을 초기화하고 비공개 모드로 설정합니다.
            CoreWebView2InitializationCompleted += (sender, e) =>
            {
                // 비공개 모드로 설정합니다.
                CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
                CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                CoreWebView2.Settings.AreDevToolsEnabled = false;
                CoreWebView2.Settings.AreHostObjectsAllowed = false;
                CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
                CoreWebView2.Settings.IsStatusBarEnabled = false;
                CoreWebView2.Settings.IsWebMessageEnabled = false;
                CoreWebView2.Settings.IsZoomControlEnabled = false;
                WebMessageReceived += WebView_WebMessageReceived;
                // 초기화 완료 후 로드할 페이지를 지정합니다.
                CoreWebView2.Navigate("https://localhost:7287/Identity/Account/Login?returnUrl=%2Fauthentication%2Flogin");
            };

            // WebView2 컨트롤을 초기화합니다.
            EnsureCoreWebView2Async();
            
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string userEmail = e.TryGetWebMessageAsString();
            LoginCompletedCommand.Execute(userEmail);
        }
    }
}
