using folderboard;
using folderchess;

namespace Chess
{

    class Program
    {
        private static void Main(string[] args)
        {

            try
            {
                Board board = new Board(8, 8);
                board.placePart(new Rook(board, Color.White), new Position(0, 0));
                board.placePart(new King(board, Color.Black), new Position(0, 1));

                board.placePart(new Rook(board, Color.White), new Position(7, 1));
                board.placePart(new King(board, Color.Black), new Position(7, 0));

                Screen.printBoard(board);
            }

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}