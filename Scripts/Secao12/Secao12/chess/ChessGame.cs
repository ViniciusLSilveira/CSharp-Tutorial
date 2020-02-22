using System;
using System.Collections.Generic;
using board;

namespace chess
{
    class ChessGame
    {

        public Board board { get; private set; }
        public int move { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public bool check { get; set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            finished = false;

            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();

            PlacePieces();
        }

        public Piece MakeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.IncrementMoves();

            Piece capturedPiece = board.removePiece(destination);

            board.setPiece(p, destination);

            if(capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        private void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.removePiece(destination);
            p.DecrementMoves();

            if(capturedPiece != null)
            {
                board.setPiece(capturedPiece, destination);
                capturedPieces.Remove(capturedPiece);
            }

            board.setPiece(p, origin);
        }

        public void PlayMove(Position origin, Position destination)
        {
            Piece capturedPiece = MakeMove(origin, destination);

            if (IsOnCheck(currentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself on check");
            }
            if (IsOnCheck(Adversary(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (CheckmateTest(Adversary(currentPlayer)))
            {
                finished = true;
            }

            move++;

            ChangePlayer();
        }

        public void ValidOriginPosition(Position pos)
        {
            if(board.getPiece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen position");
            }
            if(currentPlayer != board.getPiece(pos).color)
            {
                throw new BoardException("The chosen piece is not yours");
            }
            if (!board.getPiece(pos).HasPossibleMoves())
            {
                throw new BoardException("There is no possible moves with the chosen piece");
            }

        }

        public void ValidDestinationPosition(Position origin, Position destination)
        {
            if (!board.getPiece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid Destination Position");
            }
        }

        private void ChangePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> getCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in capturedPieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> getGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(capturedPieces);

            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece x in getGamePieces(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsOnCheck(Color color)
        {
            Piece king = King(color);

            if(king == null)
            {
                throw new BoardException("There's no " + color + " king on board");
            }

            foreach (Piece x in getGamePieces(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if(mat[king.position.row, king.position.column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsOnCheck(color))
            {
                return false;
            }

            foreach (Piece piece in getGamePieces(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if(mat[i, j])
                        {
                            Position origin = piece.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MakeMove(origin, destination);
                            bool checkTest = IsOnCheck(color);
                            UndoMove(origin, destination, capturedPiece);
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


        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            board.setPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Rook(board, Color.White));
            PlaceNewPiece('d', 1, new King(board, Color.White));
            PlaceNewPiece('h', 7, new Rook(board, Color.White));

            PlaceNewPiece('a', 8, new King(board, Color.Black));
            PlaceNewPiece('b', 8, new Rook(board, Color.Black));
        }
    }
}
