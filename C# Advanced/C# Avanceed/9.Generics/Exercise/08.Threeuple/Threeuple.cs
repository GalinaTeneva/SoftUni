using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }
        public T3 ItemThree { get; set; }


        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";
        }
    }
}
