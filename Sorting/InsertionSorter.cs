using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter : ISorter
    {
        public int[] Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int current = arr[i];
                int previousIndex = i - 1;
                while (previousIndex >= 0 && arr[previousIndex] > current)
                {
                    arr[previousIndex + 1] = arr[previousIndex];
                    previousIndex--;
                }
                arr[previousIndex + 1] = current;
            }
            return arr;
        }
    }
}
