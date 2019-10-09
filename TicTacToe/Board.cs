using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    //Handles drawing the gameboard and its states on the screen as well as updating the state of the game and allowing
    //players to make changes to the board. Board Board Board, it looks spelled wrong after you read it enough times.
    class Board
    {
        //2D array the tracks the current state of the 9 play locations on the board. Is used to check for
        //valid plays as well as for checking if anyone has won yet.
        private CurrentState[,] gameBoard = 
        { 
            { CurrentState.Empty, CurrentState.Empty, CurrentState.Empty },
            { CurrentState.Empty, CurrentState.Empty, CurrentState.Empty },
            { CurrentState.Empty, CurrentState.Empty, CurrentState.Empty },
        };

        //Draw the initial starting board. Will also wipe any current plays on the board.
        public void DrawBoard()
        {
            Console.Clear();
            Draw(0, 0, "   |   |   ");
            Draw(0, 1, "---+---+---");
            Draw(0, 2, "   |   |   ");
            Draw(0, 3, "---+---+---");
            Draw(0, 4, "   |   |   ");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("Welcome to Tic-Tac-Toe! Use the arrow keys to move and press Enter to confirm your move!");
        }

        //Allows the board to make any draw functions it needs to while handling bad inputs
        //Overload available for passing in a string or the enumeration CurrentState.
        private void Draw(int x, int y, string s)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        private void Draw(int x, int y, CurrentState s)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        //Takes in user input and allows them to navigate the board as well as make their placement selection.
        public void TakeTurn(CurrentState playerTurn)
        {
            int i = 1;           // center cell position in 0, 1, 2 columns
            int j = 1;           // center cell position in 0, 1, 2 rows
            CursorMove(i, j);
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        i = (i + 1) % 3;
                        CursorMove(i, j);
                        break;
                    case ConsoleKey.LeftArrow:
                        i = (i + 2) % 3;
                        CursorMove(i, j);
                        break;
                    case ConsoleKey.DownArrow:
                        j = (j + 1) % 3;
                        CursorMove(i, j);
                        break;
                    case ConsoleKey.UpArrow:
                        j = (j + 2) % 3;
                        CursorMove(i, j);
                        break;
                    case ConsoleKey.Enter:
                        if (gameBoard[i, j] != CurrentState.Empty) { Console.Beep(); break; } // cannot place X or O where one is already played.
                        gameBoard[i, j] = playerTurn;
                        Draw(1 + (4 * i), 2 * j, playerTurn);
                        return;
                }
            }
        }

        //Moves the cursor postion between the different cells with the passed in cell choice [i, j] using
        //magic number math to make sure that the cursor moves the correct distance.
        private void CursorMove(int i, int j)
        {
            Console.SetCursorPosition(1 + (4 * i), 2 * j);
        }

        //Get the state of the gameBoard either as the full array or as what is at a specific index in the array.
        public CurrentState[,] GetState()
        {
            return gameBoard;
        }
        public CurrentState GetState(int x, int y)
        {
            return gameBoard[x, y];
        }
    }
}
