using CLI;
using Core.Game;

namespace Core
{
    /// <summary>
    /// Игровая дока с фиксированным размером N x M 
    /// </summary>
    public class Board : Any
    {
        private Tile[,] tiles;
        private readonly TileFactory _tileFactory;
        private const int size = 8;

        public Tile[,] Tiles { get { return tiles; } }

        private GameWatcher _watcher;

        public Board(TileFactory tileFactory, GameWatcher watcher)
        {
            _tileFactory = tileFactory;
            _watcher = watcher;

            GenerateNewBoard();
        }

        public List<TileSet> FindSets()
        {
            return _watcher.FindSets(tiles);
        }

        private void GenerateNewBoard()
        {
            tiles = new Tile[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = _tileFactory.Create();
                }
            }

            bool hasMatch = true;
            do
            {
                var matched = FindSets();
                hasMatch = matched.Count > 0;
                if (hasMatch)
                {
                    foreach (var matchedSet in matched)
                    {
                        foreach (var tile in matchedSet.GetTiles())
                        {
                            tiles[tile.Item2.X, tile.Item2.Y] = _tileFactory.Create();
                        }
                    }
                }
            } while (hasMatch);
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  A B C D E F G H");
            System.Console.WriteLine("  " + new string('=', 16));
            for (int i = size - 1; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write((i + 1) + "|");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < size; j++)
                {
                    Console.Write(tiles[i, j].Type);
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("|" + (i + 1));
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("  " + new string('=', 16));
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        public int Size() => size;
    }
}