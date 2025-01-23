using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace ilksangovtr_mobil.Converters
{
    public class SelectedCategoryTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedCategory = value?.ToString();
            string currentCategory = parameter?.ToString();

            return selectedCategory == currentCategory ? Colors.White : Color.FromArgb("#677372");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 