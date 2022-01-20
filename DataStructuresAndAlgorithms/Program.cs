using System;
using Trees.AVL_Tree;
using Trees.B_Tree;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var avl = new AVLTree<int>();
            avl.Add(5);
            avl.Add(6);
            avl.Add(7);
            avl.Add(3);
            avl.Add(8);
            avl.Add(9);
            avl.Add(10);
            Console.WriteLine(avl.Contains(5));
            Console.WriteLine(avl.Contains(50));
            avl.Show();
        }
    }
}
