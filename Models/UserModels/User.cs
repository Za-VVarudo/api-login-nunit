using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models.UserModels
{
    public class User
    {
        public string UserID { get; init; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string RoleID { get; set; }

        public User() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else
            {
                var user = obj as User;
                return UserID == user.UserID && FullName == user.FullName
                                             && Email == user.Email
                                             && Phone == user.Phone
                                             && Address == user.Address
                                             && RoleID == user.RoleID;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
