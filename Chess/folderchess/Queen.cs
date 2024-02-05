using folderboard;

namespace folderchess
{
    class Queen : Part
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Qu";
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

            //NO
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
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

            // Above
            pos.defineValues(position.row - 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.row--;
            }

            // Below
            pos.defineValues(position.row + 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.row++;
            }

            // Right
            pos.defineValues(position.row, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.column++;
            }

            // Left
            pos.defineValues(position.row, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.row, pos.column] = true;
                if (board.part(pos) != null && board.part(pos).color != color)
                {
                    break;
                }
                pos.column--;
            }

            return matrix;

        }
    }
}
