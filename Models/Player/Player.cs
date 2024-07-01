namespace Models.Player
{
    /// <summary>
    /// Модель игрока
    /// </summary>
    public abstract class Player : Any
    {
        /// <summary>
        /// Реализует логику по совершению хода игроком
        /// </summary>
        /// <precondition>Существуют возможные ходы</precondition>
        /// <postcondition>Сматченные элементы удалены, уровень заполнился новыми</postcondtion>
        public abstract void Move(Move move);
    }
}