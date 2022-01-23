using System;
using Trees.AVL_Tree;
using Trees.B_Tree;
using Trees.RedBlack_Tree;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new RedBlackTree<int>();
            for (int i = 1; i < 10; i++)
            {
                tree.Insert(i);
            }
            tree.PrintTree(10);
        }
    }
}
