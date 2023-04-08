using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Login.UI.Views;
using Kakao.Receiver;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Windows;

namespace Kakao.Login.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableBase
    {
        private readonly HubManager _hubManager;
        private readonly IEventHub _eventHub;
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private GoogleWindow _googleWindow;

        [ObservableProperty]
        private string _email;

        public LoginContentViewModel(HubManager hubManager, IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider) 
        {
            _hubManager = hubManager;
            _eventHub = eventHub;
            _regionManager = regionManager;
            _containerProvider = containerProvider;

            _eventHub.Subscribe<OAuthCompletedPubSub, OauthCompletedArgs>(OAuthCompleted);
        }

        [RelayCommand]
        private void Login()
        {
            _googleWindow = new();
            _googleWindow.ShowDialog();
        }


        private async void OAuthCompleted(OauthCompletedArgs obj)
        {
            _hubManager.Start(_eventHub);

            _googleWindow.Close();

            IRegion mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
            IViewable mainConttent = _containerProvider.Resolve<IViewable>(ContentNameManager.Main);

            if (!mainRegion.Views.Contains(mainConttent))
            {
                mainRegion.Add(mainConttent);
            }
            mainRegion.Activate(mainConttent);

            await _hubManager.Connection.InvokeAsync("SendLogin", obj.Email);
        }
    }
}
