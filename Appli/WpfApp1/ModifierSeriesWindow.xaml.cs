using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Bibliotheque_classes;

namespace GymApp
{
    public partial class ModifierSeriesWindow : Window
    {
        private readonly Seance _seance;
        private readonly IEnumerable<Seance> _toutesLesSeances;

        // Snapshot des séries au moment où on ouvre la fenêtre
        // pour pouvoir annuler les modifications
        private readonly List<Series> _seriesOriginales;

        public ModifierSeriesWindow(Seance seance, IEnumerable<Exercice> exercices, IEnumerable<Seance> toutesLesSeances)
        {
            InitializeComponent();
            _seance = seance;
            _toutesLesSeances = toutesLesSeances;

            // Sauvegarde l'état original pour le bouton Annuler
            _seriesOriginales = seance.ListeSeries.ToList();

            RunNomSeance.Text = seance.Nom;
            ComboExercice.ItemsSource = exercices;
            ComboExercice.SelectedIndex = 0;

            ListeSeriesControl.ItemsSource = _seance.ListeSeries;
        }

        private void BtnAjouterSerie_Click(object sender, RoutedEventArgs e)
        {
            if (ComboExercice.SelectedItem is not Exercice exo)
            {
                MessageBox.Show("Choisis un exercice.", "Erreur",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TxtReps.Text, out int reps))
            {
                MessageBox.Show("Entre un nombre de répétitions valide.", "Erreur",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TxtPoids.Text, out int poids))
            {
                MessageBox.Show("Entre un poids valide.", "Erreur",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _seance.ListeSeries.Add(new Series(reps, poids, true, exo));
            TxtReps.Text = "";
            TxtPoids.Text = "";
        }

        private void BtnSupprimerSerie_Click(object sender, RoutedEventArgs e)
        {
            var serie = (sender as Button)?.Tag as Series;
            if (serie != null)
                _seance.ListeSeries.Remove(serie);
        }

        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            // Sauvegarde toutes les séances dans le JSON
            SeanceService.Sauvegarder(_toutesLesSeances);
            Close();
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Restaure les séries originales
            _seance.ListeSeries.Clear();
            foreach (var s in _seriesOriginales)
                _seance.ListeSeries.Add(s);

            Close();
        }
    }
}