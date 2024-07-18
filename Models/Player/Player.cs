namespace Models
{
    /// <summary>
    /// Модель игрока
    /// </summary>
    public class Player : Any
    {
        /// <summary>
        /// Реализует логику по совершению хода игроком
        /// </summary>
        /// <precondition>Существуют возможные ходы</precondition>
        /// <postcondition>Сматченные элементы удалены, уровень заполнился новыми</postcondtion>
        public void Move(Move move)
        {
            // todo: implement here
        }

        public int Score { get; set; }
        public int Moves { get; set; }

        public void IncrementScore(int points)
        {
            Score += points;
        }

        public void IncrementMoves()
        {
            Moves++;
        }
    }
}