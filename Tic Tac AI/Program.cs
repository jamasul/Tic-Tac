using System;
using static Tic.GameState;

namespace Tic
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 9)
            {
                Console.WriteLine("------Tic Tac Toe against AI------");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|     play a game or 9 to exit    |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|     Board size: (default 3x3)   |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|---------------------------------|");

                Console.WriteLine();

                int boardSize = 3;

                if (int.TryParse(Console.ReadLine(), out boardSize) != false && boardSize <= 8 && boardSize >= 3)
                {
                    choice = boardSize;
                    Game game = new Game(boardSize);
                    game.Play();
                }


                else
                {
                    Console.WriteLine("Wrong board size (3x3-8x8");
                }
                if (choice == 9)
                {
                    break;
                }
                Console.ReadLine();
            }
        }
    }

}