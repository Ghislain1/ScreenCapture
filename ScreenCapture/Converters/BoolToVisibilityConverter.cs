

namespace Figma.Converters;
 
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows;
    using System;

    public class BoolToVisibilityConverter : IValueConverter
    {
    public static BoolToVisibilityConverter Instance = new BoolToVisibilityConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is true)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }
    }
 
