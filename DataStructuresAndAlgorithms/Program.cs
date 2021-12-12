
using StackQueue;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            System.Console.WriteLine(stack.Peek()); // expect 10
            var popped = stack.Pop();
            System.Console.WriteLine(popped); // 10
            System.Console.WriteLine(stack.Peek()); // expect 5

        }
    }
}
