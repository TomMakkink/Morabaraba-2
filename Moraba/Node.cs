using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
    class Node
    {
        public string position;
        public bool occupied;
        public List<string> neighbours;
        public Cow cow;

        public Node ()
        {
            position = "a0";
            occupied = false;
            neighbours = new List<string> { };
            cow = new Cow();
        }

        public Node (string pos, bool isEmpty, List<string> friendNode, Cow newCow)
        {
            position = pos;
            occupied = isEmpty;
            neighbours = friendNode;
            cow = newCow;
        }

        public Node(string pos,List<string> friends)
        {
            position = pos;
            occupied = false;
            neighbours = friends;
            cow = new Cow();
        }

    }
}
