using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // ACIMA
            pos.SetValues(position.row + 1, position.column);
            while(board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.row += 1;
            }

            // ABAIXO
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

            // DIREITA
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

            // ESQUERDA
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
