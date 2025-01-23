using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace ilksangovtr_mobil.Converters
{
    public class OkunduStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool okundu = (bool)value;
            return okundu ? Color.FromArgb("#64748B") : Color.FromArgb("#0D7561");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 