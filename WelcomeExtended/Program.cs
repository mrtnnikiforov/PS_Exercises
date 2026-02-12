using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var user = new User
                {
                    Name = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                var viewModel = new UserViewModel(user);

                var view = new UserView(viewModel);

                view.Display();

                Delegates.Log("Mn sum qk");

                view.DisplayError();

            }
            catch (Exception e)
            {
                Delegates.Log2(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}   