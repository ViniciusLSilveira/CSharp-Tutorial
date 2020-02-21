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

        public void MakeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.IncrementMoves();

            Piece capturedPiece = board.removePiece(destination);

            board.setPiece(p, destination);

            if(capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
        }

        public void PlayMove(Position origin, Position destination)
        {
            MakeMove(origin, destination);

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

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            board.setPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Rook(board, Color.White));
            PlaceNewPiece('c', 2, new Rook(board, Color.White));
            PlaceNewPiece('d', 2, new Rook(board, Color.White));
            PlaceNewPiece('e', 2, new Rook(board, Color.White));
            PlaceNewPiece('e', 1, new Rook(board, Color.White));
            PlaceNewPiece('d', 1, new King(board, Color.White));

            PlaceNewPiece('c', 8, new Rook(board, Color.Black));
            PlaceNewPiece('c', 7, new Rook(board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(board, Color.Black));
            PlaceNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
