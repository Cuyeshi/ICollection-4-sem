using System;
using System.Collections;
using System.Collections.Generic;

namespace ICollectionLibrary
{
    public class MyCollection<T> : ICollection<T>, IEnumerable<T>
    {
        private T[] items;
        private int count;

        public MyCollection()
        {
            items = new T[100];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                throw new InvalidOperationException("Коллекция полна");
            }

            items[count] = item;
            count++;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            Array.Copy(items, index + 1, items, index, count - index - 1);
            count--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + ((right - left) / 2);

                int result = array[middle].CompareTo(value);

                if (result == 0)
                    return middle;
                else if (result < 0)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1; // Элемент не найден
        }
    }
}


