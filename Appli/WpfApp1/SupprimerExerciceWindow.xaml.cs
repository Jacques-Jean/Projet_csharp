using System.Collections.Generic;
using System.Windows;
using Bibliotheque_classes; // Vérifie que c'est bien ton namespace pour la classe Exercice

namespace GymApp
{
    public partial class SupprimerExerciceWindow : Window
    {
        // Propriété pour récupérer l'exercice choisi depuis la MainWindow
        public Exercice ExerciceSelectionne { get; private set; }

        public SupprimerExerciceWindow(IEnumerable<Exercice> liste)
        {
            InitializeComponent();
            ComboExercices.ItemsSource = liste;
        }

        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            ExerciceSelectionne = ComboExercices.SelectedItem as Exercice;

            if (ExerciceSelectionne != null)
            {
                this.DialogResult = true; // Ferme la fenêtre et renvoie "True"
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un exercice dans la liste.");
            }
        }
    }
}