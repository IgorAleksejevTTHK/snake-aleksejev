using System;

namespace Snake
{
    public static class GameOverScreen
    {
        public static void Show()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("==============================", xOffset, yOffset++);
            WriteText("G A M E O V E R", xOffset + 8, yOffset++);
            yOffset++;
            WriteText("noob.", xOffset + 13, yOffset++);
            WriteText("special for programming lesson", xOffset, yOffset++);
            WriteText("==============================", xOffset, yOffset++);
            Console.ResetColor();
        }

        private static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}