using CLI;

namespace Core
{
    public interface IShifter
    {
        public Rollback Shift(Tile[,] tiles, Position start, Position end);
    }

    public class TilesShifter : Any, IShifter
    {
        private readonly Board _board;
        public TilesShifter(Board board)
        {
            _board = board;
        }

        /// <summary>
        /// Команда сдвигающая элементы поля
        /// </summary>
        /// <precondition>Игрок сделал разрешенный ход</precondition>
        /// <postcondition>Если элементы сдвинулись в ряд (сматчились), то меняем их расположение</postcondtion>
        public Rollback Shift(Tile[,] tiles, Position start, Position end)
        {
            if (!IsValidPosition(start) || !IsValidPosition(end))
                return new Rollback();

            var beforeShiftingStart = tiles[start.Y, start.X];
            var beforeShiftingEnd = tiles[end.Y, end.X];

            tiles[start.Y, start.X] = beforeShiftingEnd;
            tiles[end.Y, end.X] = beforeShiftingStart;

            return new Rollback(beforeShiftingStart, beforeShiftingEnd);
        }

        private bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < _board.Size() && position.Y >= 0 && position.Y < _board.Size();
        }
    }
}