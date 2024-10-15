using System.Reflection.Metadata.Ecma335;

namespace mintazhtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. feladat

            string[] genresInput = File.ReadAllLines("genre.txt");

            List<string> genreList = new List<string>();

            string[] genresSplit = genresInput[0].Split(", ");

            for (int i = 0; i < genresSplit.Length; i++)
            {
                genreList.Add(genresSplit[i]);
            }

            // 2. feladat


            string[] csvInput = File.ReadAllLines("games_dataset.csv");

            List<string> gameTitle = new List<string>();
            List<string> gameGenre = new List<string>();
            List<string> gamePublisher = new List<string>();
            List<DateTime> gameRlsDate = new List<DateTime>();
            List<DateTime> gameOrigRlsDate = new List<DateTime>();

            // 1 index mert fejléc

            for (int i = 1; i < csvInput.Length; i++)
            {
                string[] csvSplit = csvInput[i].Split(";");

                gameTitle.Add(csvSplit[0]);

                // műfajokbol parseolni -1 indexxel mert 1 vs 0 indexelés

                int genreIdx = int.Parse(csvSplit[1]) - 1;

                gameGenre.Add(genreList[genreIdx]);

                gamePublisher.Add(csvSplit[2]);

                gameRlsDate.Add(DateTime.Parse(csvSplit[3]));

                gameOrigRlsDate.Add(DateTime.Parse(csvSplit [4]));



                
            }

            // 3. feladat


            Console.WriteLine("Kérem a kiadó nevét:");

            
            string pubInput = Console.ReadLine();

            int pubCount = 0;

            for (int i = 0; i < gamePublisher.Count; i++)
            {
                
                if (pubInput.ToLower() == gamePublisher[i].ToLower())
                {
                    pubCount++;
                }
            }

            Console.WriteLine($"This publisher has {pubCount} games in the list.");


            // 4. feladat

            for (int i = 0; i < gameTitle.Count; i++)
            {
                if (gameOrigRlsDate[i].Year == gameRlsDate[i].Year)
                {
                    Console.WriteLine($"{gameTitle[i]} {gameGenre[i]} {gameRlsDate[i].Year}");
                }
            }


            // 5. feladat

            for (int i = 0; i < genreList.Count; i++)
            {
                int genreCount = 0;

                for (global::System.Int32 j = 0; j < gameGenre.Count; j++)
                {
                    if (genreList[i] == gameGenre[j])
                    {
                        genreCount++;
                    }
                }

                Console.WriteLine($"{genreList[i]} - {genreCount} ");
            }

            
        }
    }
}
