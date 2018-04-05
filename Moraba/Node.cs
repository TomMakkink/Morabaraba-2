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
        public Node[] neighbours;
        public Cow cow;

        public Node ()
        {
            position = "a0";
            occupied = false;
            neighbours = new Node[4];
            cow = new Cow();
        }

        public Node (string pos, bool isEmpty, Node[] friendNode, Cow newCow)
        {
            position = pos;
            occupied = isEmpty;
            neighbours = friendNode;
            cow = newCow;
        }

        public Node(string pos, Node[] friendNode)
        {
            position = pos;
            occupied = false;
            neighbours = friendNode;
            cow = new Cow();
        }

    }
}
