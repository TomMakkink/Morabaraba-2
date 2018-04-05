using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
   
    public class Player
    {
      
        public string Name; 
        public int Team;
        public int Cows_On_Board;

        // default constructor
        public Player()
        {
            Name = "NeedName";
            Team = 0;
            Cows_On_Board = 0;
        }
        // constructor
        public Player(string name, int team)
        {
            Name = name;
            Team = team;
            Cows_On_Board = 0;
        }
    }
}
