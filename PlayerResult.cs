using System.IO;

class PlayerResult
{
    public string Name { get; set; }
    public int Score { get; set; }

    private static string fileName = "scores.txt";

    public PlayerResult(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public void Save()
    {
        File.AppendAllText(fileName, $"{Name};{Score}\n");
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
        // Сортируем по убыванию очков
        return results.OrderByDescending(r => r.Score).ToList();
    }

    public static void DisplayResults()
    {
        var results = LoadAll();
        Console.Clear();
        Console.WriteLine("Records:");
        int rank = 1;
        foreach (var r in results)
        {
            Console.WriteLine($"{rank}. {r.Name} - {r.Score}");
            rank++;
        }
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}   