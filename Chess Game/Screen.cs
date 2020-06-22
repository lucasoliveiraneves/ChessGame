using board;
using Chess;
using Microsoft.VisualBasic;
using System;

namespace Chess_Game
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.coluns; j++)
                {
                    printPiece(board.piece(i, j));

                }
            
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void printBoard(Board board, bool[,] possPosition)
        {
            ConsoleColor origBackground = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.Yellow;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.coluns; j++)
                {
                    if (possPosition[i, j])
                    {
                        Console.BackgroundColor = changeBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = origBackground;
                    }


                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = origBackground;


                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = origBackground;
        }

            public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }


        public static void printPiece(Piece piece)
        {
            if( piece == null)
            {
                Console.Write("- ");
            }
            else {
                if (piece.collor == Collor.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
             }
        }
    }
}
