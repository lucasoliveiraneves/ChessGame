

using board;
using Chess_Game.board;
using Chess_Game.Chess;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Chess
{
    class ChessMatch
    {
        public Board tab { get; private set;}
        public int turn { get; private set; }
        public Collor currentPlayer { get; private set; }
        public bool Finish { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturated;
        public bool check { get; private set;}
        public ChessMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            currentPlayer = Collor.White;
            Finish = false;
            pieces = new HashSet<Piece>();
            capturated = new HashSet<Piece>();
            check = false;
            addPieces();

        }
        public HashSet<Piece> piecesCaptured(Collor collor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturated)
            {
                if(x.collor == collor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> pieceGame(Collor collor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.collor == collor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(piecesCaptured(collor));
            return aux;
        }
        private Collor opponent(Collor collor)
        {
            if(collor == Collor.White)
            {
                return Collor.Black;
            }
            else
            {
                return Collor.White;
            }
            
        }
        private Piece king(Collor collor)
        {
            foreach (Piece x in pieceGame(collor))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool kingCheck(Collor collor)
        {
            Piece K = king(collor);
            if(K == null)
            {
                throw new BoardException("Dont have King " + collor + " on the board");
            }
            foreach (Piece x in pieceGame(opponent(collor)))
            {
                bool[,] mat = x.possiMov();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheck(Collor collor)
        {
            if (!kingCheck(collor))
            {
                return false;
            }
            foreach (Piece x in pieceGame(collor))
            {
                bool[,] mat = x.possiMov();
                for(int i = 0; i< tab.lines; i++)
                {
                    for(int j = 0; j < tab.coluns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position orig = x.position;
                            Position desti = new Position(i, j);
                            Piece capturedPiece = exMovi(x.position, desti);
                            bool testCheck = kingCheck(collor);
                            cancelMov(orig, desti, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }

        public void addNewPiece(char column, int line , Piece piece)
        {
            tab.addPieces(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        public void addPieces()
        {

            //White
            addNewPiece('a', 1, new Tower(tab, Collor.White));
            addNewPiece('b', 1, new Knight(tab, Collor.White));
            addNewPiece('c', 1, new Bishop(tab, Collor.White));
            addNewPiece('d', 1, new Queen(tab, Collor.White));
            addNewPiece('e', 1, new King(tab, Collor.White));
            addNewPiece('f', 1, new Bishop(tab, Collor.White));
            addNewPiece('g', 1, new Knight(tab, Collor.White));
            addNewPiece('h', 1, new Tower(tab, Collor.White));
            addNewPiece('a', 2, new Pawn(tab, Collor.White));
            addNewPiece('b', 2, new Pawn(tab, Collor.White));
            addNewPiece('c', 2, new Pawn(tab, Collor.White));
            addNewPiece('d', 2, new Pawn(tab, Collor.White));
            addNewPiece('e', 2, new Pawn(tab, Collor.White));
            addNewPiece('f', 2, new Pawn(tab, Collor.White));
            addNewPiece('g', 2, new Pawn(tab, Collor.White));
            addNewPiece('h', 2, new Pawn(tab, Collor.White));
            //Black
            addNewPiece('a', 8, new Tower(tab, Collor.Black));
            addNewPiece('b', 8, new Knight(tab, Collor.Black));
            addNewPiece('c', 8, new Bishop(tab, Collor.Black));
            addNewPiece('d', 8, new Queen(tab, Collor.Black));
            addNewPiece('e', 8, new King(tab, Collor.Black));
            addNewPiece('f', 8, new Bishop(tab, Collor.Black));
            addNewPiece('g', 8, new Knight(tab, Collor.Black));
            addNewPiece('h', 8, new Tower(tab, Collor.Black));
            addNewPiece('a', 7, new Pawn(tab, Collor.Black));
            addNewPiece('b', 7, new Pawn(tab, Collor.Black));
            addNewPiece('c', 7, new Pawn(tab, Collor.Black));
            addNewPiece('d', 7, new Pawn(tab, Collor.Black));
            addNewPiece('e', 7, new Pawn(tab, Collor.Black));
            addNewPiece('f', 7, new Pawn(tab, Collor.Black));
            addNewPiece('g', 7, new Pawn(tab, Collor.Black));
            addNewPiece('h', 7, new Pawn(tab, Collor.Black));


        }
        public Piece exMovi(Position orig, Position destinity)
        {
            Piece p = tab.removePiece(orig);
            p.incrementAmountMov();
            Piece pieceCaptured = tab.removePiece(destinity);
            tab.addPieces(p, destinity);

            if (pieceCaptured != null)
            {
                capturated.Add(pieceCaptured);
            }

            return pieceCaptured;
        }
        public void cancelMov(Position orig, Position destinity , Piece pieceCaptured)
        {
            Piece p = tab.removePiece(destinity);
            p.decrementAmountMov();
            if(pieceCaptured != null)
            {
                tab.addPieces(pieceCaptured, destinity);
                capturated.Remove(pieceCaptured);
            }
            tab.addPieces(p, orig);
        }
        public void makeMoves(Position orig,Position destinity)
        {
            Piece pieceCaptured = exMovi(orig, destinity);
            if (kingCheck(currentPlayer))
            {
                cancelMov(orig, destinity, pieceCaptured);
                throw new BoardException("You can't put the King in check ");
            }
            if (kingCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (testCheck(opponent(currentPlayer)))
            {
                Finish = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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
        public void validateDestinityPosition(Position orig , Position destinity)
        {
            if (!tab.piece(orig).canMoveFor(destinity))
            {
                throw new BoardException(" destination position invalidates!");
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
     
    }
}
