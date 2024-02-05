using System;
using System.Globalization;
using System.Windows.Data;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    public class ImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string pytb = AppDomain.CurrentDomain.BaseDirectory;
                string full = System.IO.Path.Combine(pytb, value.ToString());
                return full;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
