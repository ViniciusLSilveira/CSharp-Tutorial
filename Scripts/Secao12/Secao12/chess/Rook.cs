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

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // ACIMA
            pos.SetValues(Position.Row + 1, Position.Column);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if(Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row += 1;
            }

            // ABAIXO
            pos.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row -= 1;
            }

            // DIREITA
            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            // ESQUERDA
            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            return mat;
        }

    }
}
