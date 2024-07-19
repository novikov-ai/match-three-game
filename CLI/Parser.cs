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

            if (column < 'A' || column > 'H' || row < 0 || row >= 8)
            {
                return new Position();
            }

            var position = new Position();
            position.Y = column - 'A';
            position.X = row;

            return position;
        }
    }

    public class Position
    {
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
