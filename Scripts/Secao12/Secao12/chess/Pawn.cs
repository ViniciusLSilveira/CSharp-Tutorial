using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemies(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return board.getPiece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if(color == Color.White)
            {
                pos.SetValues(position.row - 1, position.column);
                if(board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row - 2, position.column);
                if(board.ValidPosition(pos) && free(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row - 1, position.column - 1);
                if(board.ValidPosition(pos) && HasEnemies(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row - 1, position.column + 1);
                if(board.ValidPosition(pos) && HasEnemies(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            else
            {
                pos.SetValues(position.row + 1, position.column);
                if (board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row + 2, position.column);
                if (board.ValidPosition(pos) && free(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row + 1, position.column - 1);
                if (board.ValidPosition(pos) && HasEnemies(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.SetValues(position.row + 1, position.column + 1);
                if (board.ValidPosition(pos) && HasEnemies(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
        }

    }
}
