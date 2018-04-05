using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
    public class Cow
    {
        public string Position;
        public int Team;

        public Cow()
        {
            Position = "a0";
            Team = 0;
        }

        public Cow(string pos, int team)
        {
            Position = pos;
            Team = team;
        }
    }
}
