using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
        }

        public bool Move()
        {
            if (index + 1 < elements.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < elements.Count - 1;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(elements[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
