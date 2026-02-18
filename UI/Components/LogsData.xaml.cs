using DataLayer.Database;
using DataLayer.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UI.Components
{
    public partial class LogsData : UserControl
    {
        public LogsData()
        {
            InitializeComponent();

            using var context = new DatabaseContext();
            context.Database.EnsureCreated();
            var logs = context.Logs.ToList();
            logsGrid.ItemsSource = logs;
        }

        private void OnMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (logsGrid.SelectedItem is LogEntry log)
            {
                MessageBox.Show($"[{log.Timestamp:G}]\n\n{log.Message}", "Log entry", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
