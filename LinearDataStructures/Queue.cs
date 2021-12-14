

using DataStructuresAndAlgorithms;

namespace StackQueue
{
    public class Queue<T>
    {
        private LinkedList<T> linkedList;
        public Queue() //LIFO
        {
            linkedList = new LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            linkedList.AddLast(element);
        }

        public T Dequeue()
        {
            return linkedList.RemoveHead();
        }

        public T Peek()
        {
            return linkedList.Head.Value;
        }
    }
}
