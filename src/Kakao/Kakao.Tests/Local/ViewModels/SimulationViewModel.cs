using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Names;
using Kakao.Core.Talkings;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Kakao.Tests.Local.ViewModels
{
    public partial class SimulationViewModel : ObservableBase, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;
        private readonly TalkWindowManager _talkWindowManager;
        private readonly IEventHub _eventHub;
        [ObservableProperty]
        private List<KeyValuePair<int, JamesWindow>> _windows;

        [ObservableProperty]
        private KeyValuePair<int, JamesWindow> _window;

        [ObservableProperty]
        private string _sendText;

        public SimulationViewModel(IEventHub eventHub, IRegionManager regionManager, IContainerProvider containerProvider, TalkWindowManager talkWindowManager)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _talkWindowManager = talkWindowManager;
            _eventHub = eventHub;

            _eventHub.Subscribe<TalkWindowRefreshEvent, TalkWindowRefreshArgs>((args) => Refresh());
        }

        public void OnLoaded(IViewable view)
        {
            Refresh();
        }

        [RelayCommand]
        private void Refresh()
        {
            Windows = _talkWindowManager.GetAllWindows();
        }

        [RelayCommand]
        private void Send()
        {
            JamesWindow window = _talkWindowManager.GetWindow(Window.Key);

            if (window != null)
            {
                if(window.Content is FrameworkElement fe && fe.DataContext is IReceiveMessage receiveMessage)

                receiveMessage.Received(SendText);
            }
        }
    }
}
