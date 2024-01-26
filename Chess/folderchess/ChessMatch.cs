using System;
using folderboard;

namespace folderchess
{
    internal class ChessMatch
    {
        public Board board { get; set; }
        private int turn;
        private Color currentPlayer;
        public bool finish { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finish = false;
            placeParts();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Part p = board.removePart(origin);
            p.increaseMoviment();
            Part capturePart = board.removePart(destiny);
            board.placePart(p, destiny);
        }

        public void placeParts()
        {
         
            board.placePart(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.placePart(new King(board, Color.Black), new ChessPosition('b', 1).toPosition());

            board.placePart(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.placePart(new King(board, Color.White), new ChessPosition('b', 8).toPosition());
        }
    }
}
