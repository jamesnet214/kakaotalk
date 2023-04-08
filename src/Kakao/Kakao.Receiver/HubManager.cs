using Jamesnet.Wpf.Global.Evemt;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kakao.Receiver
{
    public class HubManager
    {
        public HubConnection Connection;
        private IEventHub _ea;

        public int Test { get; private set; }

        public static HubManager Create()
        {
            HubManager hubManager = new();
            hubManager.Connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7287/chathub")
                .Build();

            return hubManager;
        }

        public async void Start(IEventHub ea)
        {
            _ea = ea;

            Test = 113;

            Connection.On<MessageModel>("ResponseMessagePack", (message) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoginUserArgs args = new();
                    args.Message = message;
                    _ea.Publish<LoginUserPubSub, LoginUserArgs>(args);
                });
            });

            Connection.On<List<FriendsModel>>("ResponseFriendsPack", (message) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SyncFriendsArgs args = new();
                    args.Friends = message;
                    _ea.Publish<SyncFriendsPubSub, SyncFriendsArgs>(args);
                });
            });

            try
            {
                await Connection.StartAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
