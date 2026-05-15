using System.Collections.Generic;
using System.Windows;
using Bibliotheque_classes; // Vérifie que c'est bien ton namespace pour la classe Exercice

namespace GymApp
{
    public partial class SupprimerSeanceWindow : Window
    {
        public Seance SeanceSelectionne { get; private set; }

        public SupprimerSeanceWindow(IEnumerable<Seance> liste)
        {
            InitializeComponent();
            ComboSeances.ItemsSource = liste;
        }

        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            SeanceSelectionne = ComboSeances.SelectedItem as Seance;

            if (SeanceSelectionne != null)
            {
                this.DialogResult = true; // Ferme la fenêtre et renvoie "True"
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une Seance dans la liste.");
            }
        }
    }
}