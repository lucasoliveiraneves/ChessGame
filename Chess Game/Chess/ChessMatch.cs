

using board;

namespace Chess
{
    class ChessMatch
    {
        public Board tab { get; private set;}
        private int turn;
        private Collor currentPlayer;
        public bool Finish { get; set; }
        public ChessMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            currentPlayer = Collor.White;
            Finish = false;
            addPieces();

        }

        public void addPieces()
        {
           
            
            tab.addPieces(new Tower(tab, Collor.White), new ChessPosition('c', 1).toPosition());
            tab.addPieces(new Tower(tab, Collor.White), new ChessPosition('c', 2).toPosition());
            tab.addPieces(new Tower(tab, Collor.White), new ChessPosition('d', 2).toPosition());
            tab.addPieces(new Tower(tab, Collor.White), new ChessPosition('e', 2).toPosition());
            tab.addPieces(new Tower(tab, Collor.White), new ChessPosition('e', 1).toPosition());
            tab.addPieces(new King(tab, Collor.White), new ChessPosition('d', 1).toPosition());
            
            tab.addPieces(new Tower(tab, Collor.Black), new ChessPosition('c', 7).toPosition());
            tab.addPieces(new Tower(tab, Collor.Black), new ChessPosition('c', 8).toPosition());
            tab.addPieces(new Tower(tab, Collor.Black), new ChessPosition('d', 7).toPosition());
            tab.addPieces(new Tower(tab, Collor.Black), new ChessPosition('e', 7).toPosition());
            tab.addPieces(new Tower(tab, Collor.Black), new ChessPosition('e', 8).toPosition());
            tab.addPieces(new King(tab, Collor.Black), new ChessPosition('d', 8).toPosition());
        }
        public void exMovi(Position orig, Position destinity)
        {
            Piece p = tab.removePiece(orig);
            p.incrementAmountMov();
            Piece pieceCaptured = tab.removePiece(destinity);
            tab.addPieces(p, destinity);

            
        }
    }
}
