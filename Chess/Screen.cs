using folderboard;
using System;

namespace Chess
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.part(i, j) == null)
                    {
                        Console.Write("-- ");
                    }
                    else
                    {
                        Console.Write(board.part(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
