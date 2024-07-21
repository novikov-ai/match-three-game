using CLI;

namespace Core.Game
{
    /// <summary>
    /// Реализует логику наблюдение за игрой
    /// </summary>
    public abstract class Watcher : Any
    {
        /// <summary>
        /// Запрос - проверка возможности совершить ход
        /// </summary>
        /// <precondition>Игра началась и еще не завершена</precondition>
        public abstract bool MovesExist();

        /// <summary>
        /// Поиск 3-х в ряд и более элементов
        /// </summary>
        /// <postcondition>Найдено первое комбо в игре из всех смежных элементов</postcondition>
        public abstract List<TileSet> FindSets(Tile[,] tiles);
    }

    public class GameWatcher : Watcher
    {
        public override bool MovesExist() { return true; }
        public override List<TileSet> FindSets(Tile[,] tiles)
        {
            var matchedSets = new List<TileSet>();

            var horiz = FindSets(tiles, true);
            var vert = FindSets(tiles, false);

            matchedSets.AddRange(horiz);
            matchedSets.AddRange(vert);

            return matchedSets;
        }

        private List<TileSet> FindSets(Tile[,] tiles, bool horizontal)
        {
            var matchedSets = new List<TileSet>();

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                var matchedTiles = new List<(Tile, Position)>();
                for (int j = 0; j < tiles.GetLength(0); j++)
                {
                    Tile currentTile;
                    if (horizontal)
                        currentTile = tiles[i, j];
                    else
                        currentTile = tiles[j, i];

                    if (matchedTiles.Count == 0)
                    {
                        matchedTiles.Add((currentTile, new Position(j, i)));
                        continue;
                    }

                    if (matchedTiles.Last().Item1.Equals(currentTile))
                    // matchedTiles.Count > 2 && TilesMatcher.IsAdjacent(matchedTiles, currentTile))
                    {
                        matchedTiles.Add((currentTile, new Position(j, i)));
                        continue;
                    }

                    if (matchedTiles.Count >= 3)
                        matchedSets.Add(new TileSet(matchedTiles.ToArray()));

                    matchedTiles.Clear();
                    matchedTiles.Add((currentTile,new Position(j, i)));
                }

                if (matchedTiles.Count >= 3)
                    matchedSets.Add(new TileSet(matchedTiles.ToArray()));
            }

            return matchedSets;
        }
    }
}