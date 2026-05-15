using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Bibliotheque_classes;

namespace GymApp
{
    public partial class AjouterSerieWindow : Window
    {
        public Series? NouvelleSerie { get; private set; }

        private ObservableCollection<Series> _series = new ObservableCollection<Series>();

        public AjouterSerieWindow(IEnumerable<Exercice> exercices)
        {
            InitializeComponent();
            ComboExercice.ItemsSource = exercices;
            ComboExercice.SelectedIndex = 0;
            ListeSeriesControl.ItemsSource = _series;
            _series.Add(new Series());
        }


        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            // 1. Vérification de l'exercice
            if (ComboExercice.SelectedItem is not Exercice exoChoisi)
            {
                MessageBox.Show("Veuillez choisir un exercice.", "Erreur",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. On récupère l'unique objet Series présent dans notre collection
            // (celui qui a été mis à jour par les TextBox grâce au Binding)
            var serieSaisie = _series.FirstOrDefault();

            if (serieSaisie != null)
            {
                // On lui assigne l'exercice sélectionné dans la ComboBox
                serieSaisie.exercice = exoChoisi;

                // On définit la propriété publique pour que MainWindow puisse la récupérer
                NouvelleSerie = serieSaisie;

                DialogResult = true;
                Close();
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}