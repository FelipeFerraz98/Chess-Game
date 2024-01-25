using System;

namespace folderboard
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public Part[,] parts;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            parts = new Part[rows, columns];
        }

        public Part part(int row, int column)
        {
            return parts[row, column];
        }

        public Part part(Position pos) { 
            return parts[pos.row, pos.column]; 
        }

        public bool thereIsPart(Position pos)
        {
            validatePosition(pos);
            return part(pos) != null;
        }

        public void placePart(Part p, Position pos)
        {
            if (thereIsPart(pos))
            {
                throw new BoardException("There is part in position!");
            }
            parts[pos.row, pos.column] = p;
            p.position = pos;
        }



        public bool validPosition(Position pos)
        {
            if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos) {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }

        }
    }
}
