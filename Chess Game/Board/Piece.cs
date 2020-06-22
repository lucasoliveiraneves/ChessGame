
using System.Reflection.Metadata.Ecma335;

namespace board
{
     abstract class Piece
    {
        public Position position { get; set; }
        public Collor collor { get; protected set; }
        public int amountOfMov { get; set; }

        public Board board { get; set; }

        public Piece( Collor collor, Board board)
        {
            this.position = null;
            this.collor = collor;
            this.board = board;
            this.amountOfMov = 0;
        }
        public bool existPossMove()
        {
            bool[,] mat = possiMov();
            for (int i = 0; i < board.lines; i++)
            {
                for(int j=0; j< board.coluns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;   
        }

        public abstract bool[,] possiMov();
        public void incrementAmountMov()
        {
            amountOfMov++;
        }
    }
}
