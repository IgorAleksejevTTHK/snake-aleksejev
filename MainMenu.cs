using System;

namespace Snake
{
    public static class MainMenu
    {
        public static void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("███████╗███╗   ██╗ █████╗ ██╗  ██╗███████╗");
                Console.WriteLine("██╔════╝████╗  ██║██╔══██╗██║ ██╔╝██╔════╝");
                Console.WriteLine("███████╗██╔██╗ ██║███████║█████╔╝ █████╗  ");
                Console.WriteLine("╚════██║██║╚██╗██║██╔══██║██╔═██╗ ██╔══╝  ");
                Console.WriteLine("███████║██║ ╚████║██║  ██║██║  ██╗███████╗");
                Console.WriteLine("╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝");

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("1. Alusta");
                Console.WriteLine("2. Näita tulemusi");
                Console.WriteLine("3. Välja");
                Console.ResetColor();

                Console.Write("\nValige: ");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        Program.StartGame(); // Вызов метода из Program.cs
                        break;
                    case ConsoleKey.D2:
                        PlayerResult.DisplayResults();
                        break;
                    case ConsoleKey.D3:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
