namespace Trees.BinarySearch
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree(Node<T> root = null)
        {
            this.Root = root;
        }
        public Node<T> Root { get; set; }

        public void Insert(T value)
        {
            this.Insert(this.Root, value);
        }
        public bool Contains(T value)
        {
            return this.Contains(this.Root, value);
        }
        public Node<T> Search(T value)
        {
            return this.Search(this.Root, value);
        }
        private void Insert(Node<T> current, T value)
        {
            if(current == null)
            {
                current = new Node<T>(value);
                Root = current;
                return;
            }

            if (current.Value.CompareTo(value) > 0)
            {
                if (current.LeftChild == null)
                {
                    current.LeftChild = new Node<T>(value);
                    return;
                }
                Insert(current.LeftChild, value);
            }
            else
            {
                if (current.RightChild == null)
                {
                    current.RightChild = new Node<T>(value);
                    return;
                }
                Insert(current.RightChild, value);
            }

        }
        
        private bool Contains(Node<T> node, T value)
        {
            if(node == null)
            {
                return false;
            }
            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
            if (node.Value.CompareTo(value) > 0)
            {
                return Contains(node.LeftChild, value);
            }
            else
            {
                return Contains(node.RightChild, value);
            }
        }
        private Node<T> Search(Node<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }
            if (node.Value.CompareTo(value) > 0)
            {
                return Search(node.LeftChild, value);
            }
            else
            {
                return Search(node.RightChild, value);
            }
        }
        //populate the BST
        private void Populate(BinarySearchTree<int> tree, int start, int end, List<int> elements)
        {
            if (start >= end)
            {
                return;
            }
            var middle = (start + end) / 2;
            tree.Insert(elements[middle]);
            Populate(tree, start, middle - 1, elements);
            Populate(tree, middle+1, end, elements);
        }

    }
}
