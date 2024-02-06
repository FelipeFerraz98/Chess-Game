using folderboard;

namespace folderchess
{
    class Pawn : Part
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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
                // #Especial play En Passant
                if (position.row == 3)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && existEnemy(left) && board.part(left) == match.enPassantVulnerable)
                    {
                        matrix[left.row - 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && existEnemy(right) && board.part(right) == match.enPassantVulnerable)
                    {
                        matrix[right.row - 1, right.column] = true;
                    }

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


                // #Especial play En Passant

                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && existEnemy(left) && board.part(left) == match.enPassantVulnerable)
                    {
                        matrix[left.row + 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && existEnemy(right) && board.part(right) == match.enPassantVulnerable)
                    {
                        matrix[right.row + 1, right.column] = true;
                    }

                }


            }

            return matrix;
        }

    }
}
