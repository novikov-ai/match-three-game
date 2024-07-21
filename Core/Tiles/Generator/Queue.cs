namespace Core
{

    public class TileQueue : Any
    {
        private readonly Any[] _tiles;
        private int _tilesCount = 0;
        public TileQueue(int size)
        {
            _tiles = new Tile[size];
            Clear();
        }

        // постусловие: 
        // если очередь не заполнена, то в нее добавляется новый элемент в конец
        // если очередь заполнена, то новый элемент добавляется в начало, а очередь очищается
        public void Add(Tile tile)
        {
            if (_tilesCount >= _tiles.Length)
                Clear();

            _tiles[_tilesCount] = tile;
            _tilesCount++;
        }

        public bool Get(out Any tile)
        {
            tile = _tiles[_tilesCount - 1];
            if (tile is Tile)
                return true;

            return false;
        }
        public int Capacity() => _tiles.Length;
        public int Size() => _tilesCount;
        public void Clear()
        {
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new None();
            }
            _tilesCount = 0;
        }
    }
}