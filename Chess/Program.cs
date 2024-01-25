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
                board.placePart(new Rook(board, Color.Black), new Position(0, 0));
                board.placePart(new Rook(board, Color.Black), new Position(9, 0));



                Screen.printBoard(board);
            }

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}