using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
    public enum PlayerState
    {
        PLACING,
        MOVING,
        FLYING,
        END
    };
    public class Player
    {
      
        public string Name; 
        public int Team;
        public PlayerState state;
        // default constructor
        public Player()
        {
            Name = "NeedName";
            Team = 0;
            state = PlayerState.PLACING;
        }
        // constructor
        public Player(string name, int team)
        {
            Name = name;
            Team = team;
            state = PlayerState.PLACING;
        }
    }
}
