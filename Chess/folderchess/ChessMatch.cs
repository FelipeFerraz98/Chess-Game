using System;
using folderboard;

namespace folderchess
{
    internal class ChessMatch
    {
        public Board board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void makePlay(Position origin, Position destiny)
        {
            executeMovement(origin, destiny);
            turn++;
            changePlayer();
        }
        public void vailidateOrigin(Position pos) {
            if(board.part(pos) == null)
            {
                throw new BoardException("There is no part in the choice of origin!");
            }
            if (currentPlayer != board.part(pos).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!board.part(pos).thereArePossibleMovements())
            {
                throw new BoardException("This movement cannot be performed!");
            }
        }

        public void validateDestiny(Position origin, Position destiny)
        {
            if (!board.part(origin).canMoveTo(destiny)){
                throw new BoardException("Destination position invalid!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else{
                currentPlayer = Color.White;
            }
        }

        public void placeParts()
        {
         
            board.placePart(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.placePart(new Rook(board, Color.White), new ChessPosition('a', 2).toPosition());
            board.placePart(new King(board, Color.White), new ChessPosition('b', 1).toPosition());
            board.placePart(new Rook(board, Color.White), new ChessPosition('b', 2).toPosition());
            board.placePart(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePart(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());

            board.placePart(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.placePart(new Rook(board, Color.Black), new ChessPosition('a', 7).toPosition());
            board.placePart(new King(board, Color.Black), new ChessPosition('b', 8).toPosition());
            board.placePart(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePart(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
        }
    }
}
