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
    }
}