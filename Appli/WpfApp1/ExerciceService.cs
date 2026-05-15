using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Bibliotheque_classes;

namespace GymApp
{
    public static class ExerciceService
    {
        private static readonly string _filePath = "exercices.json";

        public static List<Exercice> Charger()
        {
            if (!File.Exists(_filePath))
                return new List<Exercice>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Exercice>>(json) ?? new List<Exercice>();
        }

        public static void Sauvegarder(IEnumerable<Exercice> exercices)
        {
            string json = JsonSerializer.Serialize(exercices, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public static void Supprimer(Exercice exerciceASupprimer)
        {
            List<Exercice> exercices = Charger();

            exercices.RemoveAll(e => e.Nom == exerciceASupprimer.Nom);

            Sauvegarder(exercices);
        }
    }
}