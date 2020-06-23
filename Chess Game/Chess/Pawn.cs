using board;


namespace Chess_Game.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Collor collor) : base(collor, board)
        {

        }

        public override string ToString()
        {
            return "P";
        }
        private bool existsEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.collor != collor;
        }
        private bool free(Position pos)
        {
            return board.piece(pos) == null;

        }
      
        public override bool[,] possiMov()
        {
            bool[,] mat = new bool[board.lines, board.coluns];

            Position pos = new Position(0, 0);

            if (collor == Collor.White)
            {
                pos.setValues(position.line - 1, position.column);
                if (board.positionTrue(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 2, position.column);
                if (board.positionTrue(pos) && free(pos) && amountOfMov == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column - 1);
                if (board.positionTrue(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column + 1);
                if (board.positionTrue(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.line + 1, position.column);
                if (board.positionTrue(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 2, position.column);
                if (board.positionTrue(pos) && free(pos) && amountOfMov == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column - 1);
                if (board.positionTrue(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column + 1);
                if (board.positionTrue(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

            }
            return mat;

            }
        }
}
