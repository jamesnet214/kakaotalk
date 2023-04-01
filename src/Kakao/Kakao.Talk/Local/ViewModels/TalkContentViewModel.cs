using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Core.Talking;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Talk.Local.ViewModels
{
    public partial class TalkContentViewModel : ObservableBase, IReceivedMessage, IReceiverInfo, IViewLoadable
    {
        private readonly ChatStorage _chatStorage;
        [ObservableProperty]
        private string _sendText;

        [ObservableProperty]
        private ObservableCollection<MessageModel> _chats;
        private FriendsModel _receiver;

        public TalkContentViewModel(ChatStorage chatStorage)
        {
            _chatStorage = chatStorage;
            SendText = "";            
        }

        public void InitReceiver(FriendsModel data)
        {
            _receiver = data;
        }

        public void OnLoaded(IViewable smartWindow)
        {
            Chats = new(_chatStorage.GetChatHistory(_receiver));
        }

        public void Receive(string receiveText)
        {
            var message = new MessageModel().DataGen("Receive", receiveText);
            Chats.Add(message);
            _chatStorage.Add(_receiver, message);
        }

        [RelayCommand]
        private void Send()
        {
            var message = new MessageModel().DataGen("Send", SendText);
            Chats.Add(message);
            _chatStorage.Add(_receiver, message);
            SendText = ""; 
        }
    }
}
