using folderboard;

namespace folderchess
{
    class King : Part
    {
        public King(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Ki";
        }
    }
}
