using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Bibliotheque_classes;

namespace GymApp
{
    public static class SeanceService
    {
        private static readonly string _filePath = "seances.json";

        public static List<Seance> Charger()
        {
            if (!File.Exists(_filePath))
                return new List<Seance>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Seance>>(json) ?? new List<Seance>();
        }

        public static void Sauvegarder(IEnumerable<Seance> seances)
        {
            string json = JsonSerializer.Serialize(seances, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public static void Supprimer(Seance seanceASupprimer)
        {
            List<Seance> seances = Charger();

            seances.RemoveAll(e => e.Nom == seanceASupprimer.Nom);

            Sauvegarder(seances);
        }
    }
}