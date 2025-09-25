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
            Console.Write("Sisesta oma nimi: ");
            string playerName = Console.ReadLine();

            PlayerResult playerResult = new PlayerResult(playerName, score.GetPoints());
            playerResult.Save();

            
            PlayerResult.DisplayResults();

            Console.ReadLine();
        }


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
