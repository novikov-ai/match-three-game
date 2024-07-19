namespace Core
{
    public static class TileFactory
    {
        /// <summary>
        /// Создает новый объект Tile
        /// </summary>
        /// <returns>Новый объект Tile</returns>
        public static Tile CreateTile(char value)
        {
            return new Tile(value);
        }
    }
}
