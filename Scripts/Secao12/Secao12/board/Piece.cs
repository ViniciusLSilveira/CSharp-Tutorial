namespace board
{
    class Piece
    {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Tabuleiro { get; protected set; }

        public Piece(Board tabuleiro, Color cor)
        {
            Position = null;
            Color = cor;
            Tabuleiro = tabuleiro;

            Moves = 0;
        }

        public void IncrementMoves()
        {
            Moves++;
        }
    }
}
