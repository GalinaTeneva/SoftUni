using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
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
            (List[indexOne], List[indexTwo]) = (List[indexTwo], List[indexOne]);
        }
    }
}
