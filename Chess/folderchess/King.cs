using folderboard;

namespace folderchess
{
    class King : Part
    {

        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

        private bool castlingRookTest(Position pos)
        {
            Part p = board.part(pos);
            return p != null && p is Rook && p.color == color && p.quantityMoves == 0;
        }

        public override bool[,] possiblesMoviments()
        {
            bool[,] matrix = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            // Above
            pos.defineValues(position.row - 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
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

            // #Especial play Castling
            if (quantityMoves == 0 && !match.check)
            {
                // #Especial play small Castling
                Position posRook1 = new Position(position.row, position.column + 3);
                if (castlingRookTest(posRook1))
                {
                    Position pos1 = new Position(position.row, position.column + 1);
                    Position pos2 = new Position(position.row, position.column + 2);
                    if (board.part(pos1) == null && board.part(pos2) == null)
                    {
                        matrix[position.row, position.column + 2] = true;
                    }
                }

                // #Especial play big Castling
                Position posRook2 = new Position(position.row, position.column - 4);
                if (castlingRookTest(posRook2))
                {
                    Position pos1 = new Position(position.row, position.column - 1);
                    Position pos2 = new Position(position.row, position.column - 2);
                    Position pos3 = new Position(position.row, position.column - 3);
                    if (board.part(pos1) == null && board.part(pos2) == null && board.part(pos3) == null)
                    {
                        matrix[position.row, position.column - 2] = true;
                    }
                }
            }

            return matrix;
        }
    }
}
