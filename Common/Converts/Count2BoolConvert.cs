using System;
using System.Globalization;
using System.Windows.Data;

namespace MyToDoDemo.Common.Converts
{
    public class Count2BoolConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                if (result == true)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
