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

        private bool canMove(Position pos)
        {
            Part p = board.part(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possiblesMoviments()
        {
            bool[,] matrix = new bool[board.rows, board.columns];
            Position pos = new Position(0,0);

            // Above
            pos.defineValues(position.row - 1, position.column);
            if (board.validPosition(pos) && canMove(pos)) {
                matrix[pos.row, pos.column] = true;
            }

            // Northeast
            pos.defineValues(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            // Right
            pos.defineValues(position.row, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            // Below
            pos.defineValues(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            // South-west
            pos.defineValues(position.row + 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            // Left
            pos.defineValues(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            // Northwest
            pos.defineValues(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
            }

            return matrix;
        }
    }
}
