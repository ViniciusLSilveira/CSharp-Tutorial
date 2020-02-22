using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessGame game;

        public Pawn(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
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

                // #EspecialPlay - EnPassant
                if (position.row == 3 )
                {
                    Position left = new Position(position.row, position.column - 1);
                    if(board.ValidPosition(left) && HasEnemies(left) && board.getPiece(left) == game.vulnerableEnPassant)
                    {
                        mat[left.row - 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.ValidPosition(right) && HasEnemies(right) && board.getPiece(right) == game.vulnerableEnPassant)
                    {
                        mat[right.row - 1, right.column] = true;
                    }
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

                // #EspecialPlay - EnPassant
                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.ValidPosition(left) && HasEnemies(left) && board.getPiece(left) == game.vulnerableEnPassant)
                    {
                        mat[left.row + 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.ValidPosition(right) && HasEnemies(right) && board.getPiece(right) == game.vulnerableEnPassant)
                    {
                        mat[right.row + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }

    }
}
