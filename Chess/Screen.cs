using folderboard;
using folderchess;
using System;

namespace Chess
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPart(board.part(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
        }

        public static void printBoard(Board board, bool[,] possiblesPositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alterBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblesPositions[i, j])
                    {
                        Console.BackgroundColor = alterBackground;
                    }

                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    printPart(board.part(i, j));
                    Console.BackgroundColor = originalBackground;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
            Console.BackgroundColor = originalBackground;
        }

        public static void printPart(Part part)
        {
            if (part == null)
            {
                Console.Write("-- ");
            }

            else
            {

                if (part.color == Color.White)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(part);
                    Console.ForegroundColor = aux;

                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(part);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }


        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
