using System;

namespace folderboard
{
    abstract class Part
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int quantityMoves { get; protected set; }
        public Board board { get; protected set; }

        public Part(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.quantityMoves = 0;
            this.board = board;
        }

        public void increaseMoviment()
        {
            quantityMoves++;
        }

        public bool thereArePossibleMovements()
        {
            bool[,] matrix = possiblesMoviments();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possiblesMoviments()[pos.row, pos.column];
        }


        public abstract bool[,] possiblesMoviments();

    }
}
