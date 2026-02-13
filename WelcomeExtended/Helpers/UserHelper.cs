using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToUserString(this User user)
        {
            return $"ID: {user.Id}, Name: {user.Name}, Role: {user.Role}";
        }

        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new Exception("The name and password cannot be empty");
            }
            return userData.ValidateUser(name, password);
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new Exception("The name and password cannot be empty");
            }
            return userData.GetUser(name, password);
        }
    }
}