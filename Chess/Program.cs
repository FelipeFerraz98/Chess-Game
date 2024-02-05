using folderboard;
using folderchess;
using System.Xml;

namespace Chess
{

    class Program
    {
        private static void Main(string[] args)
        {
            ChessMatch match = new ChessMatch();
            while (!match.finish)
            {

                try
                {
                    Console.Clear();
                    Screen.printMatch(match);

                    Console.Write("Enther the origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    match.vailidateOrigin(origin);

                    bool[,] possiblesPositions = match.board.part(origin).possiblesMoviments();



                    Console.Clear();
                    Screen.printBoard(match.board, possiblesPositions);

                    Console.Write("Enter the destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();
                    match.validateDestiny(origin, destiny);

                    match.makePlay(origin, destiny);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }

            }

            Console.Clear();
            Screen.printMatch(match);

        }
    }
}