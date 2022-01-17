using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.B_Tree
{
    public class Node<T>
    {
        private int T = 3; // value should be the same inside the tree;
        public Node()
        {

        }
        public int KeyNumber { get; set; }
        public T[] Keys { get; set; } = new T[2 * T - 1];
        public Node<T>[] Children { get; set; } = new Node<T>[2 * T];
        public bool IsLeaf { get; set; } = false;
        public T Find(T value)
        {
            for (int i = 0; i < this.KeyNumber; i++)
            {
                if (this.Children[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
