using KakaoWeb.Shared.Models;
using SignalR.EasyUse.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoWeb.Shared
{
    public class ResponseFriendsPack : IClientMethod
    {
        public List<FriendsModel> Friends { get; set; }
    }
}
