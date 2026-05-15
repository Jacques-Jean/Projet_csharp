using System;

namespace Bibliotheque_classes
{
    public class Exercice
    {
        public string Nom { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string FocusedMuscle { get; set; }
        

        public Exercice(
            string nom = "Exercice ",
            string focus = "Général",
            string imagePath = @"Assets/images/blank.png",
            string description = "Aucune description disponible."
        )
        {
            Nom = nom;
            FocusedMuscle = focus;
            ImagePath = imagePath;
            Description = description;
        }
        public Exercice(): this("Exercice", "", @"Assets/images/blank.png", "")
        {
        }

        public override string ToString()
        {
            return $"{ Nom}";
        }
    }
}