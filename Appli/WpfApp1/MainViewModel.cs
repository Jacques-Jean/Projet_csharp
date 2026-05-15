using System.Collections.ObjectModel;
using System.ComponentModel;
using Bibliotheque_classes;

namespace GymApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Seance> Seances { get; set; }
        public ObservableCollection<Exercice> Exercices { get; set; }

        public MainViewModel()
        {
            // Charger exercices
            Exercices = new ObservableCollection<Exercice>(ExerciceService.Charger());
            if (Exercices.Count == 0)
            {
                Exercices.Add(new Exercice("Squat", "Quadriceps", @"Assets/images/blank.png", "Exercice de base pour les jambes."));
                Exercices.Add(new Exercice("Développé couché", "Pectoraux", @"Assets/images/blank.png", "Exercice de poitrine."));
                Exercices.Add(new Exercice("Traction", "Dos", @"Assets/images/blank.png", "Exercice de dos."));
                ExerciceService.Sauvegarder(Exercices);
            }

            // Charger séances
            var seancesChargees = SeanceService.Charger();
            if (seancesChargees != null && seancesChargees.Count > 0)
            {
                Seances = new ObservableCollection<Seance>(seancesChargees);
            }
            else
            {
                var seance1 = new Seance("Push Day");
                seance1.AddSerie(new Series(10, 80, true, Exercices[1]));
                Seances = new ObservableCollection<Seance> { seance1 };
                SeanceService.Sauvegarder(Seances);
            }
        }

        public void AjouterExercice(Exercice exercice)
        {
            Exercices.Add(exercice);
            ExerciceService.Sauvegarder(Exercices);
        }

        public void AjouterSeance(Seance seance)
        {
            Seances.Add(seance);
            SeanceService.Sauvegarder(Seances);
        }

        public void SupprimerExercice(Exercice exercice)
        {
            Exercices.Remove(exercice);
            ExerciceService.Sauvegarder(Exercices);
        }

        public void SupprimerSeance(Seance seance)
        {
            Seances.Remove(seance);
            SeanceService.Sauvegarder(Seances);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}