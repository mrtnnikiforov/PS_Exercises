using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataLayer.Database;
using DataLayer.Model;

namespace UI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DatabaseUser> _students;
        private ObservableCollection<LogEntry> _logs;

        public ObservableCollection<DatabaseUser> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public ObservableCollection<LogEntry> Logs
        {
            get => _logs;
            set
            {
                _logs = value;
                OnPropertyChanged("Logs");
            }
        }

        public MainViewModel()
        {
            LoadData();
        }

        public void FilterLogsByUser(DatabaseUser user)
        {
            using (var context = new DatabaseContext())
            {
                var filtered = context.Logs
                    .Where(l => l.Message != null && l.Message.Contains(user.Name))
                    .ToList();

                Logs = new ObservableCollection<LogEntry>(filtered);
            }
        }

        private void LoadData()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                Students = new ObservableCollection<DatabaseUser>(context.Users.ToList());
                Logs = new ObservableCollection<LogEntry>(context.Logs.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}