namespace DataStructuresAndAlgorithms
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Last { get; set; }
        private int Count { get; set; }

        public void Add(T element)
        {
            var newElement = new Node<T>(element);
            if (Head == null)
            {
                Head = newElement;
                Last = newElement;
            }
            else
            {
                newElement.Next = Head;
                Head = newElement;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            var newElement = new Node<T>(element);
            if (Head == null)
            {
                Head = newElement;
                Last = newElement;
            }
            else
            {
                Last.Next = newElement;
                Last = newElement;
            }
            Count++;
        }
        public T RemoveHead()
        {
            var oldHead = Head;
            if(Head == null)
            {
                Last = null;
            }
            Head = Head.Next;
            if (Count > 0)
            {
                Count--;
            }
            return oldHead.Value;

        }
        public T RemoveLast()
        {
            var oldLast = Last;
            if(Last == null)
            {
                Head = null;
            }
            Last = Last.Next;
            if (Count > 0)
            {
                Count--;
            }
            return oldLast.Value;
            //Not Tested
        }
        public int GetCount()
        {
            return Count;
        }
    }
}
