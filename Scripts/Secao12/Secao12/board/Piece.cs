namespace board
{
    abstract class Piece
    {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            position = null;
            this.color = color;
            this.board = board;

            moves = 0;
        }

        protected bool CanMove(Position pos)
        {
            Piece p = board.getPiece(pos);

            return p == null || p.color != color;
        }

        public void IncrementMoves()
        {
            moves++;
        }        

        public void DecrementMoves()
        {
            moves--;
        }

        public bool HasPossibleMoves()
        {
            bool[,] mat = PossibleMoves();

            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.row, pos.column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
