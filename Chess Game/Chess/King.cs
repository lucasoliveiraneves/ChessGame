using board;


namespace Chess
{
    class King : Piece  
    {
        private ChessMatch match;
        public King(Board board, Collor collor, ChessMatch match) : base(collor, board)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }
        private bool canMov(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.collor != collor;
        }
        private bool testTowerRock(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.collor == collor && p.amountOfMov == 0; 
        }
        public override bool[,] possiMov()
        {
            bool[,] mat = new bool[board.lines, board.coluns];

            Position pos = new Position(0, 0);

            //N
            pos.setValues(position.line - 1, position.column);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Ne
            pos.setValues(position.line - 1, position.column + 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //E
            pos.setValues(position.line, position.column + 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //SE
            pos.setValues(position.line + 1, position.column + 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //S
            pos.setValues(position.line + 1, position.column);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //SW
            pos.setValues(position.line + 1, position.column - 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //W
            pos.setValues(position.line, position.column - 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //NW
            pos.setValues(position.line - 1, position.column - 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //
            if(amountOfMov == 0 && !match.check)
            {
                // small rock
                Position posT1 = new Position(position.line, position.column +3);
                if (testTowerRock(posT1))
                {
                    
                    Position p1 = new Position(position.line, position.column +1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if(board.piece(p1)== null && board.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
                // big rock
                Position posT2 = new Position(position.line, position.column -4);
                if (testTowerRock(posT2))
                {

                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3)==null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    
    }
}
