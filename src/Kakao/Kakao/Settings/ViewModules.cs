using Jamesnet.Wpf.Controls;
using Kakao.Friends.UI.Views;
using Kakao.Login.UI.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Kakao.Settings
{
    internal class ViewModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, LoginContent>("LoginContent");
            containerRegistry.RegisterSingleton<IViewable, FriendsContent>("FriendsContent");
        }
    }
}
