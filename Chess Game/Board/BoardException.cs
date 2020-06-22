using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Game.board
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {
        }
    }
}
