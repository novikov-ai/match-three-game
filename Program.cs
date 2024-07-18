using System;
using System.Drawing;
using Models;
using CliManager;

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
                    // Console.ReadLine();
                    // Parse input and process arrow keys
                    var parsedPosition = CliManager.Parser.ParsePosition(input);
                    //     input = Console.ReadLine();
                    // }
                    // todo: validation

                    if (parsedPosition.IsDefault())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine($@"{DateTime.Now}: {input}
Invalid format. Use format like 'A1'

");
                        continue;
                    }

                    Console.WriteLine("PARSED: ", parsedPosition.Column, parsedPosition.Row);

                    var arrowKey = Console.ReadKey(true).Key; // Read the actual arrow key
                    // var arrowKey = Console.ReadKey().Key; // Read the actual arrow key
                    switch (arrowKey)
                    {
                        case ConsoleKey.UpArrow:
                            // Handle up arrow key
                            break;
                        case ConsoleKey.DownArrow:
                            // Handle down arrow key
                            break;
                        case ConsoleKey.LeftArrow:
                            // Handle left arrow key
                            break;
                        case ConsoleKey.RightArrow:
                            // Handle right arrow key
                            break;
                        default:
                            // Handle other keys if needed
                            break;
                    }

                    // WORKS, BUT VS CODE DEBUG NOT
                    System.Console.WriteLine(arrowKey + "!!!!!");

                    // ConsoleKeyInfo keyInfo; // Remove initialization, as it will be assigned inside the loop
                    // do
                    // {
                    //     keyInfo = Console.ReadKey(true); // Capture key press
                    // } while (keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow &&
                    //          keyInfo.Key != ConsoleKey.LeftArrow && keyInfo.Key != ConsoleKey.RightArrow);
                    // // Perform tile swap based on arrow keys
                    // int dx = 0, dy = 0;
                    // switch (keyInfo.Key)
                    // {
                    //     case ConsoleKey.UpArrow:
                    //         dx = -1;
                    //         break;
                    //     case ConsoleKey.DownArrow:
                    //         dx = 1;
                    //         break;
                    //     case ConsoleKey.LeftArrow:
                    //         dy = -1;
                    //         break;
                    //     case ConsoleKey.RightArrow:
                    //         dy = 1;
                    //         break;
                    // }

                    // Perform the swap and check for matches
                    // if (board.SwapTiles(position.Item1, position.Item2, dx, dy))
                    // {
                    //     player.IncrementMoves();
                    //     player.IncrementScore(10); // Simplified scoring for MVP
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Invalid move. Try again.");
                    // }

                    // Check for available moves
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