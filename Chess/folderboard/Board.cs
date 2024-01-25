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
    }
}
