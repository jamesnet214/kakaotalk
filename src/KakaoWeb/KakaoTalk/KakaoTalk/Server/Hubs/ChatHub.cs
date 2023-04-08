using KakaoTalk.Server.Data;
using KakaoTalk.Server.Data.Services;
using KakaoTalk.Shared;
using KakaoTalk.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using SignalR.EasyUse.Server;

namespace KakaoTalk.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;
        private readonly ApplicationDbContext _contenxt;

        //private UserService _userService;

        public ChatHub(ChatService chatService, ApplicationDbContext context)
        {
            _chatService = chatService;
            _contenxt = context;
        }

        public async Task SyncFriends(MessageModel request)
        {
            List<FriendsModel> friends = new();
            foreach (var user in _contenxt.Users.ToList()) 
            {
                friends.Add(new FriendsModel() { Id = user.Id, Email = user.Email, Name = user.UserName });       
            }

            ResponseFriendsPack pack = new();
            pack.Friends = friends;

            await Clients.Caller.SendAsync(pack);
        }

        public async Task Login(MessageModel request)
        {
            ResponseMessagePack pack = new();
            pack.Response = request;
            await Clients.All.SendAsync(pack);
        }

        public async Task SendMessage(MessageModel request)
        {
            ResponseMessagePack pack = new();
            pack.Response = request;
            await Clients.All.SendAsync(pack);
        }

        public async Task CreateOrJoinConversation(string user1Id, string user2Id)
        {
            var conversation = await _chatService.CreateOrGetConversationAsync(user1Id, user2Id);

            // 이 예에서는 방 이름을 Conversation의 Id로 설정합니다.
            var roomName = conversation.Id.ToString();

            // 클라이언트가 방에 참여하도록 합니다.
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

            // 클라이언트에게 방 정보를 전달합니다.
            await Clients.Caller.SendAsync("ConversationCreated", roomName);
        }
    }
}
