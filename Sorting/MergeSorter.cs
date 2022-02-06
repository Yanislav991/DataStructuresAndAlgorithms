using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSorter : ISorter
    {
        public int[] Sort(int[] arr)
        {
            return this.Sort(arr, 0, arr.Length - 1);
        }

        private int[] Sort(int[] arr, int start, int end)
        {
            if (end > start)
            {
                var middle = (start + end) / 2;
                Sort(arr, start, middle);
                Sort(arr, middle + 1, end);
                Merge(arr, start, middle, end);
            }
            return arr;
        }

        private void Merge(int[] arr, int start, int middle, int end)
        {
            int firstSize = middle - start + 1;
            int secondSize = end - middle;
            var leftArray = new int[firstSize];
            var rightArray = new int[secondSize];

            //Copy the data into 2 arrays
            Array.Copy(arr, start, leftArray, 0, middle - start + 1);
            Array.Copy(arr, middle + 1, rightArray, 0, end - middle);

            //actual merge of the arrays
            int firstArrayIndex = 0;
            int secondArrayIndex = 0;
            for (int i = start; i < end + 1; i++)
            {
                if (firstArrayIndex == leftArray.Length)
                {
                    arr[i] = rightArray[secondArrayIndex];
                    secondArrayIndex++;
                }
                else if (secondArrayIndex == rightArray.Length)
                {
                    arr[i] = leftArray[firstArrayIndex];
                    firstArrayIndex++;
                }
                else if (leftArray[firstArrayIndex] <= rightArray[secondArrayIndex])
                {
                    arr[i] = leftArray[firstArrayIndex];
                    firstArrayIndex++;
                }
                else
                {
                    arr[i] = rightArray[secondArrayIndex];
                    secondArrayIndex++;
                }
            }

        }
    }
}
