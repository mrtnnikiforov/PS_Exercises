using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true; 
                }
            }
            return false;
        }
        
        public User GetUser(string name, string password)
        {
            return _users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public void SetActive(string name, DateTime expires)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Expires = expires;
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}