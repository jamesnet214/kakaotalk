using Jamesnet.Wpf.Controls;
using Kakao.Core.Names;
using Kakao.Core.Talkings;
using Kakao.Forms.UI.Views;
using Kakao.Receiver;
using Prism.Ioc;
using System;
using System.Threading.Tasks;
using System.Windows;
using Unity.Lifetime;

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

            HubManager conn = HubManager.Create();

            conn.Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(1, 5) * 1000);
                await conn.Connection.StartAsync();
            };

            containerRegistry.RegisterInstance(conn);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object? sender, System.EventArgs e)
        {
            IViewable simulationWindow = Container.Resolve<IViewable>(ContentNameManager.Simulation);
            TalkWindowManager talkWindowManager = Container.Resolve<TalkWindowManager>();

            if (simulationWindow is Window window && window.ShowActivated)
            {
                window.Close();
            }

            talkWindowManager.CloseAll();

            Environment.Exit(0);
        }
    }
}
