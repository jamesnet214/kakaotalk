using Jamesnet.Wpf.Controls;
using Kakao.Core.Talking;
using Kakao.Forms.UI.Views;
using Prism.Ioc;
using System.Windows;

namespace Kakao
{
    internal class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new KakaoWindow();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);
            containerRegistry.RegisterInstance<TalkWindowManager>(new TalkWindowManager());
            containerRegistry.RegisterInstance<ChatStorage>(new ChatStorage());
        }
    }
}
