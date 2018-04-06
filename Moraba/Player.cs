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
       

        // default constructor
        public Player()
        {
            Name = "NeedName";
            Team = 0;
            
        }
        // constructor
        public Player(string name, int team)
        {
            Name = name;
            Team = team;
            
        }
    }
}
