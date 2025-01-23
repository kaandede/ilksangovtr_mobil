using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace ilksangovtr_mobil.Converters
{
    public class SelectedCategoryBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedCategory = value?.ToString();
            string currentCategory = parameter?.ToString();

            return selectedCategory == currentCategory ? Color.FromArgb("#0D7561") : Color.FromArgb("#F1F5F9");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 