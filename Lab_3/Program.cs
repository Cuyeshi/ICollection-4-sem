using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_3
{
    public class CustomCollection<T> : ICollection<T>
    {
        private T[] items;

        public CustomCollection()
        {
            items = new T[0];
        }

        public int Count => items.Length;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public void Clear()
        {
            items = new T[0];
        }

        public bool Contains(T item)
        {
            foreach (T element in items)
            {
                if (EqualityComparer<T>.Default.Equals(element, item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, items.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
            T[] newItems = new T[items.Length - 1];
            Array.Copy(items, 0, newItems, 0, index);
            Array.Copy(items, index + 1, newItems, index, items.Length - index - 1);
            items = newItems;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
