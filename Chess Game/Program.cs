using board;
using System;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);


            Screen.printBoard(board);
            Console.WriteLine();
        }
    }
}
