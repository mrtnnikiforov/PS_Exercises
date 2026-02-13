using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new LoggerProvider();
            var fileLogger = provider.CreateFileLogger("FileLogger");

            try
            {
                UserData userData = new UserData();

               
                userData.AddUser(new User { Name = "student", Password = "123", Role = UserRolesEnum.STUDENT });
                userData.AddUser(new User { Name = "Student2", Password = "123", Role = UserRolesEnum.STUDENT });
                userData.AddUser(new User { Name = "Teacher", Password = "1234", Role = UserRolesEnum.PROFESSOR });

                
                Console.Write("Enter Username: ");
                string name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();

                
                if (userData.ValidateCredentials(name, pass))
                {
                    var loggedUser = userData.GetUser(name, pass);
                    fileLogger.LogInformation($"User {loggedUser.Name} logged in successfully.");
                    Console.WriteLine(loggedUser.ToUserString());
                }
                else
                {
                    throw new Exception("User not found!");
                }

            }
            catch (Exception e)
            {
                fileLogger.LogError($"[{DateTime.Now}] Error: {e.Message}");

                ActionOnError log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}   