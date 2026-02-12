using System;
using System.Collections.Generic;
using System.Text;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.Name}");
            Console.WriteLine($"Role: {_viewModel.Role}");
        }

        public void DisplayError()
        {
            throw new Exception("An error occurred while displaying the user information.");
        }
    }
}
