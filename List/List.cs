using System;

namespace List
{
    public class List<T>
    {
        private T[] array;
        private int index;
        public List(int initialCapacity = 4)
        {
            this.array = new T[initialCapacity];
        }

        public int Count
        {
            get
            { return this.array.Length; }
        }
        public T this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        private void Grow()
        {
            T[] newArray = new T[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }
        public void Add(T item)
        {
            if (index == array.Length)
            {
                Grow();
            }

            array[index++] = item;
        }

        public void Clear(int newCapacity = 4)
        {
            this.array = new T[newCapacity];
        }

        public bool Contains(T item)
        {
            bool isFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i].Equals(item))
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].Equals(item))
                {
                    index = i;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            T[] newarr = new T[this.array.Length + 1];

            for (int i = 0; i < this.array.Length+1; i++)
            {
                if(i< index - 1)
                {
                    newarr[i] = this.array[i];

                }
                else if (i==index-1)
                {
                    newarr[i] = item;
                }
                else
                {
                    newarr[i] = this.array[i - 1];
                }
            }

        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

    }
}
