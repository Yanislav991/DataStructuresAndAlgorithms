using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    public class Node<T>
    {
        public Node(T value, params Node<T>[] nodes)
        {
            this.Value = value;
            this.Children = nodes.ToList();
        }
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
        public override string ToString()
        {
            return $"{this.Value} - Node Value";
        }
    }
}
