using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moraba
{
    class Node
    {
        public string[] position;
        public bool occupied;
        public Node[] neighbours;
        public Cow cow;

        public Node ()
        {
            position = new string[] { "A", "0" };
            occupied = false;
            neighbours = new Node[4];
            cow = new Cow();
        }

        public Node (string row, string col, bool isEmpty, Node[] friendNode, Cow newCow)
        {
            position = new string[] { row, col };
            occupied = isEmpty;
            neighbours = friendNode;
            cow = newCow;
        }

        public Node(string row, string col, Node[] friendNode)
        {
            position = new string[] { row, col };
            occupied = false;
            neighbours = friendNode;
            cow = new Cow();
        }

    }
}
