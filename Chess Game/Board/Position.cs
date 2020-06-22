
namespace board
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

        public void setValues(int line,int column)
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

