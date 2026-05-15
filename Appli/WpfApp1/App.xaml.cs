using System.Windows;
using System.Windows.Media;

namespace GymApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Brushes mode jour par défaut
            SetThemeLight();

            ParametresService.Instance.Initialiser();
        }

        public static void SetThemeLight()
        {
            Application.Current.Resources["AppBackground"] = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            Application.Current.Resources["AppCardBg"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Application.Current.Resources["AppTextMain"] = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            Application.Current.Resources["AppTextSub"] = new SolidColorBrush(Color.FromRgb(136, 136, 136));
        }

        public static void SetThemeDark()
        {
            Application.Current.Resources["AppBackground"] = new SolidColorBrush(Color.FromRgb(18, 18, 18));
            Application.Current.Resources["AppCardBg"] = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            Application.Current.Resources["AppTextMain"] = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            Application.Current.Resources["AppTextSub"] = new SolidColorBrush(Color.FromRgb(160, 160, 160));
        }
    }
}