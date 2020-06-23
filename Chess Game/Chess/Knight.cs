using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Knight: Piece
    {
        public Knight(Board board, Collor collor) : base(collor, board)
        {
        }
        public override string ToString()
        {
            return "N";
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
           
            //
            pos.setValues(position.line - 1, position.column - 2);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line -2, position.column - 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line - 2, position.column + 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line - 1, position.column +2);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line + 1, position.column +2);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line +2, position.column + 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line +2, position.column - 1);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //
            pos.setValues(position.line + 1, position.column - 2);
            if (board.positionTrue(pos) && canMov(pos))
            {
                mat[pos.line, pos.column] = true;
            }


            return mat;
        }
    }
}
