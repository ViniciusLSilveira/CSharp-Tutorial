using System;
using board;

namespace chess
{
    class ChessGame
    {

        public Board board { get; private set; }
        public int move { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            finished = false;

            PlacePieces();
        }

        public void MakeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.IncrementMoves();

            Piece capturedPiece = board.removePiece(destination);

            board.setPiece(p, destination);
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

        public void PlacePieces()
        {
            board.setPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.setPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.setPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.setPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.setPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.setPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.setPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.setPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.setPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.setPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.setPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.setPiece(new King(board, Color.Black), new ChessPosition('d', 6).toPosition());
        }
    }
}
