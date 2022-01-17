namespace HeapAndPriorityQueue
{
    public class PriorityQueue<T> : Heap<T> where T :IComparable<T>
    {
        public T Dequeue()
        {
            var top = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            HeapifyDown(0);
            return top;
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var maxChildIndex = leftChildIndex;
            if (leftChildIndex >= this.heap.Count) return; // we are at the bottom of the tree

            //describes which child has bigger value;
            if ((rightChildIndex<heap.Count) && this.heap[rightChildIndex].CompareTo(this.heap[leftChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (this.heap[maxChildIndex].CompareTo(this.heap[index]) > 0)
            {
                var temp = this.heap[index];
                this.heap[index] = this.heap[maxChildIndex];
                this.heap[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }

        }
    }
}
