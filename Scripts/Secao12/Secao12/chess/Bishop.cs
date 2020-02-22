using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // NORTHWEST
            pos.SetValues(position.row - 1, position.column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column - 1);
            }

            // NORTHEAST
            pos.SetValues(position.row - 1, position.column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column + 1);
            }

            // SOUTHEAST
            pos.SetValues(position.row + 1, position.column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column + 1);
            }

            // SOUTHWEST
            pos.SetValues(position.row + 1, position.column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column - 1);
            }


            return mat;
        }

    }
}
