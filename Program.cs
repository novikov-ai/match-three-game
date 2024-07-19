using System;
using System.Drawing;
using Core;
using CLI;

namespace Match3Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            var board = new Board();
            var dashboard = new Statistics(player, new SimpleDisplay());

            bool running = true;

            while (running)
            {
                // Console.Clear();
                board.Display();
                dashboard.Display();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Enter move (e.g., A1) or use arrow keys to swap tiles. Commands: -p (pause), -q (quit), -r (restart)");
                Console.ForegroundColor = ConsoleColor.Green;

                var input = Console.ReadLine();

                if (input == "-p")
                {
                    Console.WriteLine("Game paused. Press any key to continue...");
                    Console.ReadKey();
                }
                else if (input == "-q")
                {
                    running = false;
                    Console.WriteLine("Game over.");
                }
                else if (input == "-r")
                {
                    board = new Board();
                    player = new Player();
                    dashboard = new Statistics(player, new SimpleDisplay());
                }
                else
                {
                    var parsedPosition = CLI.Parser.ParsePosition(input);

                    if (parsedPosition.IsDefault())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine($@"{DateTime.Now}: {input}
Invalid format. Use format like 'A1'

");
                        continue;
                    }

                    Arrow direction;
                    string directionValue = "not specified";
                    var dx = parsedPosition.X;
                    var dy = parsedPosition.Y;

                    var arrowKey = Console.ReadKey(true).Key;
                    switch (arrowKey)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Arrow.Up;
                            dy += 1;
                            directionValue = "UP";
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Arrow.Down;
                            dy -= 1;
                            directionValue = "DOWN";
                            break;
                        case ConsoleKey.LeftArrow:
                            direction = Arrow.Left;
                            dx -= 1;
                            directionValue = "LEFT";
                            break;
                        case ConsoleKey.RightArrow:
                            direction = Arrow.Right;
                            dx += 1;
                            directionValue = "RIGHT";
                            break;
                        default:
                            // Default behaviour
                            direction = Arrow.Right;
                            dx += 1;
                            directionValue = "RIGHT";
                            break;
                    }

                    var move = new Move(parsedPosition, direction);

                    if (board.SwapTiles((move.Position.X, move.Position.Y), (dx, dy)))
                    {
                        player.IncrementMoves();
                        player.IncrementScore(10); // Simplified scoring for MVP
                    }
                    else
                    {
                         System.Console.WriteLine($@"{DateTime.Now}: {input} + { directionValue}
Invalid move. Try again.");
                        continue;
                    }

                    if (!board.IsMoveAvailable())
                    {
                        Console.WriteLine("No more moves available. Game over.");
                        running = false;
                    }
                }
            }
        }
    }
}