﻿using System.Collections.Generic;

namespace Tic
{
    public class GameState
    {
        private int Score;
        private int X = 0;
        private int Y = 0;
        private const int Available = 0;
        private int BoardSize;
        public GameState(int score):this()
        {
            Score = score;
        }
        public GameState()
        {
            BoardSize = Game.BoardSize;
        }

        public void MakeAImove(Board board)
        {
            GameState bestMove = FindBestMove(board, Game.PlayerO);
            board.theBoard[bestMove.X, bestMove.Y] = Game.PlayerO; // set the AI move;
        }
      
        private GameState FindBestMove(Board board, int player)
        {
            int res = Game.CheckWinner(board);
            if (res == Game.PlayerO)
            {
                return new GameState(10);
            }
            else if (res == Game.PlayerX)
            {
                return new GameState(-10);
            }
            else if (res == -1)
            {
                return new GameState(-1);
            } 

            List<GameState> gameStateList = new List<GameState>();

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board.theBoard[i, j] == 0) //available pos?
                    {
                        GameState move = new GameState();
                        move.X = i;
                        move.Y = j;
                        board.theBoard[i, j] = player;

                        if (player == Game.PlayerO)
                        {
                            int score = FindBestMove(board, Game.PlayerX).Score;
                            move.Score = score;
                        }
                        else
                        {
                            int score = FindBestMove(board, Game.PlayerO).Score;
                            move.Score = score;
                        }
                        gameStateList.Add(move);
                        board.theBoard[i, j] = Available; //reset play;
                    }
                }
            }
            int bestMove = 0;
            if (player == Game.PlayerO) //AI player
            {
                int bestScore = -100000;
                for (int k = 0; k < gameStateList.Count; k++)
                {
                    if (gameStateList[k].Score > bestScore)
                    {
                        bestMove = k;
                        bestScore = gameStateList[k].Score;
                    }
                }
            }
            else
            {
                int bestScore = 100000;
                for (int k = 0; k < gameStateList.Count; k++)
                {
                    if (gameStateList[k].Score < bestScore)
                    {
                        bestMove = k;
                        bestScore = gameStateList[k].Score;
                    }
                }

            }
            if (gameStateList.Count > 0)
                return gameStateList[bestMove];

            return new GameState(10);

        }
      
    }

}