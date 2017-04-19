using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication1
{
    class SelectedSectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ChooseCategory choose = new ChooseCategory();
                var SelectedSection = (String)value;
                switch (SelectedSection)
                {
                    case "Игра":
                        return choose.Game;
                    case "Оплата":
                        return choose.Pay;
                    case "Учетная запись":
                        return choose.Account;
                    default:
                        return new List<String>();
                }
            }
            catch
            {
                return new List<String>();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
