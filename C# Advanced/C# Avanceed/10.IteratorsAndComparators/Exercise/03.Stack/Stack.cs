using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public Stack()
        {
            items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T elementToRemove = items[Count - 1];
            Count--;
            return elementToRemove;
        }

        private void Resize()
        {
            T[] extendedArr = new T[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                extendedArr[0] = items[0];
            }

            items = extendedArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
