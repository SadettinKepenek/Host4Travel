using System;
using System.ComponentModel.DataAnnotations;

namespace Host4Travel.Entities.Concrete
{
    public partial class ChatMessage
    {
        [Key]
        public Guid ChatMessageId { get; set; }
        public string Message { get; set; }
        public string OwnerId { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsActive { get; set; }
        public Guid ChatId { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
