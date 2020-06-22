

namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int coluns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int colluns)
        {
            this.lines = lines;
            this.coluns = colluns;
            this.pieces = new Piece[lines, colluns];
        }

        public Piece piece(int line,int colun)
        {
            return pieces[line, colun];
        }
        public void addPieces(Piece p , Position pos)
        {
            pieces[pos.line, pos.column] = p;

            p.position = pos;
        }
    }
}
