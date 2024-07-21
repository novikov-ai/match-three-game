using CLI;

namespace Core
{

    public class TileSet
    {
        private readonly List<(Tile, Position)> _set;
        public TileSet((Tile, Position)[] tiles)
        {
            _set = new List<(Tile, Position)>(tiles);
        }
        public bool Exists()
        {
            return _set.Count > 3;
        }
        public string TileType() => _set.First().Item1.Type;

        public List<(Tile, Position)> GetTiles() => _set;
    }
}