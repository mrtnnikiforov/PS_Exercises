using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _name;
        private string _password;
        private UserRolesEnum role;
        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
        public UserRolesEnum Role { get => role; set => role = value; }

    }
}
