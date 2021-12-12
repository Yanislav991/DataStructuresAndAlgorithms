

using DataStructuresAndAlgorithms;

namespace StackQueue
{
    public class Queue<T>
    {
        private LinkedList<T> linkedList;
        public Queue() //LIFO
        {
            this.linkedList = new LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            this.linkedList.AddLast(element);
        }

        public T Dequeue()
        {
            return this.linkedList.RemoveHead();
        }

        public T Peek()
        {
            return this.linkedList.Head.Value;
        }
    }
}
