using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }
}
