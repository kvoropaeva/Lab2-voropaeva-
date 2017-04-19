using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
