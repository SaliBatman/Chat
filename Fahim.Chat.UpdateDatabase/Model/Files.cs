using System;
using System.Collections.Generic;

namespace Fahim.Chat.UpdateDatabase.Model
{
    public partial class Files
    {
        public Guid FileId { get; set; }
        public string OrginalName { get; set; }
        public long FileSize { get; set; }
        public string StoragePath { get; set; }
        public string MimeType { get; set; }
        public int? Type { get; set; }
        public Guid? ItemId { get; set; }
        public byte[] TimeStamp { get; set; }
        public DateTime AddedDate { get; set; }

        public Conversation Item { get; set; }
        public Users ItemNavigation { get; set; }
    }
}
