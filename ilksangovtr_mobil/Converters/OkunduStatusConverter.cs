using System;
using System.Globalization;

namespace ilksangovtr_mobil.Converters
{
    public class OkunduStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool okundu = (bool)value;
            return okundu ? "Okundu" : "Yeni";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 