using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Names;
using Kakao.Login.UI.Views;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Windows;

namespace Kakao.Login.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableBase
    {
        private readonly IEventHub _eventHub;
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private GoogleWindow _window;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _email;

        public LoginContentViewModel(IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider) 
        {
            _eventHub = eventHub;
            _regionManager = regionManager;
            _containerProvider = containerProvider;

            _eventHub.Subscribe<LoginCompletedPubSub, LoginCompletedArgs>(LoginCompleted);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Email);
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private void Login()
        {
            _window = new();
            _window.ShowDialog();

            return;
        }

        private void LoginCompleted(LoginCompletedArgs obj)
        {
            _window.Close();

            IRegion mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
            IViewable mainConttent = _containerProvider.Resolve<IViewable>(ContentNameManager.Main);

            if (!mainRegion.Views.Contains(mainConttent))
            {
                mainRegion.Add(mainConttent);
            }
            mainRegion.Activate(mainConttent);
        }
    }
}
