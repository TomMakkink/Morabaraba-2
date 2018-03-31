using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
    public class Cow
    {
        public string Name;
        public string [] Position;
        public int Team;

        public Cow()
        {
            Name = "NoNameBrand";
            Position = new string[] { "A", "0" };
            Team = 0;
        }

        public Cow(string name, string row, string col, int team)
        {
            Name = name;
            Position = new string[] { row, col };
            Team = team;
        }
    }
}
