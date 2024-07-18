namespace CliManager
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
            position.Column = column - 'A';
            position.Row = row;

            return position;
        }
    }

    public class Position
    {
        public int Column
        {
            get => this.Column;

            set
            {
                _default = false;
                this.Column = value;
            }
        }
        public int Row
        {
            get => this.Row;

            set
            {
                _default = false;
                this.Row = value;
            }
        }

        private bool _default = true;

        public bool IsDefault()
        {
            return _default;
        }
    }
}
