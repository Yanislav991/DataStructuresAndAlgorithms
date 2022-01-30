using HashSet;
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
            var hashtset = new HashSet<string>(8, 50);
            hashtset.Add("aa");
            hashtset.Add("ab");
            hashtset.Add("zz");
            hashtset.Add("ca");
            hashtset.Add("dr");
            hashtset.Add("abzz");
            hashtset.Add("zzaa");
            hashtset.Add("caza");
            hashtset.Add("drzaq");
            hashtset.Add("aa2");
            hashtset.Add("ab3");
            hashtset.Add("zz4");
            hashtset.Add("ca5");
            foreach (var item in hashtset.internalArray)
            {
                if (item == null)
                {
                    Console.WriteLine("Empty slot");
                    continue;
                }
                Console.WriteLine(String.Join(", ", item));
            }
            Console.WriteLine($"Contains aa => {hashtset.Contains("aa")}");
            Console.WriteLine($"Contains aw => {hashtset.Contains("aw")}");
        }
    }
}
