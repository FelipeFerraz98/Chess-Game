using folderboard;
using folderchess;
using System.Xml;

namespace Chess
{

    class Program
    {
        private static void Main(string[] args)
        {

            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.finish)
                {

                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.Write("Enther the origin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possiblesPositions = match.board.part(origin).possiblesMoviments();

                    

                    Console.Clear();
                    Screen.printBoard(match.board, possiblesPositions);

                    Console.Write("Enter the destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMovement(origin, destiny);
                }
            }

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}