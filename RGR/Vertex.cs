using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RGR
{
    class Vertex
    {
        public PointF point;
        public Vertex(float x, float y)
        {
            point.X = x;
            point.Y = y;
        }
       
    }
    
    class Edge
    {
        public Vertex a;
        public Vertex b;
        public Edge(Vertex v1, Vertex v2)
        {
            if(v1.point.X<v2.point.X || v1.point.X == v2.point.X && v1.point.Y < v2.point.Y)
            {
                a = v1;
                b = v2;
            }
            else if(v1.point.X > v2.point.X || v1.point.X == v2.point.X && v1.point.Y > v2.point.Y)
            {
                b = v1;
                a = v2;
            }
            else
            {
                a = v1;
                b = v2;
            }
        }
    }
    class Triangle
    {
        public Vertex[] verts = new Vertex[3];
        public Triangle[] trns = new Triangle[3];
        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            verts[0] = a;
            verts[1] = b;
            verts[2] = c;
            for (int i = 0; i < 3; i++) trns[i] = null;
        }
    }
}
