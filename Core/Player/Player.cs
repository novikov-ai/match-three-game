using CLI;

namespace Core
{
    /// <summary>
    /// Модель игрока
    /// </summary>
    public class Player : Any
    {
        private IShifter _shifter;
        private Board _board;

        public Player(IShifter shifter, Board board)
        {
            _shifter = shifter;
            _board = board;
        }

        /// <summary>
        /// Реализует логику по совершению хода игроком
        /// </summary>
        /// <precondition>Существуют возможные ходы</precondition>
        /// <postcondition>Сматченные элементы удалены, уровень заполнился новыми</postcondtion>
        public void Move(Tile[,] tiles, Position startPosition, ConsoleKey direction)
        {
            var endPosition = Coordinator.ShiftedPosition(startPosition, direction);

            var rollback = _shifter.Shift(tiles, startPosition, endPosition);
            if (!rollback.Available())
                return;

            var matchedTiles = _board.FindSets();
            if (matchedTiles.Count > 0)
            {
                foreach (var combo in matchedTiles)
                {
                    foreach (var tile in combo.GetTiles())
                    {
                        tiles[tile.Item2.Y, tile.Item2.X] = new Tile("✨");
                        IncrementScore(10);
                    }
                }

                IncrementMoves();
            }
            else
            {
                var (beforeShiftingStart, beforeShiftingEnd) = rollback.Back();

                tiles[startPosition.Y, startPosition.X] = beforeShiftingStart;
                tiles[endPosition.Y, endPosition.X] = beforeShiftingEnd;
            }
        }

        public int Score { get; set; }
        public int Moves { get; set; }

        private void IncrementScore(int points)
        {
            Score += points;
        }

        private void IncrementMoves()
        {
            Moves++;
        }
    }
}