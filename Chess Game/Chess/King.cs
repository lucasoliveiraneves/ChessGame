using board;


namespace Chess
{
    class King :Piece
    {
        public King (Board board , Collor collor ) : base(collor, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
