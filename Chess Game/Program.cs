using board;
using Chess;
using Chess_Game.board;
using System;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch Match = new ChessMatch();

                while (!Match.Finish)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(Match);
                        

                        Console.WriteLine();

                        Console.Write("Origim:");
                        Position orig = Screen.readChessPosition().toPosition();
                        Match.validateOriginPosition(orig);

                        bool[,] possPosition = Match.tab.piece(orig).possiMov();

                        Console.Clear();
                        Screen.printBoard(Match.tab, possPosition);

                        Console.WriteLine();
                        Console.Write("Destinity:");
                        Position dest = Screen.readChessPosition().toPosition();
                        Match.validateDestinityPosition(orig, dest);

                        Match.makeMoves(orig, dest);
                    }
                     catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                

                
               
               
            }
            catch(BoardException e)
            {
                Console.Write(e.Message);
            }
            Console.ReadLine();
        }
    }
}
