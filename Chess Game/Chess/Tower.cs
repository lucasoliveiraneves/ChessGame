using board;


namespace Chess
{
    class Tower: Piece
    {
        public Tower(Board board, Collor collor) : base(collor, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }
        private bool canMov(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.collor != collor;
        }
        public override bool[,] possiMov()
        {
            bool[,] mat = new bool[board.lines, board.coluns];

            Position pos = new Position(0, 0);

            //N
            pos.setValues(position.line - 1, position.column);
            while(board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).collor != collor)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //S
            pos.setValues(position.line + 1, position.column);
            while (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).collor != collor)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            //E
            pos.setValues(position.line, position.column +1);
            while (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).collor != collor)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }
            //W
            pos.setValues(position.line, position.column -1);
            while (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).collor != collor)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
