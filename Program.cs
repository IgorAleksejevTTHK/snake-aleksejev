using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program

        


    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(80, 25);

            ShowMainMenu();
        }



        static void ShowMainMenu()
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

                // 🔻 Меню
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
                        StartGame();
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



        static void StartGame()
        {
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '∎');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '€');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Score score = new Score();
            Speed speed = new Speed();
            Level level = new Level();
            AudioManager audioManager = new AudioManager();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    audioManager.PlayGameOverSound();
                    break;
                }

                if (snake.Eat(food))
                {
                    audioManager.PlayEatSound();
                    score.AddPoints(10);

                    if (score.GetPoints() % 50 == 0)
                    {
                        level.IncreaseLevel();
                        speed.IncreaseSpeed();
                    }

                    food = foodCreator.CreateFood();
                    Thread.Sleep(500);//пришлось добавить задержку, потому что еда могла появиться сразу на звейке и съедаться мгновенно, после чего новой еды не появлялось
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                score.Draw();
                level.Draw();

                Thread.Sleep(speed.GetDelay());

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver();
            Console.SetCursorPosition(0, 20);
            string playerName;

            do
            {
                Console.Write(" Sisestage nimi(min 3 tahte): ");
                playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName) || playerName.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nimi on liiga lühike!");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            } while (true);

            PlayerResult playerResult = new PlayerResult(playerName, score.GetPoints());
            playerResult.Save();

            PlayerResult.DisplayResults();

            static void WriteGameOver()
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

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
}
    
