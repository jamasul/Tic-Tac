using System;

namespace Tic
{
    public class Game
    {
        public const int PlayerX = 1;
        public const int PlayerO = 2;
        public const int Available = 0;
        public const int Draw = 3;
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
        private void ConsoleTextInMiddle()
        {
            Console.SetCursorPosition(0, 10);
        }
        public void Play()
        {
            int choice = 0;
            do
            {
                if (currentPlayer == PlayerX)
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

                    if (x <= 3 && y <= 3 && board.theBoard[x, y] == Available) //2 means available 1 = X, 0 = O
                    {
                        board.theBoard[x, y] = PlayerX;
                    }

                    else
                    {
                        Console.WriteLine("Invalid field!");
                    }
                }

                ChangePlayer();

                if (currentPlayer == PlayerO)
                {
                    gameState.MakeAImove(board);
                }
                Console.Clear();

                ConsoleTextInMiddle();
                board.PrintBoard();
                
                switch (CheckWinner(board))
                {
                    case PlayerX:
                        Console.WriteLine("You Win!");
                        BeepHumanWin();
                        break;
                    case PlayerO:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("AI Wins!");
                        BeepAIWin();
                        break;
                }
                if (CheckDraw(board) == Draw)
                {
                    Console.WriteLine("Draw!");
                    break;
                }
                
            }
            while (choice != 9);

        }

        public void ChangePlayer()
        {
            if (currentPlayer == PlayerX)
            {
                currentPlayer = PlayerO;
            }
            else
            {
                currentPlayer = PlayerX;
            }
        }

        public static int CheckWinner(Board board)
        {

            if (CheckWinningPosDiagonal(board.theBoard) == PlayerX)
            {
                return PlayerX;
            }
            else if (CheckWinningPosDiagonal(board.theBoard) == PlayerO)
            {
                return PlayerO;
            }
            if (CheckWinningPosHorisontal(board.theBoard) == PlayerX)
            {
                return PlayerX;
            }
            if (CheckWinningPosHorisontal(board.theBoard) == PlayerO)
            {
                return PlayerO;
            }

            if (CheckWinningPosVertical(board.theBoard) == PlayerX)
            {
                return PlayerX;
            }
            if (CheckWinningPosVertical(board.theBoard) == PlayerO)
            {
                return PlayerO;
            }
            return 0; //no winners
        }
        private int CheckDraw(Board board)
        {
            bool full = true;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board.theBoard[i, j] == Available)
                    {
                        full = false;
                        return 0;
                    }
                }
            }
            if (full && CheckWinner(board) != PlayerO && CheckWinner(board) != PlayerX)
            {
                return Draw;
            }
            return 0;
        }

        private static int CheckWinningPosDiagonal(int[,] currentboard)
        {
            if ((currentboard[0, 0] & currentboard[1, 1] & currentboard[2, 2]) == PlayerX)
            {
                return PlayerX; //playerX won diagonal
            }

            if ((currentboard[0, 0] & currentboard[1, 1] & currentboard[2, 2]) == PlayerO)
            {
                return PlayerO; //playerO won diagonal
            }

            if ((currentboard[0, 2] & currentboard[1, 1] & currentboard[2, 0]) == PlayerX)
            {
                return PlayerX; //playerX won diagonal
            }

            if ((currentboard[0, 2] & currentboard[1, 1] & currentboard[2, 0]) == PlayerO)
            {
                return PlayerO; //playerO won diagonal
            }
            return 0;
        }

        private static int CheckWinningPosHorisontal(int[,] currentboard)
        {
            if ((currentboard[0, 0] & currentboard[0, 1] & currentboard[0, 2]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }
            if ((currentboard[1, 0] & currentboard[1, 1] & currentboard[1, 2]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }
            if ((currentboard[2, 0] & currentboard[2, 1] & currentboard[2, 2]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }

            if ((currentboard[0, 0] & currentboard[0, 1] & currentboard[0, 2]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }
            if ((currentboard[1, 0] & currentboard[1, 1] & currentboard[1, 2]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }
            if ((currentboard[2, 0] & currentboard[2, 1] & currentboard[2, 2]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }

            return 0;
        }

        public static int CheckWinningPosVertical(int[,] currentboard)
        {

            if ((currentboard[0, 0] & currentboard[1, 0] & currentboard[2, 0]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }

            if ((currentboard[0, 1] & currentboard[1, 1] & currentboard[2, 1]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }
            if ((currentboard[0, 2] & currentboard[1, 2] & currentboard[2, 2]) == PlayerX)
            {
                return PlayerX; //playerX won horisontal
            }

            if ((currentboard[0, 0] & currentboard[1, 0] & currentboard[2, 0]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }
            if ((currentboard[0, 1] & currentboard[1, 1] & currentboard[2, 1]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }
            if ((currentboard[0, 2] & currentboard[1, 2] & currentboard[2, 2]) == PlayerO)
            {
                return PlayerO; //playerO won horisontal
            }
            return 0;
        }
        private void BeepAIWin()
        {
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(698, 350);
            Console.Beep(523, 150);
            Console.Beep(415, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
        }
        private void BeepHumanWin()
        {
            Console.Beep(440, 2000);
        }
    }
}