using board;
using Chess;
using System;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.addPieces(new Tower(board, Collor.Black), new Position(0, 0));
            board.addPieces(new Tower(board, Collor.Black), new Position(1, 3));
            board.addPieces(new King(board, Collor.Black), new Position(2, 4));


            Screen.printBoard(board);
            Console.WriteLine();
        }
    }
}
