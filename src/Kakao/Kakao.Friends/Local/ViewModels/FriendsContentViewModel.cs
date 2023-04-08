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
using Kakao.Core.Talkings;
using Kakao.Receiver;
using Kakao.Talk.UI.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private readonly TalkWindowManager _talkWindowManager;
        private readonly IEventHub _eventHub;
        private readonly HubManager _hubManager;
        [ObservableProperty]
        private List<FriendsModel> _favorites;

        public FriendsContentViewModel(HubManager hubManager, IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider, TalkWindowManager talkWindowManager)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _talkWindowManager = talkWindowManager;
            _eventHub = eventHub;
            _hubManager = hubManager;

            _eventHub.Subscribe<LoginUserPubSub, LoginUserArgs>(LoginUserReceived);
            _eventHub.Subscribe<SyncFriendsPubSub, SyncFriendsArgs>(SyncFriendsReceived);
            talkWindowManager.WindowCountChanged += TalkWindowManager_WindowCountChanged;

            Favorites = new();
        }

        private List<FriendsModel> GetFavorites()
        {
            List<FriendsModel> source = new();
            //source.Add(new FriendsModel().DataGen(0, "James"));
            //source.Add(new FriendsModel().DataGen(1, "Vicky"));
            //source.Add(new FriendsModel().DataGen(2, "Harry"));
            return source;
        }

        private void TalkWindowManager_WindowCountChanged(object? sender, EventArgs e)
        {
            TalkWindowRefreshArgs args = new();
            _eventHub.Publish<TalkWindowRefreshEvent, TalkWindowRefreshArgs>(args);
        }

        [RelayCommand]
        private void DoubleClick(FriendsModel data)
        {
            //UserIdsModel req = new(data.Id, );

            //await _hubManager.Connection.InvokeAsync("CreateOrJoinConversation",) ;
            TalkWindow window = _talkWindowManager.ResolveWindow<TalkWindow>(data.Email);
            TalkContent content = new();

            window.Title = data.Name;
            window.Width = 360;
            window.Height = 500;
            window.Content = content;

            if(content.DataContext is IReceiverInitializable receiver) 
            {
                receiver.InitReceiverInfo(data);
            }

            window.Show();
        }

        [RelayCommand]
        private void ShowSimulation()
        {
            IViewable simulation = _containerProvider.Resolve<IViewable>(ContentNameManager.Simulation);

            if (simulation is JamesWindow window)
            {
                window.Show();
            }
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

        private async void LoginUserReceived(LoginUserArgs obj)
        {
        }

        [RelayCommand]
        private async void SyncFriends()
        {
            await _hubManager.Connection.InvokeAsync("SyncFriends", new MessageModel());
        }

        [RelayCommand]
        private void SyncFriendsReceived(SyncFriendsArgs obj)
        {
            Favorites = obj.Friends;
        }
    }
}
