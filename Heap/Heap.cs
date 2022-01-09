using System;
using System.Collections.Generic;

namespace HeapAndPriorityQueue
{
    public class Heap<T> where T : IComparable<T>
    {
        private List<T> heap;
        public Heap()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return this.heap.Count; } }
        public T Peek()
        {
            return this.heap[0];
        }
        public void Add(T element) 
        {
            this.heap.Add(element);
            Hepify(this.heap.Count - 1);
        }

        private void Hepify(int index)
        {
            if (index == 0) return;
            var parentIndex = (index - 1) / 2;
            if (this.heap[index].CompareTo(this.heap[parentIndex]) > 0)
            {
                var temp = this.heap[index];
                this.heap[index] = this.heap[parentIndex];
                this.heap[parentIndex] = temp;
                Hepify(parentIndex);
            }
        }
    }
}
