using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserInfos = new HashSet<UserInfo>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
