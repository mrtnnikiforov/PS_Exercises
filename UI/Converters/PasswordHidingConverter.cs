using System;
using System.Globalization;
using System.Windows.Data;

namespace UI.Converters
{
    public class PasswordHidingConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            string password = value.ToString();

            return new string('*', password.Length);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
