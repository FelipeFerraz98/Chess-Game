using folderboard;

namespace folderchess
{
    class Pawn : Part
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Pa";
        }

        private bool existEnemy(Position pos)
        {
            Part p = board.part(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return board.part(pos) == null;
        }

        public override bool[,] possiblesMoviments()
        {
            bool[,] matrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.defineValues(position.row - 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 2, position.column);
                if (board.validPosition(pos) && free(pos) && quantityMoves == 0)
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }
            }

            else
            {
                pos.defineValues(position.row + 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 2, position.column);
                if (board.validPosition(pos) && free(pos) && quantityMoves == 0)
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    matrix[pos.row, pos.column] = true;
                }
            }

            return matrix;
        }

    }
}
