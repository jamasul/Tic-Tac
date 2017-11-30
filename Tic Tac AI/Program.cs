using System;
using static Tic.GameState;

namespace Tic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Tic Tac Toe against AI------");
            Console.WriteLine();
            Console.WriteLine("Board size: (default 3x3)");
            int boardSize = 3;
            if (int.TryParse(Console.ReadLine(), out boardSize) != false && boardSize <=8)
            {
                Game game = new Game(boardSize);
                game.Play();
            }
            else
            {
                Console.WriteLine("Wrong board size (3x3-8x8");
            }
            Console.ReadLine();
        }
    }

}