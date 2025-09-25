class Score
{
    private int points;

    public Score()
    {
        points = 0;
    }

    public void AddPoints(int amount)
    {
        points += amount;
    }

    public int GetPoints()
    {
        return points;
    }

    public void Draw()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Score: {points}");
    }
}