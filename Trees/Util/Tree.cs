using System;
using System.Collections.Generic;

namespace Trees
{
    public class Tree<T>
    {
        public Tree(Node<T> root)
        {
            this.Root = root;
        }
        public Node<T> Root { get; set; }
        public List<Node<T>> BFS(Node<T> node)
        {
            var queue = new Queue<Node<T>>();
            var list = new List<Node<T>>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                list.Add(currentNode);
                foreach (var element in currentNode.Children)
                {
                    queue.Enqueue(element);
                }
            }
            return list;
        }
        public void DFS(Node<T> node, int spaces) // coul add a reference to a list as a third choice
        {
            Console.WriteLine(new string(' ', spaces));
            Console.WriteLine(node);
            //var list = new List<Node<T>>();
            foreach (var element in node.Children)
            {
                //list.AddRange(DFS(element))   
                DFS(element, spaces + 3);
            }
            //return list;
        }
    }
}
