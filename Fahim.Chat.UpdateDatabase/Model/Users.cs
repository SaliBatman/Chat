using System;
using System.Collections.Generic;

namespace Fahim.Chat.UpdateDatabase.Model
{
    public partial class Users
    {
        public Users()
        {
            Files = new HashSet<Files>();
        }

        public Guid UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string About { get; set; }
        public bool IsLogin { get; set; }
        public string Username { get; set; }
        public long IdentifierNumber { get; set; }

        public ICollection<Files> Files { get; set; }
    }
}
