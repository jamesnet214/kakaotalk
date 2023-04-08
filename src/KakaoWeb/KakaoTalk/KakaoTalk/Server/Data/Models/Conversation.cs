using KakaoTalk.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoTalk.Server.Data.Models
{
    public class Conversation
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User1Id")]
        public virtual ApplicationUser User1 { get; set; }
        public string User1Id { get; set; }

        [ForeignKey("User2Id")]
        public virtual ApplicationUser User2 { get; set; }
        public string User2Id { get; set; }

        public ICollection<Message> Messages { get; set; }
    }

}
