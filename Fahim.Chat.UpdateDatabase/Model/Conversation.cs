using System;
using System.Collections.Generic;

namespace Fahim.Chat.UpdateDatabase.Model
{
    public partial class Conversation
    {
        public Conversation()
        {
            Files = new HashSet<Files>();
        }

        public Guid ConversationId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public int MessageStatus { get; set; }
        public int MessageType { get; set; }
        public DateTime AddedDate { get; set; }
        public string Body { get; set; }
        public ICollection<Files> Files { get; set; }
    }
}
