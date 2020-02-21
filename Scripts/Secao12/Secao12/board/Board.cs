namespace board
{
    class Board
    {

        public int rows { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            pieces = new Piece[this.rows, this.columns];
        }

        public Piece getPiece(int rows, int columns)
        {
            return pieces[rows, columns];
        }

        public Piece getPiece(Position pos)
        {
            return pieces[pos.row, pos.column];
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
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {

            if(getPiece(pos) == null)
            {
                return null;
            }
            Piece aux = getPiece(pos);
            aux.position = null;

            pieces[pos.row, pos.column] = null;

            return aux;

        }

        public bool ValidPosition(Position pos)
        {
            if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns)
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
