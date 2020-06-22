

using Chess_Game.board;

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

        public bool existPiece(Position pos)
        {
            valPosition(pos);
            return piece(pos) != null;
        }

        public Piece piece(int line,int colun)
        {
            return pieces[line, colun];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }
        public void addPieces(Piece p , Position pos)
        {
            if (existPiece(pos))
            {
                throw new BoardException("There is already a piece here");
            }
            pieces[pos.line, pos.column] = p;

            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if(piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool positionTrue(Position pos)
        {
            if (pos.line <0 || pos.line >= lines || pos.column <0 || pos.column >= coluns)
            {
                return false;
            }
            return true;
        }

        public void valPosition(Position pos)
        {
            if (!positionTrue(pos))
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
