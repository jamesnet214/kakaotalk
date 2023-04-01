using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Core.Talking;
using Kakao.Talk.UI.Views;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Documents;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {
        private readonly IEventHub _eventHub;
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private readonly TalkWindowManager _talkWindowManager;
        [ObservableProperty]
        private List<FriendsModel> _favorites;

        public FriendsContentViewModel(IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider, TalkWindowManager talkWindowManager)
        {
            _eventHub = eventHub;
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _talkWindowManager = talkWindowManager;
            _talkWindowManager.WindowCountChanged += _talkWindowManager_WindowCountChanged;

            Favorites = GetFavorites();
        }

        private void _talkWindowManager_WindowCountChanged(object? sender, EventArgs e)
        {
            RefreshTalkWindowArgs args = new();
            _eventHub.Publish<RefreshTalkWindowEvent, RefreshTalkWindowArgs>(args);
        }

        private List<FriendsModel> GetFavorites()
        {
            List<FriendsModel> source = new();
            source.Add(new FriendsModel().DataGen(1, "James"));
            source.Add(new FriendsModel().DataGen(2, "Vicky"));
            source.Add(new FriendsModel().DataGen(3, "Harry"));

            return source;
        }

        [RelayCommand]
        private void DoubleClick(FriendsModel data)
        {
            TalkContent content = new TalkContent();
            TalkWindow talkWindow = _talkWindowManager.ResolveWindow<TalkWindow>(data.Id);
            talkWindow.Content = content;
            talkWindow.Title = data.Name;
            talkWindow.Width = 360;
            talkWindow.Height = 500;

            if (content.DataContext is IReceiverInfo info)
            {
                info.InitReceiver(data);
            }

            talkWindow.Show();
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

        [RelayCommand]
        private void ShowSimulator()
        {
            IViewable simulatorWindow = _containerProvider.Resolve<IViewable>(ContentNameManager.Simulator);

            if (simulatorWindow is JamesWindow win)
            {
                win.Show();
            }
        }
    }
}
