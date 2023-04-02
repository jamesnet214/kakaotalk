using Kakao.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Talkings
{
    public class ChatStorage
    {
        private readonly Dictionary<FriendsModel, List<MessageModel>> chats;

        public ChatStorage()
        {
            chats = new();
        }

        public ObservableCollection<MessageModel> GetChatHistory(FriendsModel friends)
        {
            if (!chats.ContainsKey(friends))
            {
                chats.Add(friends, new List<MessageModel>());
            }
            return new ObservableCollection<MessageModel>(chats[friends]);
        }

        public void Save(FriendsModel friends, MessageModel sendText)
        {
            if (!chats.ContainsKey(friends))
            { 
                chats.Add(friends, new List<MessageModel>());
            }
            chats[friends].Add(sendText);   
        }
    }
}
