using System;
using System.Linq;

namespace Trees.B_Tree
{
    public class BTree<T> where T : IComparable<T>
    {
        private int MinDeg = 3;
        private Node<T> Root;
        public BTree()
        {
            Root = new Node<T>();
            Root.KeysNumber = 0;
            Root.IsLeaf = true;
        }

        private Node<T> Search(Node<T> node, T key)
        {
            int i = 0;
            if (node == null)
            {
                return node;
            }
            for (i = 0; i < node.KeysNumber; i++)
            {

                if (key.CompareTo(node.Keys[i]) < 0)
                {
                    break;
                }
                if (key.CompareTo(node.Keys[i]) == 0)
                {
                    return node;
                }
            }
            if (node.IsLeaf)
            {
                return null;
            }
            else
            {
                return Search(node.Children[i], key);
            }
        }
        private void Split(Node<T> node, int position, Node<T> secondNode)
        {
            Node<T> thirdNode = new Node<T>();
            thirdNode.IsLeaf = secondNode.IsLeaf;
            thirdNode.KeysNumber = this.MinDeg - 1;
            for (int i = 0; i < this.MinDeg - 1; i++)
            {
                thirdNode.Keys[i] = secondNode.Keys[i + this.MinDeg];
            }
            if (!secondNode.IsLeaf)
            {
                for (int i = 0; i < this.MinDeg; i++)
                {
                    thirdNode.Children[i] = secondNode.Children[i + this.MinDeg];
                }
            }
            secondNode.KeysNumber = MinDeg - 1;
            for (int i = node.KeysNumber; i >= position + 1; i--)
            {
                node.Children[i + 1] = node.Children[i];
            }
            node.Children[position + 1] = thirdNode;
            for (int i = node.KeysNumber - 1; i >= position; i--)
            {
                node.Keys[i + 1] = node.Keys[i];
            }
            node.Keys[position] = secondNode.Keys[this.MinDeg - 1];
            node.KeysNumber = node.KeysNumber + 1;
        }
        private void InsertValue(Node<T> node, T value)
        {
            if (node.IsLeaf)
            {
                int i = 0;
                for (i = node.KeysNumber - 1; i >= 0 && value.CompareTo(node.Keys[i]) < 0; i--)
                {
                    node.Keys[i + 1] = node.Keys[i];
                }
                node.Keys[i + 1] = value;
                node.KeysNumber = node.KeysNumber + 1;
            }
            else
            {
                int i = 0;
                for (i = node.KeysNumber - 1; i >= 0 && value.CompareTo(node.Keys[i]) < 0; i--)
                {
                }
                i++;
                Node<T> temp = node.Children[i];
                if (temp.KeysNumber == 2 * this.MinDeg - 1)
                {
                    Split(node, i, temp);
                    if (value.CompareTo(node.Keys[i]) > 0) // consider =
                    {
                        i++;
                    }
                }
                InsertValue(node.Children[i], value);
            }
        }
        public void Insert(T value)
        {
            Node<T> newnNode = this.Root;
            if (newnNode.KeysNumber == 2 * this.MinDeg - 1)
            {
                Node<T> secondNewNode = new Node<T>();
                Root = secondNewNode;
                secondNewNode.IsLeaf = false;
                secondNewNode.KeysNumber = 0;
                secondNewNode.Children[0] = newnNode;
                Split(secondNewNode, 0, newnNode);
                InsertValue(secondNewNode, value);
            }
            else
            {
                InsertValue(newnNode, value);
            }
        }
        public void Show() => this.Show(Root);
        private void Show(Node<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("Node is Null");
            }
            for (int i = 0; i < node.KeysNumber; i++)
            {
                Console.Write(node.Keys[i]+ " ");
                
            }
            Console.WriteLine();
            if (!node.IsLeaf)
            {
                
                for (int i = 0; i < node.KeysNumber + 1; i++)
                {
                    Show(node.Children[i]);
                }
            }
        }
        public bool Contains(T value)
        {
            if (this.Search(Root, value) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        //TODO : Remove
    }
}
