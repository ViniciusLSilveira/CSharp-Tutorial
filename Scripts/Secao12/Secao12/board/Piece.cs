namespace board
{
    abstract class Piece
    {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;

            Moves = 0;
        }

        protected bool CanMove(Position pos)
        {
            Piece p = Board.getPiece(pos);

            return p == null || p.Color != Color;
        }

        public void IncrementMoves()
        {
            Moves++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
