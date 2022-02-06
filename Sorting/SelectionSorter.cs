using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SelectionSorter : ISorter
    {
        public int[] Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var currentElement = arr[i];
                var minElement = int.MaxValue;
                var minElementIndex = int.MaxValue;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (minElement > arr[j])
                    {
                        minElement = arr[j];
                        minElementIndex = j;
                    }
                }
                if (minElement < currentElement)
                {
                    var temp = arr[i];
                    arr[i] = arr[minElementIndex];
                    arr[minElementIndex] = temp;
                }
            }
            return arr;
        }


    }
}
