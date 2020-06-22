
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

        public abstract bool[,] possiMov();
        public void incrementAmountMov()
        {
            amountOfMov++;
        }
    }
}
