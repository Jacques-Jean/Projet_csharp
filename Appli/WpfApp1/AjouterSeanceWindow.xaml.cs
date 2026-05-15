using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Bibliotheque_classes;

namespace GymApp
{
    public partial class AjouterSeanceWindow : Window
    {
        public Seance NouvelSeance { get; private set; }
        public List<Series> SeriesCreees { get; private set; }

        private ObservableCollection<Series> _series = new ObservableCollection<Series>();

        public AjouterSeanceWindow()
        {
            InitializeComponent();
            _series.Add(new Series()); // une série vide par défaut
        }


        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNom.Text))
            {
                MessageBox.Show("Le champ Nom est obligatoire.");
                return;
            }

            NouvelSeance = new Seance(
                nom: TxtNom.Text.Trim()
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