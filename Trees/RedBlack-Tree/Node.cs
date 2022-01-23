using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.RedBlack_Tree
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.LeftChild = null;
            this.RightChild = null;
            this.Parent = null;
            this.Color = Color.Red;
        }
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public Color Color { get; set; }
        public Node<T> Parent { get; set; }
        public override string ToString()
        {
            return $"{this.Value}P:{this.Parent.Value} C:{this.Color.ToString()}";
        }

    }

}
