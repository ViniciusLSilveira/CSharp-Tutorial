using board;

namespace chess
{
    class King : Piece
    {

        public King(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            for (int i = -1; i <= 1 ; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    pos.SetValues(position.row + i, position.column + j);

                    if(board.ValidPosition(pos) && CanMove(pos))
                    {
                        mat[pos.row, pos.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
