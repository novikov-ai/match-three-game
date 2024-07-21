namespace Core
{
    public class Rollback
    {
        private Tile beforeShiftingFirst;
        private Tile beforeShiftingSecond;
        public Rollback(Tile first, Tile second)
        {
            beforeShiftingFirst = first;
            beforeShiftingSecond = second;
        }

        public Rollback()
        { }

        public bool Available()
        {
            return beforeShiftingFirst != null && beforeShiftingSecond != null;
        }

        public (Tile, Tile) Back() => (beforeShiftingFirst, beforeShiftingSecond);
    }
}