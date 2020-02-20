namespace board
{
    class Board
    {

        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            pieces = new Piece[Rows, Columns];
        }

        public Piece getPiece(int rows, int columns)
        {
            return pieces[rows, columns];
        }

        public Piece getPiece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return getPiece(pos) != null;
        }

        public void setPiece(Piece p, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new BoardException("There's already a piece in this position");
            }
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public Piece removePiece(Position pos)
        {

            if(getPiece(pos) == null)
            {
                return null;
            }
            Piece aux = getPiece(pos);
            aux.Position = null;

            pieces[pos.Row, pos.Column] = null;

            return aux;

        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position");
            }
        } 
    }
}
