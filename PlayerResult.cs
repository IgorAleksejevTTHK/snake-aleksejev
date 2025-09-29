using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Snake
{
    public class PlayerResult
    {
        public string Name { get; set; }
        public int Score { get; set; }

        private static string fileName = "scores.txt";
        private static int maxRecords = 10; // топ-10

        public PlayerResult(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public void Save()
        {
            if (Name.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nimi peaks olla vähemalt 3 tähemärki pikk!");
                Console.ResetColor();
                return;
            }

            var allResults = LoadAll();
            allResults.Add(this);

            var sortedResults = allResults
                .OrderByDescending(r => r.Score)
                .Take(maxRecords)
                .ToList();

            File.WriteAllLines(fileName, sortedResults.Select(r => $"{r.Name};{r.Score}"));
        }

        public static List<PlayerResult> LoadAll()
        {
            var results = new List<PlayerResult>();

            if (!File.Exists(fileName))
                return results;

            foreach (var line in File.ReadAllLines(fileName))
            {
                var parts = line.Split(';');
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    results.Add(new PlayerResult(parts[0], score));
                }
            }

            return results;
        }

        public static void DisplayResults()
        {
            var results = LoadAll();
            Console.Clear();
            Console.WriteLine("=== Leaderboard===");
            int rank = 1;
            foreach (var r in results)
            {
                Console.WriteLine($"{rank}. {r.Name} - {r.Score}");
                rank++;
            }
            Console.WriteLine("\nSisestage midagi et edasi minna...");
            Console.ReadKey();
        }
    }
}
