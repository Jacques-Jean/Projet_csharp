using System.Windows;

namespace GymApp
{
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();

            // Initialiser les boutons selon les préférences sauvegardées
            RadioNuit.IsChecked = ParametresService.Instance.ModeNuit;
            RadioJour.IsChecked = !ParametresService.Instance.ModeNuit;
            RadioKg.IsChecked = ParametresService.Instance.UtiliserKg;
            RadioLbs.IsChecked = !ParametresService.Instance.UtiliserKg;
        }

        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            ParametresService.Instance.ModeNuit = RadioNuit.IsChecked == true;
            ParametresService.Instance.UtiliserKg = RadioKg.IsChecked == true;
            ParametresService.Instance.Sauvegarder();

            var dict = System.Windows.Application.Current.Resources;
            var brush = dict["AppBackground"] as System.Windows.Media.SolidColorBrush;
            

            DialogResult = true;
            Close();
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}