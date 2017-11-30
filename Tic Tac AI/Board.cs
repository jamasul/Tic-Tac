using System;
using System.Collections.Generic;

namespace Tic
{
    public class Board
    {
        public int[,] theBoard;
        private int BoardSize = Game.BoardSize;
        Dictionary<int, char> screen = new Dictionary<int, char>() { { 1, 'X' }, { 2, 'O' }, { 0, '_' } };
        public Board(int[,] board)
        {
            theBoard = board;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    theBoard[i, j] = 0;
                }
            }

        }
        public void PrintBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {

                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write("|__{0}__|", screen[theBoard[i, j]]);

                }
                Console.WriteLine();
            }
        }
    }

}