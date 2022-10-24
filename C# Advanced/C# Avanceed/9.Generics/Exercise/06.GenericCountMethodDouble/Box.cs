using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public int Count(T comparisonElement)
        {
            int count = 0;

            foreach (var item in Items)
            {
                if (item.CompareTo(comparisonElement) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
