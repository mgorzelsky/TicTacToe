using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
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
