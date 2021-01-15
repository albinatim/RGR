using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Edge
    {
        public Point Begin { get; set; }
        public Point Dest { get; set; }
        public Edge()
        {
        }
        public Edge(Point begin, Point dest)
        {
            Begin = begin;
            Dest = dest;
        }
    }
}
