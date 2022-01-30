using System;
using System.Collections.Generic;

namespace HashSet
{
    public class HashSet<T> where T : IComparable<T>
    {
        //could be extended for event better performance if is used AVL or RB tree 
        public List<T>[] internalArray;
        private int fillCount = 0;
        private int loadFactor;
        public HashSet(int capacity = 8, int loadFactor = 75)
        {
            internalArray = new List<T>[capacity];
            this.loadFactor = loadFactor;

        }
        public void Add(T element)
        {
            this.Add(element, internalArray);
        }

        private void Resize()
        {
            var condition = ((float)fillCount / internalArray.Length * 100) > loadFactor;
            if (condition)
            {
                Console.WriteLine("Load factor is smaller than fill rate so we resize");
                List<T>[] newArray = new List<T>[internalArray.Length * 2];
                for (int i = 0; i < internalArray.Length; i++)
                {
                    if (internalArray[i] != null)
                    {
                        for (int j = 0; j < internalArray[i].Count; j++)
                        {
                            this.Add(internalArray[i][j], newArray, true);
                        }
                    }
                }
                this.internalArray = newArray;
            }
        }

        public bool Contains(T element)
        {
            int index = Math.Abs(Hash(element) % internalArray.Length);
            return this.Contains(index, element);

        }
        private void Add(T element, List<T>[] internalArray, bool isResizing = false)
        {
            int index = Math.Abs(Hash(element) % internalArray.Length);
            if (internalArray[index] == null)
            {
                internalArray[index] = new List<T>();
            }
            //prevent equal elements from being added in the set
            if (!isResizing && this.Contains(index, element))
            {
                return;
            }
            internalArray[index].Add(element);
            if (!isResizing)
            {
                fillCount++;
                Resize();
            }
        }
        private bool Contains(int index, T element)
        {
            //if is empty slot then we do not contain an element that gets the same hash code
            if (internalArray[index] == null)
            {
                return false;
            }
            // check in the array if such element exists
            for (int i = 0; i < internalArray[index].Count; i++)
            {
                if (internalArray[index][i].CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private int Hash(T element)
        {
            return element.GetHashCode();
        }
    }
}

//Manually tested {
//var hashtset = new HashSet<string>(8, 50);
//hashtset.Add("aa");
//hashtset.Add("ab");
//hashtset.Add("zz");
//hashtset.Add("ca");
//hashtset.Add("dr");
//hashtset.Add("abzz");
//hashtset.Add("zzaa");
//hashtset.Add("caza");
//hashtset.Add("drzaq");
//hashtset.Add("aa2");
//hashtset.Add("ab3");
//hashtset.Add("zz4");
//hashtset.Add("ca5");
//foreach (var item in hashtset.internalArray)
//{
//    if (item == null)
//    {
//        Console.WriteLine("Empty slot");
//        continue;
//    }
//    Console.WriteLine(String.Join(", ", item));
//}
//Console.WriteLine($"Contains aa => {hashtset.Contains("aa")}");
//Console.WriteLine($"Contains aw => {hashtset.Contains("aw")}");
//}