using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR
{
    public partial class Form1 : Form
    {
        List<Vertex> vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                vertices.Add(new Vertex(e.X, e.Y));
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush point = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 1);
            if(vertices.Count!=0)
            foreach(Vertex v in vertices)
            {
                g.FillEllipse(point, v.point.X - 5, v.point.Y - 5, 10, 10);
            }
            if(edges.Count!=0)
            foreach(Edge t in edges)
            {  
                g.DrawLine(pen, t.a.point, t.b.point);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            edges.Clear();
            pictureBox1.Refresh();
        }

        private void build_Click(object sender, EventArgs e)
        {
            edges.Clear();
            if (vertices.Count >= 3)
            {
                for(int i = 0; i < vertices.Count-1; i++)
                {
                    for(int j=0;j< vertices.Count - i; j++)
                    {
                         if (vertices[i].point.X > vertices[j].point.X || vertices[i].point.X == vertices[j].point.X && vertices[i].point.Y > vertices[j].point.Y)
                        {
                            Vertex c = vertices[i];
                            vertices[i] = vertices[j];
                            vertices[j] = c;
                        }
                        
                    }
                }
                for (int i = 0; i < vertices.Count; i++)
                {

                    for (int j = 0; j < vertices.Count; j++)
                    {
                        if (i != j)
                        {
                            Edge edge = new Edge(vertices[i], vertices[j]);
                            int n = 0;
                            for (int p = 0; p < edges.Count; p++)
                            {
                                if (edge == edges[p]) n++;
                            }
                            if (n == 0)
                                edges.Add(edge);
                        }

                    }
                }

                int k = edges.Count - 1;
                while (k >= 0)
                {
                    int t = edges.Count - 1;
                    while (t >= 0)
                    {
                        if (Intersect(edges[k].a, edges[k].b, edges[t].a, edges[t].b))
                        {
                            edges.Remove(edges[t]);
                            k--;
                        }
                        t--;
                    }
                    k--;
                }
                pictureBox1.Refresh();
            }
            
        }
       

        private bool Intersect(Vertex a1, Vertex a2, Vertex b1, Vertex b2)
        {
            float v1, v2, v3, v4;
            v1 = (b2.point.X - b1.point.X) * (a1.point.Y - b1.point.Y) - (b2.point.Y - b1.point.Y) * (a1.point.X - b1.point.X);
            v2 = (b2.point.X - b1.point.X) * (a2.point.Y - b1.point.Y) - (b2.point.Y - b1.point.Y) * (a2.point.X - b1.point.X);
            v3 = (a2.point.X - a1.point.X) * (b1.point.Y - a1.point.Y) - (a2.point.Y - a1.point.Y) * (b1.point.X - a1.point.X);
            v4 = (a2.point.X - a1.point.X) * (b2.point.Y - a1.point.Y) - (a2.point.Y - a1.point.Y) * (b2.point.X - a1.point.X);
            bool intrsct = (v1 * v2 < 0) && (v3 * v4 < 0);
            return intrsct;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

    }
}
