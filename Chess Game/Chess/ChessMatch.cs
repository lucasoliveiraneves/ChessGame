

using board;
using Chess_Game.board;

namespace Chess
{
    class ChessMatch
    {
        public Board tab { get; private set;}
        public int turn { get; private set; }
        public Collor currentPlayer { get; private set; }
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

        public void makeMoves(Position orig,Position destinity)
        {
            exMovi(orig, destinity);
            turn++;
            changePlayer();
        }
       public void validateOriginPosition(Position pos)
        {
            if(tab.piece(pos) == null)
            {
                throw new BoardException("Don't exist piece on origin position!");
            }
            if(currentPlayer != tab.piece(pos).collor)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!tab.piece(pos).existPossMove())
            {
                throw new BoardException("Don't have possible movement!");
            }
        }
        
        
        
        private void changePlayer()
        {
            if(currentPlayer == Collor.White)
            {
                currentPlayer= Collor.Black;
            }
            else
            {
                currentPlayer = Collor.White;
            }
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
