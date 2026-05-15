using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GymApp
{
    public class CouleurSeanceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                if (count == 0) return new SolidColorBrush(Color.FromRgb(200, 200, 200));
                if (count <= 3) return new SolidColorBrush(Color.FromRgb(46, 213, 115));  
                if (count <= 6) return new SolidColorBrush(Color.FromRgb(255, 193, 7));  
                return new SolidColorBrush(Color.FromRgb(233, 69, 96));  
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}