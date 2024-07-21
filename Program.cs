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
            var board = new Board(new TileFactory(), new Core.Game.GameWatcher());
            var player = new Player(new TilesShifter(board), board);
            var dashboard = new Statistics(player, new SimpleDisplay());

            bool running = true;

            while (running)
            {
                board.Display();
                dashboard.Display();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Enter move (e.g., A1) or use arrow keys to swap tiles. Commands: -p (pause), -q (quit), -r (restart)");
                Console.ForegroundColor = ConsoleColor.Green;

                var input = Console.ReadLine();

                switch (input)
                {
                    case "-p":
                        {
                            Console.WriteLine("Game paused. Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case "-q":
                        {
                            running = false;
                            Console.WriteLine("Game over.");
                            break;
                        }
                    case "-r":
                        {
                            board = new Board(new TileFactory(), new Core.Game.GameWatcher());
                            player = new Player(new TilesShifter(board), board);
                            dashboard = new Statistics(player, new SimpleDisplay());
                            break;
                        }
                    default:
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

                            var arrowKey = Console.ReadKey(true).Key;

                            player.Move(board.Tiles, parsedPosition, arrowKey);
                            break;
                        }
                }
            }
        }
    }
}