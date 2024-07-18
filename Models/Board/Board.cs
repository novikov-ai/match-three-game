namespace Models
{
    /// <summary>
    /// Игровая дока с фиксированным размером N x M 
    /// </summary>
    public class Board : Any
    {
        private Tile[,] tiles;
        private Random random = new Random();
        private const int size = 8;
        private readonly char[] tileTypes = { 'A', 'B', 'C', 'D', 'E' };

        public Board()
        {
            tiles = new Tile[size, size];
            GenerateNewBoard();
        }

        private void GenerateNewBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = new Tile(tileTypes[random.Next(tileTypes.Length)]);
                }
            }
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  A B C D E F G H");
            System.Console.WriteLine("  " + new string('-', 15));
            for (int i = 0; i < size; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write((i + 1) + "|");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < size; j++)
                {
                    Console.Write(tiles[i, j].Type + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < size && y >= 0 && y < size;
        }

        public bool SwapTiles((int, int) pos1, (int, int) pos2)
        {
            if (IsValidPosition(pos1.Item1, pos1.Item2) && IsValidPosition(pos2.Item1, pos2.Item2))
            {
                // Swap the tiles
                var temp = tiles[pos1.Item1, pos1.Item2];
                tiles[pos1.Item1, pos1.Item2] = tiles[pos2.Item1, pos2.Item2];
                tiles[pos2.Item1, pos2.Item2] = temp;

                // Check for matches
                if (CheckForMatches())
                {
                    RemoveMatches();
                    DropTiles();
                    return true;
                }
                else
                {
                    // Swap back if no match found
                    temp = tiles[pos1.Item1, pos1.Item2];
                    tiles[pos1.Item1, pos1.Item2] = tiles[pos2.Item1, pos2.Item2];
                    tiles[pos2.Item1, pos2.Item2] = temp;
                }
            }
            return false;
        }

        private bool CheckForMatches()
        {
            // Simplified match checking for MVP (to be expanded)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 2; j++)
                {
                    if (tiles[i, j].Type == tiles[i, j + 1].Type && tiles[i, j + 1].Type == tiles[i, j + 2].Type)
                        return true;
                }
            }

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size - 2; i++)
                {
                    if (tiles[i, j].Type == tiles[i + 1, j].Type && tiles[i + 1, j].Type == tiles[i + 2, j].Type)
                        return true;
                }
            }

            return false;
        }

        private void RemoveMatches()
        {
            // Simplified match removal for MVP (to be expanded)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 2; j++)
                {
                    if (tiles[i, j].Type == tiles[i, j + 1].Type && tiles[i, j + 1].Type == tiles[i, j + 2].Type)
                    {
                        tiles[i, j] = null;
                        tiles[i, j + 1] = null;
                        tiles[i, j + 2] = null;
                    }
                }
            }

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size - 2; i++)
                {
                    if (tiles[i, j].Type == tiles[i + 1, j].Type && tiles[i + 1, j].Type == tiles[i + 2, j].Type)
                    {
                        tiles[i, j] = null;
                        tiles[i + 1, j] = null;
                        tiles[i + 2, j] = null;
                    }
                }
            }
        }

        private void DropTiles()
        {
            for (int j = 0; j < size; j++)
            {
                int emptyCount = 0;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (tiles[i, j] == null)
                    {
                        emptyCount++;
                    }
                    else if (emptyCount > 0)
                    {
                        tiles[i + emptyCount, j] = tiles[i, j];
                        tiles[i, j] = null;
                    }
                }

                for (int i = 0; i < emptyCount; i++)
                {
                    tiles[i, j] = new Tile(tileTypes[random.Next(tileTypes.Length)]);
                }
            }
        }

        public bool IsMoveAvailable()
        {
            // Simplified check for available moves for MVP (to be expanded)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (SwapTiles((i, j), (i, j + 1)) || SwapTiles((i, j + 1), (i, j)))
                        return true;
                }
            }

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    if (SwapTiles((i, j), (i + 1, j)) || SwapTiles((i + 1, j), (i, j)))
                        return true;
                }
            }

            return false;
        }

    }
}