using Trees.B_Tree;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree<int> b = new BTree<int>();
            b.Insert(8);
            b.Insert(9);
            b.Insert(10);
            b.Insert(11);
            b.Insert(15);
            b.Insert(20);
            b.Insert(17);

            b.Show();

            if (b.Contains(12))
            {
                global::System.Console.WriteLine("yes"); 
            }
            else
            {
                global::System.Console.WriteLine("no"); 
            }
        }
    }
}
