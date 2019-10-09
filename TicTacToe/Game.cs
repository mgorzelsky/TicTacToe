using System;
using System.Threading;
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
            string gameResult;
            playArea.DrawBoard();

            //The loop that handles the game play.
            while (true)
            {
                playArea.TakeTurn(playerX.GetPlayer());
                gameResult = WinCheck();
                if (gameResult == "X" || gameResult == "O" || gameResult == "DRAW")
                    break;

                playArea.TakeTurn(playerO.GetPlayer());
                gameResult = WinCheck();
                if (gameResult == "X" || gameResult == "O" || gameResult == "DRAW")
                    break;
            }
            
            //Clears the current line of text under the game board so that results can be cleanly displayed.
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(2, 6);

            if (gameResult == "X" || gameResult == "O")
                Console.WriteLine("Congratulations player " + gameResult + "! You've won the game!");
            else
                Console.WriteLine("Well it seems it was a " + gameResult + "! Better luck next time!");
            
            Thread.Sleep(5000);
        }
        
        //Checks all the possible win states and returns a string declaring who, if anyone, won
        private string WinCheck()
        {
            CurrentState[,] currentGameBoard = playArea.GetState();
            //Horizontal X wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[0, 1] == CurrentState.X && currentGameBoard[0, 2] == CurrentState.X)
                return "X";
            if (currentGameBoard[1, 0] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[1, 2] == CurrentState.X)
                return "X";
            if (currentGameBoard[2, 0] == CurrentState.X && currentGameBoard[2, 1] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return "X";

            //Vertical X wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[1, 0] == CurrentState.X && currentGameBoard[2, 0] == CurrentState.X)
                return "X";
            if (currentGameBoard[0, 1] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 1] == CurrentState.X)
                return "X";
            if (currentGameBoard[0, 2] == CurrentState.X && currentGameBoard[1, 2] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return "X";

            //Diagonal X Wins
            if (currentGameBoard[0, 0] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 2] == CurrentState.X)
                return "X";
            if (currentGameBoard[0, 2] == CurrentState.X && currentGameBoard[1, 1] == CurrentState.X && currentGameBoard[2, 0] == CurrentState.X)
                return "X";

            //Horizontal O wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[0, 1] == CurrentState.O && currentGameBoard[0, 2] == CurrentState.O)
                return "O";
            if (currentGameBoard[1, 0] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[1, 2] == CurrentState.O)
                return "O";
            if (currentGameBoard[2, 0] == CurrentState.O && currentGameBoard[2, 1] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return "O";

            //Vertical O wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[1, 0] == CurrentState.O && currentGameBoard[2, 0] == CurrentState.O)
                return "O";
            if (currentGameBoard[0, 1] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 1] == CurrentState.O)
                return "O";
            if (currentGameBoard[0, 2] == CurrentState.O && currentGameBoard[1, 2] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return "O";

            //Diagonal O Wins
            if (currentGameBoard[0, 0] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 2] == CurrentState.O)
                return "O";
            if (currentGameBoard[0, 2] == CurrentState.O && currentGameBoard[1, 1] == CurrentState.O && currentGameBoard[2, 0] == CurrentState.O)
                return "O";

            //Draw condition
            if (currentGameBoard[0, 0] != CurrentState.Empty && currentGameBoard[0, 1] != CurrentState.Empty && currentGameBoard[0, 2] != CurrentState.Empty &&
                currentGameBoard[1, 0] != CurrentState.Empty && currentGameBoard[1, 1] != CurrentState.Empty && currentGameBoard[1, 2] != CurrentState.Empty &&
                currentGameBoard[2, 0] != CurrentState.Empty && currentGameBoard[2, 1] != CurrentState.Empty && currentGameBoard[2, 2] != CurrentState.Empty)
                return "DRAW";

            else { return "contine"; }
        }
    }
}
