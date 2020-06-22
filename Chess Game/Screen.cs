using board;
using System;

namespace Chess_Game
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for ( int i = 0; i < board.lines; i++)
            {
                for(int j = 0; j < board.coluns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }


        }
    }
}
