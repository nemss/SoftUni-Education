using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int x = 20;
            int y = 10;
            int directionX = 0;
            int directionY = 1;
            char snakeHead = '@';
            char snakeBody = '*';
            char food = '#';

            int foodX = random.Next(0, Console.WindowWidth);
            int foodY = random.Next(0, Console.WindowHeight);

            List<int> snakeX = new List<int>();
            List<int> snakeY = new List<int>();

            int snakeBodyCount = 5;

            var snakeColor = ConsoleColor.Green;
            var foodColor = ConsoleColor.Red;

            for (int i = 0; i < snakeBodyCount; i++)
            {
                x += directionX;
                y += directionY;

                snakeX.Add(x);
                snakeY.Add(y);
                             
            }

            while (true)
            {
                Console.ForegroundColor = snakeColor;
                for (int i = 0; i < snakeX.Count; i++)
                {
                    char element = snakeBody;
                    if (i < snakeX.Count - 1)
                    {
                        snakeX[i] = snakeX[i + 1];
                        snakeY[i] = snakeY[i + 1]; 
                    }
                    else
                    {
                        // check if left or right wall hit
                        if (snakeX[i] + directionX > Console.WindowWidth -1)
                        {
                            snakeX[i] = 0;
                        }
                        if (snakeX[i] + directionX < 0)
                        {
                            snakeX[i] = Console.WindowWidth - 1;
                        }

                        // check if up or down wall hit
                        if (snakeY[i] + directionY > Console.WindowHeight - 1)
                        {
                            snakeY[i] = 0;
                        }
                        if (snakeY[i] + directionY < 0)
                        {
                            snakeY[i] = Console.WindowHeight - 1;
                        }

                        snakeX[i] += directionX;
                        snakeY[i] += directionY;
                        bool isCurrentlyEaten = false;

                        if (snakeX[i] == foodX && snakeY[i] == foodY)
                        {
                            foodX = random.Next(0, Console.WindowWidth);
                            foodY = random.Next(0, Console.WindowHeight);
                            snakeX.Add(snakeX[i]);
                            snakeY.Add(snakeY[i]);
                            isCurrentlyEaten = true;
                        }

                        //check if on eaten myself
                        for (int j = 0; j < snakeX.Count - 1; j++)
                        {
                            if (snakeX[i] == snakeX[j] &&
                                snakeY[i] == snakeY[j] && !isCurrentlyEaten)
                            {
                                Console.Clear();
                                Console.WriteLine("Dead");
                                return;
                            }
                        }

                        element = snakeHead;
                    }

                    Console.SetCursorPosition(snakeX[i], snakeY[i]);
                    Console.Write(element);
                }

                Console.ForegroundColor = foodColor;
                Console.SetCursorPosition(foodX, foodY);
                Console.Write(food);

                //Collision checking

                // Change
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        if (directionX != 1)
                        {
                            directionX = -1;
                            directionY = 0;
                        }
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (directionX != -1)
                        {
                            directionX = 1;
                            directionY = 0;
                        }
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (directionY != -1)
                        {
                            directionY = 1;
                            directionX = 0;
                        }

                    }

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (directionY != 1)
                        {
                            directionX = 0;
                            directionY = -1; 
                        }
                    }
                }
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
