using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Host4Travel.UI
{
    public partial class Chat
    {
        public Chat()
        {
            ChatMessage = new HashSet<ChatMessage>();
        }
        [Key]
        public Guid ChatId { get; set; }
        public Guid? PostId { get; set; }
        public string Side1 { get; set; }
        public string Side2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
    }
}
