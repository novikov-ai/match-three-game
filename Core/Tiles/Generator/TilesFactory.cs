namespace Core
{
    public class TileFactory
    {
        private Random random = new Random();

        private readonly string[] _tileTypes = { "🍏", "🍎", "🍊","🍌", "🍇", "🍒", "🥝", "🍑" };

        /// <summary>
        /// Создает новый объект Tile
        /// </summary>
        /// <returns>Новый объект Tile</returns>
        public Tile Create()
        {
            return new Tile(_tileTypes[random.Next(_tileTypes.Length)]);
        }
    }
}
