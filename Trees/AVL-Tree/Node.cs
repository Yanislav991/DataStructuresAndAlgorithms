namespace Trees.AVL_Tree
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Data = value;
        }
        public T Data { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
    }
}
