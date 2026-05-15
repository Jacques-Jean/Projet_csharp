using Bibliotheque_classes;
using System.Text.Json;
namespace Tests_de_classes
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var Bench = new Exercice("Bench", "pecs","", "Meilleur exo existant ");
            Series serie1 = new Series(2,8,true,Bench);
            var exCible = new Exercice(
    nom: "Pompes",
    imagePath: "assets/pompes.jpg"
);
            var serie2 = new Series();

            var PUSH = new Seance(nom: "PUSH");
            PUSH.AddSerie(serie1);
            PUSH.AddSerie(serie2);

            Console.WriteLine(PUSH);





        }
    }
}
