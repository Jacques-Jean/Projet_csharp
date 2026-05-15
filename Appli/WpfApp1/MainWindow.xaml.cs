using System.Windows;
using System.Windows.Controls;
using Bibliotheque_classes;

namespace GymApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }

        private void BtnSeances_Click(object sender, RoutedEventArgs e)
        {
            ExercicesPanel.Visibility = Visibility.Collapsed;
            SeancesPanel.Visibility = Visibility.Visible;

            TxtTitrePage.Text = "Séances";
        }

        private void BtnExercices_Click(object sender, RoutedEventArgs e)
        {
            SeancesPanel.Visibility = Visibility.Collapsed;
            ExercicesPanel.Visibility = Visibility.Visible;
            TxtTitrePage.Text = "Exercices";
        }

        private void BtnParametres_Click(object sender, RoutedEventArgs e)
        {
            // 1. Instanciation
            var fenetre = new Parametres();

            // 2. Définir le propriétaire (pour que la fenêtre soit centrée sur la principale)
            fenetre.Owner = this;

            // 3. Affichage en mode modal (bloque la fenêtre principale tant qu'elle est ouverte)
            fenetre.ShowDialog();
        }
        private void BtnAjouterExercice_Click(object sender, RoutedEventArgs e)
        {
            var fenetre = new AjouterExerciceWindow();
            fenetre.Owner = this;
            if (fenetre.ShowDialog() == true)
                _vm.AjouterExercice(fenetre.NouvelExercice);
        }

        private void BtnSupprimerExercice_Click(object sender, RoutedEventArgs e)
        {
            var fenetre = new SupprimerExerciceWindow(_vm.Exercices);
            fenetre.Owner = this;

            if (fenetre.ShowDialog() == true)
            {
                var exASupprimer = fenetre.ExerciceSelectionne;
                var result = MessageBox.Show($"Voulez-vous vraiment supprimer l'exercice '{exASupprimer.Nom}' ?",
                                             "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    _vm.SupprimerExercice(exASupprimer);
            }
        }

        private void BtnAjouterSeance_Click(object sender, RoutedEventArgs e)
        {
            var fenetre = new AjouterSeanceWindow();
            fenetre.Owner = this;
            if (fenetre.ShowDialog() == true)
                _vm.AjouterSeance(fenetre.NouvelSeance);
        }

        private void BtnSupprimerSeance_Click(object sender, RoutedEventArgs e)
        {
            var fenetre = new SupprimerSeanceWindow(_vm.Seances);
            fenetre.Owner = this;

            if (fenetre.ShowDialog() == true)
            {
                var seanceASupprimer = fenetre.SeanceSelectionne;
                var result = MessageBox.Show($"Voulez-vous vraiment supprimer '{seanceASupprimer.Nom}' ?",
                                             "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    _vm.SupprimerSeance(seanceASupprimer);
            }
        }

        private void BtnModifierSeriesSeance_Click(object sender, RoutedEventArgs e)
        {
            var seance = (sender as Button)?.Tag as Seance;
            if (seance == null) return;

            var fenetre = new ModifierSeriesWindow(seance, _vm.Exercices, _vm.Seances);
            fenetre.Owner = this;
            fenetre.ShowDialog();
        }
    }
}