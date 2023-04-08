using KakaoTalk.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KakaoTalk.Server.Data.Services
{
    public class ChatService
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conversation> CreateOrGetConversationAsync(string user1Id, string user2Id)
        {
            if (user1Id == user2Id)
            {
                throw new ArgumentException("User1 and User2 cannot be the same.");
            }

            // 정렬된 사용자 ID
            var sortedUserIds = new[] { user1Id, user2Id }.OrderBy(id => id).ToArray();
            user1Id = sortedUserIds[0];
            user2Id = sortedUserIds[1];

            // 이미 존재하는 대화를 찾습니다.
            var existingConversation = await _dbContext.Conversations
                .FirstOrDefaultAsync(c => c.User1Id == user1Id && c.User2Id == user2Id);

            if (existingConversation != null)
            {
                // 기존 대화가 있는 경우 반환
                return existingConversation;
            }

            var conversation = new Conversation
            {
                User1Id = user1Id,
                User2Id = user2Id
            };

            await _dbContext.Conversations.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            return conversation;
        }
    }
}
