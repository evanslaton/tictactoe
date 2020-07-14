using System;

namespace tic_tac_toe
{
    class Board
    {
        private static int BOARD_DIMENSION = 3;
        private static int MAX_TURNS = 9;
        private static char O = 'O';
        private static char X = 'X';
        public char[,] GameBoard { get; set; }
        public char CurrentSymbol { get; set; }
        public bool HasWinner { get; set; }
        public bool Draw { get; set; }
        public int Turns { get; set; }

        public Board()
        {
            Clear();
        }

        public void Clear()
        {
            GameBoard = CreateBoard();
            CurrentSymbol = O;
            HasWinner = false;
            Draw = false;
            Turns = 0;
        }

        private char[,] CreateBoard()
        {
            char[,] board = new char[BOARD_DIMENSION, BOARD_DIMENSION];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    board[i, j] = ' ';
                }
            }
            return board;
        }

        public void AddMove(int x, int y)
        {
            if (IsValidMove(x, y))
            {
                GameBoard[x, y] = CurrentSymbol;
                CurrentSymbol = CurrentSymbol == O ? X : O;
                Turns++;
                CheckForWin();
                CheckForDraw();
                Render();
            }
        }

        public bool IsValidMove(int x, int y)
        {
            return GameBoard[x, y] == ' '
                && x < BOARD_DIMENSION
                && y < BOARD_DIMENSION;
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(0); j++)
                {
                    if (j == 0)
                    {
                        Console.Write($" {GameBoard[i, j]}");
                    }
                    else
                    {
                        Console.Write($"|{GameBoard[i, j]}");
                    }
                }
                if (i != GameBoard.GetLength(0) - 1)
                {
                    Console.WriteLine("\n -----");
                }
            }
            Console.WriteLine();
        }

        public void CheckForWin()
        {
            if (GameBoard[1,1] != ' ')
            {
                if ((GameBoard[1, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[1, 2])
                || (GameBoard[0, 1] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 1])
                || (GameBoard[0, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 2])
                || (GameBoard[0, 2] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 0]))
                {
                    HasWinner = true;
                }
            }
            
            if (GameBoard[0,0] != ' ')
            {
                if ((GameBoard[0, 0] == GameBoard[0, 1] && GameBoard[0, 1] == GameBoard[0, 2])
                || (GameBoard[0, 0] == GameBoard[1, 0] && GameBoard[1, 0] == GameBoard[2, 0]))
                {
                    HasWinner = true;
                }
            }
            
            if (GameBoard[2, 2] != ' ')
            {
                if ((GameBoard[2, 0] == GameBoard[2, 1] && GameBoard[2, 1] == GameBoard[2, 2])
                || (GameBoard[0, 2] == GameBoard[1, 2] && GameBoard[1, 2] == GameBoard[2, 2]))
                {
                    HasWinner = true;
                }
            }
        }

        public void CheckForDraw()
        {
            Draw = (Turns == MAX_TURNS && !HasWinner);
        }
    }
}
