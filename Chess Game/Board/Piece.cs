
using System.Reflection.Metadata.Ecma335;

namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Collor collor { get; protected set; }
        public int amountOfMov { get; set; }

        public Board board { get; set; }

        public Piece(Position position, Collor collor, Board board)
        {
            this.position = position;
            this.collor = collor;
            this.board = board;
            this.amountOfMov = 0;
        }
    }
}
