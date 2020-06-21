using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int line , int column)
        {
            this.column = column;
            this.line = line;
        }

        public override string ToString()
        {
            return line + "," + column;
        }
    }
}

