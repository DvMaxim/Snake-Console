using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main( string[] args ) // change colors in program
		{
			while (true)
			{
				int largeHeight = Console.LargestWindowHeight;
				int largeWidth = Console.LargestWindowWidth;
				int mapWidth = largeWidth - 82;
				int mapHeight = largeHeight - 20;

				Console.Title = "Snake";
				Console.BackgroundColor = ConsoleColor.DarkYellow;
				Console.SetWindowSize(largeWidth - 80, largeHeight - 10);
				Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

				int score = 0, snake_lenght = 1;
				Direction start_direction = Direction.RIGHT;

				Walls walls = new Walls(mapWidth, mapHeight);
				walls.Draw();

				// Create and draw snake			
				Point p = new Point(40, 15, '*');
				Snake snake = new Snake(p, snake_lenght, start_direction);
				snake.Draw();

				FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, '$');
				Point food = foodCreator.CreateFood(snake);
				food.drawFood();

				bool one_more_time = false, exit = false ;

				while (!one_more_time)
				{
					showScore(score, mapWidth, mapHeight);
					if (walls.IsHit(snake) || snake.IsHitTail())
					{
						while (true)
						{
							try
							{
								Console.Clear();
								Console.SetCursorPosition(mapWidth / 2, mapHeight / 2 - 3); // move these labes down
								Console.Write("GAME OVER");
								Console.SetCursorPosition(mapWidth / 2 - 2, mapHeight / 2 - 1);
								Console.Write("Final score: " + score);
								Console.SetCursorPosition(mapWidth / 2 - 12, mapHeight / 2 + 1);
								Console.Write("Do you want to play one more time ?");
								Console.SetCursorPosition(mapWidth / 2 - 10, mapHeight / 2 + 3);
								Console.Write("Your choise (1 - yes, 0 - no): ");
								int choise = Convert.ToInt32(Console.ReadLine());
								if (choise == 1)
								{
									one_more_time = true;
									break;
								}
								else if (choise == 0)
								{
									exit = true;
									break;
								}
								else
								{
									throw new Exception();
								}
							}
							catch
							{
								Console.SetCursorPosition(mapWidth / 2 - 9, mapHeight / 2 + 6);
								Console.Write("Oops, something has gone bad.");
								Console.SetCursorPosition(mapWidth / 2 - 20, mapHeight / 2 + 8);
								Console.Write("Please, input only one of the offered INTEGER values.");
								Console.SetCursorPosition(mapWidth / 2 - 10, mapHeight / 2 + 10);
								Console.Write("Click any button to try again...");
								Console.ReadKey();
							};
						}
						if (one_more_time)
                        {
							Console.Clear();
							continue;
						}
                        else
                        {
							break;
                        }
					}
					else if (snake.Eat(food))
					{
						score += 100;
						food = foodCreator.CreateFood(snake);
						food.drawFood();
					}
					else
					{
						snake.Move();
					}

					Thread.Sleep(100);
					if (Console.KeyAvailable)
					{
						ConsoleKeyInfo key = Console.ReadKey();
						snake.HandleKey(key.Key);
					}
					else
					{
						snake.setEqualDirections();
					}
				}
				if (exit)
                {
					return;
                }
			}
        }

		static void showScore(int score, int mapWidth, int mapHeight)
        {
			Console.SetCursorPosition(mapWidth / 2 - 3, mapHeight + 5);
			Console.Write($"Current score: {score}");
		}

	}
}
