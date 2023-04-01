using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using Kakao.Core.Talkings;
using System.Collections.ObjectModel;

namespace Kakao.Talk.Local.ViewModels
{
    public partial class TalkContentViewModel : ObservableBase, IViewLoadable, ITalkInitializable, IReceiveMessage
    {
        private readonly ChatStorage _chatStorage;
        private FriendsModel _friends;

        [ObservableProperty]
        private string _sendText;

        [ObservableProperty]
        private ObservableCollection<MessageModel> _messages;

        public TalkContentViewModel(ChatStorage chatStorage) 
        {
            _chatStorage = chatStorage;
        }

        public void InitInformation(FriendsModel data)
        {
            _friends = data;
        }

        public void OnLoaded(IViewable smartWindow)
        {
            Messages = _chatStorage.GetChats(_friends);
        }

        [RelayCommand]
        private void Send()
        {
            MessageModel message = new MessageModel().DataGen("Send", SendText);

            Messages.Add(message);
            _chatStorage.Save(_friends, message);
            SendText = "";
        }

        public void Received(string receivedText)
        {
            MessageModel message = new MessageModel().DataGen("Received", receivedText);
            Messages.Add(message);
            _chatStorage.Save(_friends, message);
        }
    }
}
