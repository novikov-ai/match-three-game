using CLI;

namespace Core
{
    public class Tile : Any, IEquatable<Tile>
    {
        /// <summary>
        /// Компонент игровой доски
        /// </summary>

        public string Type { get; set; }
        // public Position Position { get; set; }
        public Tile(string type)
        {
            Type = type;
        }

        public bool Equals(Tile other)
        {
            if (other == null)
                return false;

            return this.Type == other.Type;
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