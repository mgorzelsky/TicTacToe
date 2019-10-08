using System;

namespace TicTacToe
{
    //Enumeration for keeping track of the 3 possible states of a given play space.
    enum CurrentState { Empty, X, O };
    class Program
    {
        static void Main()
        {
            Game thisGame = new Game();
            thisGame.PlayGame();
            
            Console.ReadKey();
        }
    }
}
