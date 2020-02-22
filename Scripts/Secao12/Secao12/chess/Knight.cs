using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.SetValues(position.row - 1, position.column - 2);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row - 2, position.column - 1);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row - 2, position.column + 1);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row - 1, position.column + 2);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row + 1, position.column + 2);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row + 2, position.column + 1);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row + 2, position.column - 1);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            pos.SetValues(position.row + 1, position.column - 2);
            if(board.ValidPosition(pos) && CanMove(pos)){
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
