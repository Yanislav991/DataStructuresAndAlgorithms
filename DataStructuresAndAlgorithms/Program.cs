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
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Delete(7);
            tree.PrintTree();
        }
    }
}
