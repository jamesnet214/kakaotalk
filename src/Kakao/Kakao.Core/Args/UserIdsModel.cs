using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Args
{
    public class UserIdsModel
    {
        public string User1Id { get; set; }
        public string User2Id { get; set; }

        public UserIdsModel(string user1Id, string user2Id)
        {
            // 정렬된 사용자 ID
            var sortedUserIds = new[] { user1Id, user2Id }.OrderBy(id => id).ToArray();
            User1Id = sortedUserIds[0];
            User2Id = sortedUserIds[1];
        }
    }
}
