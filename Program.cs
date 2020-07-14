using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Render();

            int x;
            int y;
            while (!board.HasWinner && !board.Draw)
            {
                x = Int32.Parse(Console.ReadLine());
                y = Int32.Parse(Console.ReadLine());

                board.AddMove(x, y);
            }
        }
    }
}
