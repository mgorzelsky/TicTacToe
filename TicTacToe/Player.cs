using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    //The player class exists to create the two players and pass their identity to other parts of the program
    class Player
    {
        readonly CurrentState player;
        public Player(CurrentState player)
        {
            this.player = player;
        }

        public CurrentState GetPlayer()
        {
            return player;
        }
    }
}
