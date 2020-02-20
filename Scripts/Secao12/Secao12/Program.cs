﻿using System;
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
                    Console.Clear();
                    Display.PrintBoard(game.board);

                    Console.Write("\nOrigin: ");
                    Position origin = Display.ReadChessPosition().toPosition();

                    Console.Write("Destination: ");
                    Position destination = Display.ReadChessPosition().toPosition();

                    game.MakeMove(origin, destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
