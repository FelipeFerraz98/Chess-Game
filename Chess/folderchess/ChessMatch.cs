using System.Collections.Generic;
using folderboard;

namespace folderchess
{
    internal class ChessMatch
    {
        public Board board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finish { get; private set; }
        private HashSet<Part> parts;
        private HashSet<Part> captures;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finish = false;
            parts = new HashSet<Part>();
            captures = new HashSet<Part>();
            placeParts();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Part p = board.removePart(origin);
            p.increaseMoviment();
            Part capturePart = board.removePart(destiny);
            board.placePart(p, destiny);
            if (capturePart != null )
            {
                captures.Add(capturePart);
            }
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

        public HashSet<Part> capturedParts(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part x in captures) {
                if (x.color == color)
                { aux.Add(x); }
            }
            return aux;
        }

        public HashSet<Part> partsInGame(Color color)
        {
            HashSet <Part> aux = new HashSet<Part>();
            foreach (Part x in captures)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedParts(color));
            return aux;
        }

        public void placeNewPart(char column, int row, Part part)
        {
            board.placePart(part, new ChessPosition(column, row).toPosition());
        }

        public void placeParts()
        {

            placeNewPart('a', 1, new Rook(board, Color.White));
            placeNewPart('a', 2, new Rook(board, Color.White));
            placeNewPart('b', 1, new King(board, Color.White));
            placeNewPart('b', 2, new Rook(board, Color.White));
            placeNewPart('c', 1, new Rook(board, Color.White));
            placeNewPart('c', 2, new Rook(board, Color.White));

            placeNewPart('a', 8, new Rook(board, Color.Black));
            placeNewPart('a', 7, new Rook(board, Color.Black));
            placeNewPart('b', 8, new King(board, Color.Black));
            placeNewPart('b', 7, new Rook(board, Color.Black));
            placeNewPart('c', 8, new Rook(board, Color.Black));
            placeNewPart('c', 7, new Rook(board, Color.Black));
        }
    }
}
