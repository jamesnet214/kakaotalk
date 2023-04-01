using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Names;
using Kakao.Core.Talking;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity.Resolution;

namespace Kakao.Tests.Local.ViewModels
{
    public partial class SimulatorViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _eventHub;
        private readonly TalkWindowManager _talkWindowManager;

        [ObservableProperty]
        private List<KeyValuePair<int, JamesWindow>> _talkWindows;

        [ObservableProperty]
        private KeyValuePair<int, JamesWindow> _window;

        [ObservableProperty]
        private string _receiveText;

        public SimulatorViewModel(IEventHub eventHub, TalkWindowManager talkWindowManager)
        {
            _eventHub = eventHub;
            _talkWindowManager = talkWindowManager;

            _eventHub.Subscribe<RefreshTalkWindowEvent, RefreshTalkWindowArgs>((args) => Refresh());
        }

        public void OnLoaded(IViewable view)
        {
            Refresh();
        }

        [RelayCommand]
        private void Refresh()
        {
            TalkWindows = _talkWindowManager.GetAllWindows();
        }

        [RelayCommand]
        private void Receive()
        {

            var content = Window.Value.Content;

            if (content is FrameworkElement fe && fe.DataContext is IReceivedMessage receive)
            {
                receive.Receive(ReceiveText);
            }
        }
    }
}
