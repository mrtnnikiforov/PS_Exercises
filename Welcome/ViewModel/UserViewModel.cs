using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Model;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name { get => _user.Name; set => _user.Name = value; }
        public string Password { get => _user.Password; set => _user.Password = value; }
        public string Role { get => _user.Role.ToString(); set => _user.Role = (Others.UserRolesEnum)Enum.Parse(typeof(Others.UserRolesEnum), value); }

    }
}
