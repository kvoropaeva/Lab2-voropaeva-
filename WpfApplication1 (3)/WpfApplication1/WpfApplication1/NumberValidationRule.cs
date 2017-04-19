using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication1
{
    class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var s = (String)value;
            bool isNumber = true;
            char[] check = s.ToCharArray();
            for (int i = 0; i < check.Length; i++)
            {
                if (!Char.IsDigit(check[i]))
                {
                    isNumber = false;
                    break;
                }
            }
            if (isNumber)
            {
                return new ValidationResult(isNumber, String.Empty);
            }
            else
            {
                return new ValidationResult(isNumber, "Некорректные данные");
            }
        }
    }
}
