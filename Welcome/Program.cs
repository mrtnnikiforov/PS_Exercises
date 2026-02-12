using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Name = "Ivan Atanasov", Password = "password", Role = UserRolesEnum.ADMIN };
            UserViewModel viewModel = new UserViewModel(user);
            UserView view = new UserView(viewModel);

            view.Display();
        }
    }
}