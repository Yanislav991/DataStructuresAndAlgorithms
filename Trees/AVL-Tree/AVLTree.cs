using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.AVL_Tree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTree()
        {

        }
        public Node<T> Root { get; set; }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if(this.Root == null)
            {
                this.Root = newNode;
                return;
            }
            else
            {
                this.Root = this.Insert(this.Root, newNode);
            }

        }

        private Node<T> Insert(Node<T> currNode, Node<T> newNode)
        {
            if(currNode == null)
            {
                currNode = newNode;
                return currNode;
            }
            throw new NotImplementedException();
        }
    }
}
