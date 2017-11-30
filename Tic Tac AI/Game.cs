using System;

namespace Tic
{
    public class Game
    {
        public const int playerX = 1;
        public const int playerO = 2;
        public const int available = 0;
        public const int draw = -1;
        public static int BoardSize = 3; //default
        public int currentPlayer;
        Board board;
        GameState gameState;
        public Game(int boardSize)
        {
            BoardSize = boardSize;
            board = new Board(new int[boardSize, BoardSize]);
            gameState = new GameState();
        }

        public void Play()
        {
            int choice = 0;
            do
            {
                if (currentPlayer == playerX)
                {
                    Console.WriteLine("Player X: x: ");
                    if (!int.TryParse(Console.ReadLine(), out int x))
                    {
                        Console.WriteLine("Wrong input!");
                    }

                    Console.WriteLine("Player X: y:");
                    if (!int.TryParse(Console.ReadLine(), out int y))
                    {
                        Console.WriteLine("Wrong input!");
                    }

                    choice = x;

                    if (x <= 3 && y <= 3 && board.theBoard[x, y] == available) //2 means available 1 = X, 0 = O
                    {
                        board.theBoard[x, y] = playerX;
                    }

                    else
                    {
                        Console.WriteLine("Invalid field!");
                    }
                }
                ChangePlayer();

                if (currentPlayer == playerO)
                {
                    gameState.MakeAImove(board);
                }
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine();

            }
            while (choice != 9);

        }

        public void ChangePlayer()
        {
            if (currentPlayer == playerX)
            {
                currentPlayer = playerO;
            }
            else
            {
                currentPlayer = playerX;
            }
        }

        public static int CheckWinner(Board board)
        {
            if (CheckWinningPosDiagonal(board.theBoard) == playerX)
            {
                //Console.WriteLine("PlayerX won diagonal!");
                return playerX;
            }
            else if (CheckWinningPosDiagonal(board.theBoard) == playerO)
            {
                //Console.WriteLine("PlayerO won diagonal!");
                return playerO;
            }
            if (CheckWinningPosHorisontal(board.theBoard) == playerX)
            {
                //Console.WriteLine("PlayerX won horisontal!");
                return playerX;
            }
            if (CheckWinningPosHorisontal(board.theBoard) == playerO)
            {
                //Console.WriteLine("PlayerO won horisontal!");
                return playerO;
            }

            if (CheckWinningPosVertical(board.theBoard) == playerX)
            {
                //Console.WriteLine("PlayerX won vertical!");
                return playerX;
            }
            if (CheckWinningPosVertical(board.theBoard) == playerO)
            {
                //Console.WriteLine("PlayerO won vertical!");
                return playerO;
            }
            return 0; //no winners
        }

        public static int CheckWinningPosDiagonal(int[,] currentboard)
        {
            if ((currentboard[0, 0] & currentboard[1, 1] & currentboard[2, 2]) == playerX)
            {
                return playerX; //playerX won diagonal
            }

            if ((currentboard[0, 0] & currentboard[1, 1] & currentboard[2, 2]) == playerO)
            {
                return playerO; //playerO won diagonal
            }

            if ((currentboard[0, 2] & currentboard[1, 1] & currentboard[2, 0]) == playerX)
            {
                return playerX; //playerX won diagonal
            }

            if ((currentboard[0, 2] & currentboard[1, 1] & currentboard[2, 0]) == playerO)
            {
                return playerO; //playerO won diagonal
            }
            return 0;
        }

        public static int CheckWinningPosHorisontal(int[,] currentboard)
        {
            if ((currentboard[0, 0] & currentboard[0, 1] & currentboard[0, 2]) == playerX)
            {
                return playerX; //playerX won horisontal
            }
            if ((currentboard[1, 0] & currentboard[1, 1] & currentboard[1, 2]) == playerX)
            {
                return playerX; //playerX won horisontal
            }
            if ((currentboard[2, 0] & currentboard[2, 1] & currentboard[2, 2]) == playerX)
            {
                return playerX; //playerX won horisontal
            }

            if ((currentboard[0, 0] & currentboard[0, 1] & currentboard[0, 2]) == playerO)
            {
                return playerO; //playerO won horisontal
            }
            if ((currentboard[1, 0] & currentboard[1, 1] & currentboard[1, 2]) == playerO)
            {
                return playerO; //playerO won horisontal
            }
            if ((currentboard[2, 0] & currentboard[2, 1] & currentboard[2, 2]) == playerO)
            {
                return playerO; //playerO won horisontal
            }

            return 0;
        }

        public static int CheckWinningPosVertical(int[,] currentboard)
        {

            if ((currentboard[0, 0] & currentboard[1, 0] & currentboard[2, 0]) == playerX)
            {
                return playerX; //playerX won horisontal
            }

            if ((currentboard[0, 1] & currentboard[1, 1] & currentboard[2, 1]) == playerX)
            {
                return playerX; //playerX won horisontal
            }
            if ((currentboard[0, 2] & currentboard[1, 2] & currentboard[2, 2]) == playerX)
            {
                return playerX; //playerX won horisontal
            }

            if ((currentboard[0, 0] & currentboard[1, 0] & currentboard[2, 0]) == playerO)
            {
                return playerO; //playerO won horisontal
            }
            if ((currentboard[0, 1] & currentboard[1, 1] & currentboard[2, 1]) == playerO)
            {
                return playerO; //playerO won horisontal
            }
            if ((currentboard[0, 2] & currentboard[1, 2] & currentboard[2, 2]) == playerO)
            {
                return playerO; //playerO won horisontal
            }
            return 0;
        }
    }

}