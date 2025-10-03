using System;
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

            MainMenu.Show();
            Console.CursorVisible = false;
        }

        public static void StartGame()
        {
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '█');
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
                    Thread.Sleep(200);
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
            Console.Clear();
            GameOverScreen.Show();  

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
        }
    }
}
