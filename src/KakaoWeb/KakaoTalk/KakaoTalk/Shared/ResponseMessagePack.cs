using KakaoTalk.Shared.Models;
using SignalR.EasyUse.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoTalk.Shared
{
    public class ResponseMessagePack : IClientMethod
    {
        public MessageModel Response { get; set; }
    }
}
