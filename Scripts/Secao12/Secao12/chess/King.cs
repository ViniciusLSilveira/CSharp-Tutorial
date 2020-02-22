using board;

namespace chess
{
    class King : Piece
    {
        private ChessGame game;

        public King(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool RookCastleTest(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p != null && p is Rook && p.color == color && p.moves == 0;
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

            // #EspecialPlay - Castle
            if(moves == 0 && !game.check)
            {
                // #EspecialPlay - Castle Kingside
                Position posT1 = new Position(position.row, position.column + 3);
                if(RookCastleTest(posT1)){
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if(board.getPiece(p1) == null && board.getPiece(p2) == null)
                    {
                        mat[position.row, position.column + 2] = true;
                    }
                }
                
                // #EspecialPlay - Castle Queenside
                Position posT2 = new Position(position.row, position.column - 4);
                if(RookCastleTest(posT2)){
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if(board.getPiece(p1) == null && board.getPiece(p2) == null && board.getPiece(p3) == null)
                    {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
