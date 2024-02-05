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
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finish = false;
            check = false;
            parts = new HashSet<Part>();
            captures = new HashSet<Part>();
            placeParts();
        }

        public Part executeMovement(Position origin, Position destiny)
        {
            Part p = board.removePart(origin);
            p.increaseMoviment();
            Part capturedPart = board.removePart(destiny);
            board.placePart(p, destiny);
            if (capturedPart != null)
            {
                captures.Add(capturedPart);
            }

            return capturedPart;
        }

        public void undoMovement(Position origin, Position destiny, Part capturedPart)
        {
            Part p = board.removePart(destiny);
            p.decreaseMoviment();
            if (capturedPart != null)
            {
                board.placePart(capturedPart, destiny);
                captures.Remove(capturedPart);
            }
            board.placePart(p, origin);

        }

        public void makePlay(Position origin, Position destiny)
        {
            Part capturedPart = executeMovement(origin, destiny);

            if (inCheck(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPart);
                throw new BoardException("You can't put yourself in check!");
            }

            if (inCheck(opponent(currentPlayer)))
            {
                check = true;
            }

            else
            {
                check = false;
            }

            if (checkmateTest(currentPlayer))
            {
                finish = true;
            }

            else
            {
                turn++;
                changePlayer();
            }
        }
        public void vailidateOrigin(Position pos)
        {
            if (board.part(pos) == null)
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
            if (!board.part(origin).possibleMoviment(destiny))
            {
                throw new BoardException("Destination position invalid!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Part> capturedParts(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part x in captures)
            {
                if (x.color == color)
                { aux.Add(x); }
            }
            return aux;
        }

        public HashSet<Part> partsInGame(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part x in parts)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedParts(color));
            return aux;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }

            return Color.White;
        }

        private Part king(Color color)
        {
            foreach (Part x in partsInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool inCheck(Color color)
        {
            Part Ki = king(color);
            if (Ki == null)
            {
                throw new BoardException("Don't exist the king of color " + color + " in board!");
            }

            foreach (Part x in partsInGame(opponent(color)))
            {
                bool[,] matrix = x.possiblesMoviments();
                if (matrix[Ki.position.row, Ki.position.column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool checkmateTest(Color color)
        {
            if (!inCheck(color))
            {
                return false;
            }

            foreach (Part x in partsInGame(color))
            {
                bool[,] matrix = x.possiblesMoviments();
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Part capturedPart = executeMovement(origin, destiny);
                            bool checkTest = inCheck(color);
                            undoMovement(origin, destiny, capturedPart);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void placeNewPart(char column, int row, Part part)
        {
            board.placePart(part, new ChessPosition(column, row).toPosition());
            parts.Add(part);
        }

        public void placeParts()
        {
            // White parts
            placeNewPart('a', 2, new Pawn(board, Color.White));
            placeNewPart('b', 2, new Pawn(board, Color.White));
            placeNewPart('c', 2, new Pawn(board, Color.White));
            placeNewPart('d', 2, new Pawn(board, Color.White));
            placeNewPart('e', 2, new Pawn(board, Color.White));
            placeNewPart('f', 2, new Pawn(board, Color.White));
            placeNewPart('g', 2, new Pawn(board, Color.White));
            placeNewPart('h', 2, new Rook(board, Color.White));
            
            placeNewPart('a', 1, new Rook(board, Color.White));
            placeNewPart('b', 1, new Knight(board, Color.White));
            placeNewPart('c', 1, new Bishop(board, Color.White));
            placeNewPart('d', 1, new Queen(board, Color.White));
            placeNewPart('e', 1, new King(board, Color.White));
            placeNewPart('f', 1, new Bishop(board, Color.White));
            placeNewPart('g', 1, new Knight(board, Color.White));
            placeNewPart('h', 1, new Rook(board, Color.White));


            // Black parts
            placeNewPart('a', 7, new Pawn(board, Color.Black));
            placeNewPart('b', 7, new Pawn(board, Color.Black));
            placeNewPart('c', 7, new Pawn(board, Color.Black));
            placeNewPart('d', 7, new Pawn(board, Color.Black));
            placeNewPart('e', 7, new Pawn(board, Color.Black));
            placeNewPart('f', 7, new Pawn(board, Color.Black));
            placeNewPart('g', 7, new Pawn(board, Color.Black));
            placeNewPart('h', 7, new Pawn(board, Color.Black));


            placeNewPart('a', 8, new Rook(board, Color.Black));
            placeNewPart('b', 8, new Knight(board, Color.Black));
            placeNewPart('c', 8, new Bishop(board, Color.Black));
            placeNewPart('d', 8, new Queen(board, Color.Black));
            placeNewPart('e', 8, new Knight(board, Color.Black));
            placeNewPart('f', 8, new Bishop(board, Color.Black));
            placeNewPart('g', 8, new Knight(board, Color.Black));
            placeNewPart('h', 8, new Rook(board, Color.Black));
        }
    }
}
