class Level
{
    private int currentLevel;

    public Level()
    {
        currentLevel = 1;
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void IncreaseLevel()
    {
        currentLevel++;
    }

    public void Draw()
    {
        Console.SetCursorPosition(15, 0);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"Level: {currentLevel}");
    }
}