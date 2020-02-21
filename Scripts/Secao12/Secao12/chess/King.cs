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

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            for (int i = -1; i <= 1 ; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    pos.SetValues(Position.Row + i, Position.Column + j);

                    if(Board.ValidPosition(pos) && CanMove(pos))
                    {
                        mat[pos.Row, pos.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
