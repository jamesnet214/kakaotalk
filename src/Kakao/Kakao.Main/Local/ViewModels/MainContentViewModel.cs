﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Kakao.Main.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        [ObservableProperty]
        private List<MenuModel> _menus;

        public MainContentViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;

            Menus = GetMenus();
        }

        private List<MenuModel> GetMenus()
        {
            List<MenuModel> source = new();
            source.Add(new MenuModel().DataGetn("Chats"));
            source.Add(new MenuModel().DataGetn("Friends"));
            source.Add(new MenuModel().DataGetn("More"));

            return source;
        }

        [RelayCommand]
        private void Chats()
        {
            IRegion contentRegion = _regionManager.Regions[RegionNameManager.ContentRegion];
            IViewable chatsContent = _containerProvider.Resolve<IViewable>(ContentNameManager.Chats);

            if (!contentRegion.Views.Contains(chatsContent))
            {
                contentRegion.Add(chatsContent);
            }
            contentRegion.Activate(chatsContent);
        }

        [RelayCommand]
        private void Friends()
        {
            IRegion contentRegion = _regionManager.Regions[RegionNameManager.ContentRegion];
            IViewable friendsContent = _containerProvider.Resolve<IViewable>(ContentNameManager.Friends);

            if (!contentRegion.Views.Contains(friendsContent))
            {
                contentRegion.Add(friendsContent);
            }
            contentRegion.Activate(friendsContent);
        }

        [RelayCommand]
        private void Logout()
        {
            IRegion mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
            IViewable loginContent = _containerProvider.Resolve<IViewable>(ContentNameManager.Login);

            if (!mainRegion.Views.Contains(loginContent))
            {
                mainRegion.Add(loginContent);
            }
            mainRegion.Activate(loginContent);
        }
    }
}
