using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Bibliotheque_classes;

namespace GymApp
{
    public partial class AjouterExerciceWindow : Window
    {
        public Exercice NouvelExercice { get; private set; }
        public List<Series> SeriesCreees { get; private set; }

        private ObservableCollection<Series> _series = new ObservableCollection<Series>();

        public AjouterExerciceWindow()
        {
            InitializeComponent();
            ListeSeriesControl.ItemsSource = _series;
            _series.Add(new Series()); // une série vide par défaut
        }


        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNom.Text) ||
                string.IsNullOrWhiteSpace(TxtMuscle.Text))
            {
                MessageBox.Show("Les champs Nom et Muscle ciblé sont obligatoires.",
                                "Champs manquants", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NouvelExercice = new Exercice(
                nom: TxtNom.Text.Trim(),
                focus: TxtMuscle.Text.Trim(),
                description: TxtDescription.Text.Trim()
            );


            DialogResult = true;
            Close();
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void TxtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}