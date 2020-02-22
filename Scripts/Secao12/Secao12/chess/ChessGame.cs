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
        public Piece vulnerableEnPassant { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            vulnerableEnPassant = null;

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

            // #EspecialPlay - Castle Kingside
            if(p is King && destination.column == origin.column + 2)
            {
                Position RookOrigin = new Position(origin.row, origin.column + 3);
                Position RookDestination = new Position(origin.row, origin.column + 1);

                Piece R = board.removePiece(RookOrigin);
                R.IncrementMoves();
                board.setPiece(R, RookDestination);
            } 
            
            // #EspecialPlay - Castle Queenside
            if(p is King && destination.column == origin.column - 2)
            {
                Position RookOrigin = new Position(origin.row, origin.column - 4);
                Position RookDestination = new Position(origin.row, origin.column - 1);

                Piece R = board.removePiece(RookOrigin);
                R.IncrementMoves();
                board.setPiece(R, RookDestination);
            }

            // #EspecialPlay - EnPassant
            if (p is Pawn)
            {
                if(origin.column != destination.column && capturedPiece == null)
                {
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(destination.row + 1, destination.column);
                    }
                    else
                    {
                        posP = new Position(destination.row - 1, destination.column);
                    }

                    capturedPiece = board.removePiece(posP);
                    capturedPieces.Add(capturedPiece);
                }
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

            // #EspecialPlay - Castle Kingside
            if (p is King && destination.column == origin.column + 2)
            {
                Position RookOrigin = new Position(origin.row, origin.column + 3);
                Position RookDestination = new Position(origin.row, origin.column + 1);

                Piece R = board.removePiece(RookDestination);
                R.DecrementMoves();
                board.setPiece(R, RookOrigin);
            }          
            
            // #EspecialPlay - Castle Queenside
            if (p is King && destination.column == origin.column - 2)
            {
                Position RookOrigin = new Position(origin.row, origin.column - 4);
                Position RookDestination = new Position(origin.row, origin.column - 1);

                Piece R = board.removePiece(RookDestination);
                R.DecrementMoves();
                board.setPiece(R, RookOrigin);
            }

            // #EspecialPlay - EnPassant
            if(p is Pawn)
            {
                if(origin.column != destination.column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = board.getPiece(destination);
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(3, destination.column);
                    }
                    else
                    {
                        posP = new Position(4, destination.column);
                    }
                    board.setPiece(pawn, posP);
                }
            }

            board.setPiece(p, origin);
        }

        public void PlayMove(Position origin, Position destination)
        {
            Piece capturedPiece = MakeMove(origin, destination);
            Piece p = board.getPiece(destination);

            if (IsOnCheck(currentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself on check");
            }

            // #EspecialPlay - Promotion
            if(p is Pawn)
            {
                if((p.color == Color.White && destination.row == 0) || (p.color == Color.Black && destination.row == 7))
                {
                    p.board.removePiece(destination);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color);
                    board.setPiece(queen, destination);
                    pieces.Add(queen);
                }
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
            else
            {
                move++;
                ChangePlayer();
            }

            // #EspecialPlay - EnPassant
            if(p is Pawn && (destination.row == origin.row - 2 || destination.row == origin.row + 2))
            {
                vulnerableEnPassant = p;
            }
            else
            {
                vulnerableEnPassant = null;
            }

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
            PlaceNewPiece('a', 1, new Rook(board, Color.White));
            PlaceNewPiece('b', 1, new Knight(board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(board, Color.White));
            PlaceNewPiece('d', 1, new Queen(board, Color.White));
            PlaceNewPiece('e', 1, new King(board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(board, Color.White));
            PlaceNewPiece('g', 1, new Knight(board, Color.White));
            PlaceNewPiece('h', 1, new Rook(board, Color.White));
            for (char ch = 'a'; ch <= 'h'; ch++)
            {
                PlaceNewPiece(ch, 2, new Pawn(board, Color.White, this));
            }

            PlaceNewPiece('a', 8, new Rook(board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(board, Color.Black));
            PlaceNewPiece('e', 8, new King(board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(board, Color.Black));
            for (char ch = 'a'; ch <= 'h'; ch++)
            {
                PlaceNewPiece(ch, 7, new Pawn(board, Color.Black, this));
            }
        }
    }
}
