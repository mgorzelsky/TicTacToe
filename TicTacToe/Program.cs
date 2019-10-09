using System;

namespace TicTacToe
{
    //Enumeration for keeping track of the 3 possible states of a given play space.
    enum CurrentState { Empty, X, O };
    class Program
    {
        static void Main()
        {
            //Play again loop. Allows the players to choose to play again or to quit.
            while (true)
            {
                ConsoleKeyInfo playAgain;
                Game thisGame = new Game();
                thisGame.PlayGame();

                Console.Clear();
                Console.SetCursorPosition(2, 3);
                Console.Write("Would you like to play again?\n Press Y to play again or N to quit : ");
                
                //Handles the incorrect keys being pressed
                while (true)
                {
                    playAgain = Console.ReadKey(true);
                    if (playAgain.Key == ConsoleKey.N)
                        return;
                    if (playAgain.Key == ConsoleKey.Y)
                        break;
                }
            }
        }
    }
}
