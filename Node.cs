using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_3_SvetlioMaps
{
    class Node
    {
        private int nextNode;
        private int distance;

        public Node(int nextNode, int distance)
        {
            this.nextNode = nextNode;
            this.distance = distance;
        }

        public int NextNode
        {
            get { return this.nextNode; }
            set { this.nextNode = value; }
        }
        public int Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }
    }
}
