using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box()
        {
            Elements = new List<T>();
        }

        public List<T> Elements {get; set;}


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Elements)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
