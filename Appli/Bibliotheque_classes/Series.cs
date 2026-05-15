using System;

namespace Bibliotheque_classes
{
    public class Series
    {
        public int Repetitions { get; set; } 

        public int Poids { get; set; }

        public bool Adding { get; set; }

        public Exercice exercice { get; set; }

        public Series(int repetitions = 0,
                      int poids = 0,
                      bool adding = true,
                      Exercice exo = null)
        {
            Repetitions= repetitions;
            Poids = poids;
            Adding = adding;
            exercice = exo;

        }
        public Series() : this(0, 0, true, null)
        {
        }

        public override string ToString()
        {
            return $"l'exo {exercice} le nombre de reps {Repetitions}";
        }
    }
}