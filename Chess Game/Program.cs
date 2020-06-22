using board;
using Chess;
using Chess_Game.board;
using System;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.addPieces(new Tower(board, Collor.Black), new Position(0, 0));
                board.addPieces(new Tower(board, Collor.Black), new Position(1, 3));
                board.addPieces(new King(board, Collor.Black), new Position(2, 4));

                board.addPieces(new King(board, Collor.White), new Position(3, 5));


                Screen.printBoard(board);
               
            }
            catch(BoardException e)
            {
                Console.Write(e.Message);
            }
            Console.ReadLine();
        }
    }
}
