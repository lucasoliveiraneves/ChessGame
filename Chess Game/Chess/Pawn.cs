using board;
using Chess;

namespace Chess_Game.Chess
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Collor collor, ChessMatch match) : base(collor, board)
        {
            this.match = match;
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
                //  en passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.positionTrue(left) && existsEnemy(left) && board.piece(left) == match.vEnPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.positionTrue(right) && existsEnemy(right) && board.piece(right) == match.vEnPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
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
                //  en passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column + 1);
                    if (board.positionTrue(left) && existsEnemy(left) && board.piece(left) == match.vEnPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column - 1);
                    if (board.positionTrue(right) && existsEnemy(right) && board.piece(right) == match.vEnPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }


            }
            return mat;

        }
    }
}
