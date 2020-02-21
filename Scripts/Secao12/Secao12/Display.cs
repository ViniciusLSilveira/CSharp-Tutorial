using System;
using System.Collections.Generic;
using board;
using chess;

namespace Secao12
{
    class Display
    {

        public static void PrintGame(ChessGame game)
        {
            PrintBoard(game.board);

            Console.WriteLine();
            PrintCapturedPieces(game);

            Console.WriteLine("\nTurno: " + game.move);
            Console.WriteLine("Waiting for: " + game.currentPlayer);

            if (game.check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintHashSet(game.getCapturedPieces(Color.White));

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Black: ");
            PrintHashSet(game.getCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void PrintHashSet(HashSet<Piece> hashSet)
        {
            Console.Write("[");
            foreach (Piece x in hashSet)
            {
                PrintPiece(x);
                Console.Write(" ");
            }
            Console.WriteLine("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    PrintPiece(board.getPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.getPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else if (piece.color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);

        }
    }
}
