namespace Core
{
    public abstract class Shifter : Any
    {
        /// <summary>
        /// Команда сдвигающая элементы поля
        /// </summary>
        /// <precondition>Игрок сделал разрешенный ход</precondition>
        /// <postcondition>Если элементы сдвинулись в ряд (сматчились), то меняем их расположение</postcondtion>
        public abstract void Shift();
    }
}