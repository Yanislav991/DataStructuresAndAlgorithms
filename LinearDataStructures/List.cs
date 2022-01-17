namespace List
{
    public class List<T>
    {
        private T[] array;
        private int index;
        public List(int initialCapacity = 4)
        {
            array = new T[initialCapacity];
        }

        public int Count
        {
            get
            { return array.Length; }
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
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
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
            array = new T[newCapacity];
        }

        public bool Contains(T item)
        {
            bool isFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    index = i;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            T[] newarr = new T[array.Length + 1];

            for (int i = 0; i < array.Length + 1; i++)
            {
                if (i < index - 1)
                {
                    newarr[i] = array[i];

                }
                else if (i == index - 1)
                {
                    newarr[i] = item;
                }
                else
                {
                    newarr[i] = array[i - 1];
                }
            }

        }
        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = 0; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[Count - 1] = default;
            this.index--;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of Range");
            }
        }

    }
}
