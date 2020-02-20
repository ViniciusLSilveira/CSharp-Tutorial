using System;
using board;

namespace chess
{
    class ChessGame
    {

        public Board board { get; private set; }
        private int move;
        private Color currentPlayer;
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
            board.setPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
