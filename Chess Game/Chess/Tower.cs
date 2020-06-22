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
    }
}
