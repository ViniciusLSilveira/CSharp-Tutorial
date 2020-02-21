using System;
using System.Globalization;
using board;
using chess;

namespace Secao12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame game = new ChessGame();

                while (!game.finished)
                {
                    try
                    {
                        Console.Clear();
                        Display.PrintGame(game);

                        Console.Write("\nOrigin: ");
                        Position origin = Display.ReadChessPosition().toPosition();
                        game.ValidOriginPosition(origin);

                        bool[,] possiblePositions = game.board.getPiece(origin).PossibleMoves();

                        Console.Clear();

                        Display.PrintBoard(game.board, possiblePositions);

                        Console.Write("\nDestination: ");
                        Position destination = Display.ReadChessPosition().toPosition();
                        game.ValidDestinationPosition(origin, destination);

                        game.PlayMove(origin, destination);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
