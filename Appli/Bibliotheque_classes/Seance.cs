using System.Collections.ObjectModel;

namespace Bibliotheque_classes
{
    public class Seance
    {
        public string Nom { get; set; }
        public string ImagePath { get; set; }

        // ← ObservableCollection au lieu de List
        public ObservableCollection<Series> ListeSeries { get; set; } = new ObservableCollection<Series>();

        public Seance(string nom = "Seance", string imagePath = @"Assets/images/blank.png")
        {
            Nom = nom;
            ImagePath = imagePath;
        }

        public void AddSerie(Series serie)
        {
            ListeSeries.Add(serie);
        }

        public Seance() : this("Seance", @"Assets/images/blank.png") { }

        public override string ToString()
        {
            string listContent = "";
            foreach (Series serie in ListeSeries)
                listContent += $"- {serie.exercice}\n";
            return $"Séance: {Nom}\nListe des exercices:{listContent}";
        }
    }
}