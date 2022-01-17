using System;
namespace Trees.B_Tree
{
    public class BTree<T> where T : IComparable<T>
    {
        private int T = 3;
        private Node<T> root;
        public BTree()
        {
            root = new Node<T>();
            root.KeyNumber = 0;
            root.IsLeaf = true;
        }

        private Node<T> Search(Node<T> node, T key)
        {
            int i = 0;
            if (node == null)
            {
                return node;
            }
            for (int i = 0; i < node.KeyNumber; i++)
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
            thirdNode.KeyNumber = this.T - 1;
            for (int i = 0; i < this.T - 1; i++)
            {
                thirdNode.Keys[i] = secondNode.Keys[i + this.T];
            }
            if (!secondNode.IsLeaf)
            {
                for (int i = 0; i < this.T; i++)
                {
                    thirdNode.Children[i] = secondNode.Children[i + this.T];
                }
            }
            secondNode.KeyNumber = T - 1;
            for (int i = node.KeyNumber; i >= position + 1; i--)
            {
                node.Children[i + 1] = node.Children[i];
            }
            node.Children[position + 1] = thirdNode;
            for (int i = node.KeyNumber; i >= position; i--)
            {
                node.Keys[i + 1] = node.Keys[i];
            }
            node.Keys[position] = secondNode.Keys[this.T - 1];
            node.KeyNumber = node.KeyNumber + 1;
        }
        private void InsertValue(Node<T> node, T value)
        {
            if (node.IsLeaf)
            {
                int i = 0;
                for (int i = node.KeyNumber - 1; i >= 0 && value.CompareTo(node.Keys[i]) < 0; i--)
                {
                    node.Keys[i + 1] = node.Keys[i];
                }
                node.Keys[i + 1] = value;
                node.KeyNumber = node.KeyNumber + 1;
            }
            else
            {
                int i = 0;
                for (int i = node.KeyNumber; i >= 0 && value.CompareTo(node.Keys[i]) < 0; i--)
                {
                }
                i++;
                Node<T> temp = node.Children[i];
                if (temp.KeyNumber == 2 * this.T - 1)
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
            Node temp = this.root;
            if (root.KeyNumber == 2 * this.T - 1)
            {
                Node<T> node = new Node<T>();
                root = node;
                node.IsLeaf = false;
                node.KeyNumber = 0;
                node.Children[0] = temp;
                Split(node, 0, temp);
                InsertValue(node, value);
            }
            else
            {
                InsertValue(root, value);
            }
        }
        public void Show() => this.Show(root);
        private void Show(Node<T> node)
        {
            if(node == null)
            {
                Console.WriteLine("Node is Null");
            }
            for (int i = 0; i < node.KeyNumber; i++)
            {
                Console.WriteLine(node.Keys[i] + " ");
            }
            if (!node.IsLeaf)
            {
                for (int i = 0; i < node.KeyNumber; i++)
                {
                    Show(node.Children[i]);
                }
            }
        }
        public bool Contains(T value)
        {
            if (this.Search(root, value) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
