namespace CLI
{
    /// <summary>
    /// Функция для парсинга ввода пользователя, например, "A1" в (0, 0)
    /// </summary>
    public static class Parser
    {
        public static Position ParsePosition(string input)
        {
            if (input.Length != 2)
            {
                return new Position();
            }


            char column = Char.ToUpper(input[0]);
            int row = 0;

            var parsed = Int32.TryParse(input[1].ToString(), out row);
            if (!parsed)
            {
                return new Position();
            }

            // В консоли у нас шкала начинается с 1
            row -= 1;

            if (column < 'A' || column > 'H' || row < 0 || row >= 8)
            {
                return new Position();
            }

            var position = new Position();
            position.X = column - 'A';
            position.Y = row;

            return position;
        }
    }

    public class Position
    {
        public Position()
        {
        }
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
            _default = false;
        }
        private int _x;
        private int _y;
        public int Y
        {
            get => _y;

            set
            {
                _default = false;
                _y = value;
            }
        }
        public int X
        {
            get => _x;

            set
            {
                _default = false;
                _x = value;
            }
        }

        private bool _default = true;

        public bool IsDefault()
        {
            return _default;
        }
    }
}
