using System;
using System.Collections.Generic;
using board;
using chess;

namespace Secao12
{
    class Display
    {

        private static ConsoleColor originalForeground = ConsoleColor.Gray;
        private static ConsoleColor originalBackground = ConsoleColor.Black;
        private static ConsoleColor whiteBackground = ConsoleColor.DarkGray;
        private static ConsoleColor blackBackground = ConsoleColor.Black;
        private static ConsoleColor whiteForeground = ConsoleColor.Cyan;
        private static ConsoleColor blackForeground = ConsoleColor.Yellow;
        private static ConsoleColor possibleMovesBackground = ConsoleColor.DarkGreen;

        public static void PrintGame(ChessGame game)
        {
            PrintBoard(game.board);

            Console.WriteLine();
            PrintCapturedPieces(game);

            Console.ForegroundColor = originalForeground;
            Console.WriteLine("\nMove: " + game.move);
            if (!game.finished)
            {
                Console.WriteLine("Waiting for: " + game.currentPlayer);

                if (game.check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + game.currentPlayer);
            }

        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured pieces: ");

            Console.ForegroundColor = whiteForeground;
            Console.Write("White: ");
            PrintHashSet(game.getCapturedPieces(Color.White));

            Console.ForegroundColor = blackForeground;
            Console.Write("Black: ");
            PrintHashSet(game.getCapturedPieces(Color.Black));

            Console.ForegroundColor = originalForeground;
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
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                    {
                        Console.BackgroundColor = whiteBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = blackBackground;
                    }
                    PrintPiece(board.getPiece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = originalBackground;
                Console.ForegroundColor = originalForeground;
            }
            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                    {
                        Console.BackgroundColor = whiteBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = blackBackground;
                    }
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = possibleMovesBackground;
                    }
                    PrintPiece(board.getPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                    Console.ForegroundColor = originalForeground;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;
            Console.WriteLine("  a b c d e f g h");
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
                    Console.ForegroundColor = whiteForeground;
                    Console.Write(piece);
                }
                else if (piece.color == Color.Black)
                {
                    Console.ForegroundColor = blackForeground;
                    Console.Write(piece);
                }
                Console.Write(" ");
            }
            Console.ForegroundColor = originalForeground;
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
