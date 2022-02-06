using Excercises;
using Sorting;
using System;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ISorter sorter = new MergeSorter();
            var sortedArr = sorter.Sort(new int[] { 2, 1, 3, 1 });
            Console.WriteLine(String.Join(", ", sortedArr));
        }
    }
}
