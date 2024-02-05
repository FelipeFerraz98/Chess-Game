using folderboard;

namespace folderchess
{
    class Knight : Part
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Kn";
        }

        private bool canMove(Position pos)
        {
            Part p = board.part(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possiblesMoviments()
        {
            bool[,] matrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.defineValues(position.row - 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) 
            {
                matrix[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, pos.column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            return matrix;
        }
    }
}
