using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    //Class that handles the actual states of the game including the order of play as well as verifying that the game hasn't
    //ended yet (X win, O win, Draw).
    class Game
    {
        Board playArea = new Board();
        Player playerX = new Player(CurrentState.X);
        Player playerO = new Player(CurrentState.O);
        public void PlayGame()
        {
            playArea.DrawBoard();

            //The loop that handles the game play.
            while (true)
            {
                playArea.TakeTurn(playerX.GetPlayer());
                if (WinCheck())
                    break;

                playArea.TakeTurn(playerO.GetPlayer());
                if (WinCheck())
                    break;
            }
        }
        private bool WinCheck()
        {
            CurrentState[,] currentGameBoard = playArea.GetState();
            //Horizontal X wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[0, 1] == CurrentState.X && currentGameBoard[0, 2] == CurrentState.X)
                return true;
            if (currentGameBoard[1, 0] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[1, 2] == CurrentState.X)
                return true;
            if (currentGameBoard[2, 0] == CurrentState.X && currentGameBoard[2, 1] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return true;

            //Vertical X wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[1, 0] == CurrentState.X && currentGameBoard[2, 0] == CurrentState.X)
                return true;
            if (currentGameBoard[0, 1] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 1] == CurrentState.X)
                return true;
            if (currentGameBoard[0, 2] == CurrentState.X && currentGameBoard[1, 2] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return true;

            //Diagonal X Wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return true;
            if (currentGameBoard[0, 2] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 0] == CurrentState.X)
                return true;

            //Horizontal O wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[0, 1] == CurrentState.O && currentGameBoard[0, 2] == CurrentState.O)
                return true;
            if (currentGameBoard[1, 0] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[1, 2] == CurrentState.O)
                return true;
            if (currentGameBoard[2, 0] == CurrentState.O && currentGameBoard[2, 1] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return true;

            //Vertical O wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[1, 0] == CurrentState.O && currentGameBoard[2, 0] == CurrentState.O)
                return true;
            if (currentGameBoard[0, 1] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 1] == CurrentState.O)
                return true;
            if (currentGameBoard[0, 2] == CurrentState.O && currentGameBoard[1, 2] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return true;

            //Diagonal O Wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return true;
            if (currentGameBoard[0, 2] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 0] == CurrentState.O)
                return true;

            //Draw condition
            if (currentGameBoard[0, 0] != CurrentState.Empty && currentGameBoard[0, 1] != CurrentState.Empty && currentGameBoard[0, 2] != CurrentState.Empty &&
                currentGameBoard[1, 0] != CurrentState.Empty && currentGameBoard[1, 1] != CurrentState.Empty && currentGameBoard[1, 2] != CurrentState.Empty &&
                currentGameBoard[2, 0] != CurrentState.Empty && currentGameBoard[2, 1] != CurrentState.Empty && currentGameBoard[2, 2] != CurrentState.Empty)
                return true;

            else { return false; }
        }
    }
}
