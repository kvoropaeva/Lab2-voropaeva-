using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        public List<String> Sections { get; set; }
        private List<String> _categories;
        public List<String> Categories {
            get { return _categories; }
            set { _categories = value;
                DoPropertyChanged("Categories"); }
        }

        public String Name { get; set; }
        public String Number { get; set; }
        public String Email { get; set; }
        private String _selectedSection;
        public String SelectedSection {
            get { return _selectedSection; }
            set {
                _selectedSection = value;
                DoPropertyChanged("SelectedSection");
            }
        }
        public String SelectedCategory { get; set; }
        public String Problem { get; set; }
        public String FilePath { get; set; }

        public DateTime Date { get; set; }

        public MainWindowViewModel()
        {
            Categories = new List<String>();
            Sections = new List<String>()
            {
                "Игра",
                "Оплата",
                "Учетная запись"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static void PushLine(string name, string number, string email, DateTime date, string section, string category, string problem, string link)
        {
            using (SqlConnection cn = new SqlConnection("Server = mysimpledatabase.database.windows.net; Database = myDataBase; Trusted_Connection = True;"))
            {
                cn.Open();
                string sql = string.Format("INSERT INTO lab6(Name, Number, Email, Date, Section, Category, Problem, Link) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", name, number, email, date, section, category, problem, link);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => PushLine(Name, Number, Email, Date, SelectedSection, SelectedCategory, Problem, FilePath), _canExecute));

            }
        }
        private bool _canExecute;
    }
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }

    
}
}
