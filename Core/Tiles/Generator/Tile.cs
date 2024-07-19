namespace Core
{
    public class Tile : Any
    {
        /// <summary>
        /// Компонент игровой доски
        /// </summary>

        public char Type { get; set; }

        public Tile(char type)
        {
            Type = type;
        }
    }

    public abstract class Queue : Any
    {
        private readonly List<Tile> _queue;
        public Queue(List<Tile> queue)
        {
            _queue = queue;
        }

        /// <summary>
        /// Команда по вставке элемента в очередь
        /// </summary>
        /// <postcondition>Элемент вставлен в конец очереди</postcondtion>
        public abstract void Enqueue(Tile tile);

        /// <summary>
        /// Команда по извлечению элемента из очереди
        /// </summary>
        /// <precondition>В очереди не менее 1 элемента</precondition>
        /// <postcondition>Из очереди удален первый элемент</postcondtion>
        public abstract Tile Dequeue();

        /// <summary>
        /// Запрос на получение длины очереди
        /// </summary>
        public abstract int Length();
    }
}