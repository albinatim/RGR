using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class Node
    {
        
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public Node()//пустой узел
        {
            Next = Prev = this;
        }
        public Node Insert(Node b) //включает узел после текущего узла
        {
            Node c = Next;
            b.Next = c;
            b.Prev = this;
            Next = b;
            c.Prev = b;
            return b;
        }
        public Node Remove() //удаляет текущий узел
        {
            Prev.Next = Next;
            Next.Prev = Prev;
            Next = Prev = this;
            return this;
        }
        public void Splice(Node b)//вообще непонятно зачем
        {
            Node a = this;
            Node an = a.Next;
            Node bn = b.Next;
            a.Next = bn;
            b.Next = an;
            an.Prev = b;
            bn.Prev = a;
        }
    }
    class LList<T>
    {

    }
}
