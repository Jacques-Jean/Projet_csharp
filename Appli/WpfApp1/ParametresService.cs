using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Media;

namespace GymApp
{
    public class ParametresService : INotifyPropertyChanged
    {
        public static ParametresService Instance { get; } = new ParametresService();

        private static readonly string _filePath = "parametres.json";

        private bool _modeNuit = false;
        public bool ModeNuit
        {
            get => _modeNuit;
            set
            {
                _modeNuit = value;
                OnPropertyChanged(nameof(ModeNuit));
                AppliquerTheme();
            }
        }

        private bool _utiliserKg = true;
        public bool UtiliserKg
        {
            get => _utiliserKg;
            set
            {
                _utiliserKg = value;
                OnPropertyChanged(nameof(UtiliserKg));
                OnPropertyChanged(nameof(UnitePoids));
            }
        }

        public string UnitePoids => _utiliserKg ? "kg" : "lbs";

        // Constructeur privé — pas d'appel à Charger() ici
        private ParametresService() { }

        // À appeler manuellement depuis App.xaml.cs APRÈS que l'app soit démarrée
        public void Initialiser()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    var data = JsonSerializer.Deserialize<ParametresData>(json);
                    if (data != null)
                    {
                        _modeNuit = data.ModeNuit;
                        _utiliserKg = data.UtiliserKg;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur chargement paramètres: {ex.Message}");
            }

            AppliquerTheme();
        }

        public void Sauvegarder()
        {
            try
            {
                var data = new ParametresData { ModeNuit = _modeNuit, UtiliserKg = _utiliserKg };
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur sauvegarde paramètres: {ex.Message}");
            }
        }

        private void AppliquerTheme()
        {
            if (App.Current == null) return;

            if (_modeNuit)
                App.SetThemeDark();
            else
                App.SetThemeLight();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public class ParametresData
    {
        public bool ModeNuit { get; set; } = false;
        public bool UtiliserKg { get; set; } = true;
    }
}