using board;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chess
{
    class King : Piece  
    {
        public King(Board board, Collor collor) : base(collor, board)
        {
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

            return mat;
        }
    
    }
}
