using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            List = new List<T>();
        }

        public List<T> List { get; set; }

        public int Count(T comparisonElement)
        {
            int count = 0;
            foreach (var item in List)
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
