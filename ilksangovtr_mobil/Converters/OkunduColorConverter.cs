using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace ilksangovtr_mobil.Converters
{
    public class OkunduColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool okundu = (bool)value;
            return okundu ? Microsoft.Maui.Graphics.Colors.White : Color.FromArgb("#F8FAFC");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 