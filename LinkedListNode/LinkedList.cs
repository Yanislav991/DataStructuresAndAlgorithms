using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int GetCount()
        {
            return this.Count;
        }
    }
}
//LinkedList<int> linkedList = new LinkedList<int>();
//linkedList.Add(5);
//linkedList.AddLast(10);
//var currItem = linkedList.Head;
//while (currItem != null)
//{

//    System.Console.WriteLine(currItem.Value);
//    currItem = currItem.Next;
//}
//System.Console.WriteLine(linkedList.Remove());
//System.Console.WriteLine(linkedList.RemoveLast());