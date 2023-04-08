using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoTalk.Server.Data.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ConversationId")]
        public virtual Conversation Conversation { get; set; }
        public Guid ConversationId { get; set; }

        [ForeignKey("UserId")]
        public virtual Server.Models.ApplicationUser Sender { get; set; }
        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
