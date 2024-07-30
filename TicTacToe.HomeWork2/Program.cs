using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.HomeWork2
{
    internal class Program
    {
        static int numberOfMove = 0;

        enum PlayerSymbol { X, O }

        static PlayerSymbol currentPlayer = PlayerSymbol.X;

        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static void Main(string[] args)
        {
            PrintBoard();
            while (true)
            {
                PlayerMove();
                PrintBoard();

                if (CheckWin())
                {
                    Console.WriteLine($"Победил: {currentPlayer}");
                    break;
                }

                if (Draw())
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
            }

            Console.ReadKey();
        }
        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i, j]} ");
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("---|---|---");
            }
        }

        static bool Draw()
        {
            return board.Cast<char>().All(f => f == 'X' || f == 'O');
        }
        static void PlayerMove()
        {
            currentPlayer = (numberOfMove % 2 == 0) ? PlayerSymbol.X : PlayerSymbol.O;
            Console.WriteLine($"Сейчас ходит: {currentPlayer.ToString()[0]}");
            int choice;
            bool isValidMove = false;
            while (!isValidMove)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 9)
                {
                    int row = (choice - 1) / 3;
                    int column = (choice - 1) % 3;
                    if (board[row, column] != 'X' && board[row, column] != 'O')
                    {
                        board[row, column] = currentPlayer.ToString()[0];
                        isValidMove = true;
                    }
                    else
                    {
                        Console.WriteLine($"Эта ячейка уже занята, в ней стоит {board[row, column]}");
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите число от 1 до 9.");
                }
            }

            numberOfMove++;
        }

        static bool CheckWin()
        {
            char currentChar = currentPlayer.ToString()[0];
            int pointToWin = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[0, i] == currentChar && board[1, i] == currentChar && board[2, i] == currentChar
                    || board[i, 0] == currentChar && board[i, 1] == currentChar && board[i, 2] == currentChar)
                {
                    Console.WriteLine($"Победил: {currentChar}");
                    return true;
                }
            }

            if ((board[0, 0] == currentChar && board[1, 1] == currentChar && board[2, 2] == currentChar) ||
                (board[0, 2] == currentChar && board[1, 1] == currentChar && board[2, 0] == currentChar))
            {
                Console.WriteLine($"Победил: {currentChar}");
                return true;
            }
            return false;
        }

    }
}
