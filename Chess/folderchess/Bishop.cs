using folderboard;

namespace folderchess
{
    class Bishop : Part
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Bi";
        }

        private bool canMove(Position pos)
        {
            Part p = board.part(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possiblesMoviments()
        {
            bool[,] matrix = new bool[board.rows,board.columns];
            
            Position pos = new Position(0,0);

            //NO
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column - 1);
            }

            //NE
            pos.defineValues(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column + 1);
            }

            //SO
            pos.defineValues(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column - 1);
            }

            //SE
            pos.defineValues(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column + 1);
            }
            
            return matrix;
        }
    }
}
