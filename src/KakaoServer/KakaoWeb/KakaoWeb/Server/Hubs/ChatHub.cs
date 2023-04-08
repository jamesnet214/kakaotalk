using KakaoWeb.Server.Data;
using KakaoWeb.Shared;
using KakaoWeb.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.EasyUse.Server;

namespace KakaoWeb.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SyncFriends(RequestInfo request)
        {
            List<FriendsModel> friends = new();
            foreach (var user in _context.Users.ToList())
            {
                friends.Add(new FriendsModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName
                });
            }

            ResponseFriendsPack pack = new();
            pack.Friends = friends;

            await Clients.All.SendAsync(pack);
        }
    }
}
