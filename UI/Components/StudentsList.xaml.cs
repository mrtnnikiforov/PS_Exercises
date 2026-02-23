using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataLayer.Model;
using UI;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Components
{
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (studentsGrid.SelectedItem is DatabaseUser user)
            {
                if (this.DataContext is MainViewModel viewModel)
                {
                    viewModel.FilterLogsByUser(user);
                }
            }
        }
    }
}
