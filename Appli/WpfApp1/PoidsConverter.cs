
using System;
using System.Globalization;
using System.Windows.Data;
namespace GymApp
{
    public class PoidsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // On accepte maintenant le 'double' en entrée
            if (values[0] is not double poids) return "0";

            string unite = values[1] as string ?? "kg";

            if (unite == "lbs")
            {
                double lbs = poids * 2.20462;
                return $"{lbs:F1} lbs";
            }

            return $"{poids:F1} kg";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}