
using DataStructuresAndAlgorithms;
using System;

namespace StackQueue
{
    public class Stack<T>
    {
        private LinkedList<T> linkedList;
        public Stack() //LIFO
        {
            this.linkedList = new LinkedList<T>();
        }

        public void Push(T element)
        {
            this.linkedList.Add(element);
        }

        public T Pop()
        {
            return this.linkedList.RemoveHead();
        }

        public T Peek()
        {
            return this.linkedList.Head.Value;
        }
    }
}
//Stack<int> stack = new Stack<int>();
//stack.Push(5);
//stack.Push(10);
//System.Console.WriteLine(stack.Peek()); // expect 10
//var popped = stack.Pop();
//System.Console.WriteLine(popped); // 10
//System.Console.WriteLine(stack.Peek()); // expect 5