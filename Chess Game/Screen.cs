using board;
using Chess;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Chess_Game
{
    class Screen
    {
        public static void printMatch(ChessMatch match)
        {
            printBoard(match.tab);
            Console.WriteLine();
            printPiecesCaptured(match);
            Console.WriteLine();
            Console.WriteLine("Turn:" + match.turn);
            Console.WriteLine();
            if (!match.Finish)
            {
                Console.WriteLine("Waiting for the move:" + " " + match.currentPlayer);
                if (match.check)
                {
                    Console.WriteLine("check!");
                }
            }
            else { 
                Console.WriteLine("Checkmate!");
                Console.WriteLine("The winner :" + match.currentPlayer);
            }
        }
        public static void printPiecesCaptured(ChessMatch match)
        {
            
            Console.WriteLine("Pieces Captured:");
            Console.WriteLine();
            Console.Write("White:");

            ConsoleColor aux1 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.piecesCaptured(Collor.White));
            Console.ForegroundColor = aux1;
            Console.WriteLine();
            Console.Write("Blacks:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            printSet(match.piecesCaptured(Collor.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        } 
        public static void printSet( HashSet<Piece> sets)
        {
            Console.Write(" [");
            foreach (Piece x in sets)
            {
                Console.Write(x + " ");
            }
            Console.Write(" ]");
        }

        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.coluns; j++)
                {
                    PrintPiece(board.piece(i, j));

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


                    PrintPiece(board.piece(i, j));
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


        public static void PrintPiece(Piece piece)
        {
            if( piece == null)
            {
                Console.Write("- ");
            }
            else {
                if (piece.collor == Collor.White)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
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
