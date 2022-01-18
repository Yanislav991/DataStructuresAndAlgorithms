using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.B_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        // value should be the same inside the tree;
        private static int MinDeg = 3;
        public Node()
        {

        }
        public int KeysNumber { get; set; }
        public T[] Keys { get; set; } = new T[2 * MinDeg - 1];
        public Node<T>[] Children { get; set; } = new Node<T>[2 * MinDeg];
        public bool IsLeaf { get; set; } = false;
        public int Find(T value)
        {
            for (int i = 0; i < this.KeysNumber; i++)
            {
                if (this.Keys[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
