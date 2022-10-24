using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box()
        {
            List = new List<T>();
        }

        public List<T> List { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in List)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }

        public void Swap(int indexOne, int indexTwo)
        {
            T elementOne = List[indexOne];
            T elementTwo = List[indexTwo];

            List[indexOne] = elementTwo;
            List[indexTwo] = elementOne;
        }
    }
}
