using CLI;

namespace Core
{
    /// <summary>
    /// Реализует логику хода игрока
    /// </summary>
    public class Move : Any
    {
        public readonly Position Position;
        public readonly Arrow Direction;

        public Move(Position position, Arrow direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}