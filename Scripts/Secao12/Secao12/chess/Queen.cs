using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column - 1);
            }

            // NORTH
            pos.SetValues(position.row + 1, position.column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.row += 1;
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

            // EAST
            pos.SetValues(position.row, position.column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column += 1;
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

            // SOUTH
            pos.SetValues(position.row - 1, position.column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.row -= 1;
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

            // WEST
            pos.SetValues(position.row, position.column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column -= 1;
            }

            return mat;
        }

    }
}
