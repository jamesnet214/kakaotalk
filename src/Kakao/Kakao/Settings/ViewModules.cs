﻿using Jamesnet.Wpf.Controls;
using Kakao.Core.Names;
using Kakao.Friends.UI.Views;
using Kakao.Login.UI.Views;
using Kakao.Main.UI.Views;
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
            containerRegistry.RegisterSingleton<IViewable, LoginContent>(ContentNameManager.Login);
            containerRegistry.RegisterSingleton<IViewable, MainContent>(ContentNameManager.Main);
            containerRegistry.RegisterSingleton<IViewable, FriendsContent>(ContentNameManager.Friends);
        }
    }
}
