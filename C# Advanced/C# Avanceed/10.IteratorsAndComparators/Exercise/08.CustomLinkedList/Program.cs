using CustomDoublyLinkedList;
using System;

namespace _08.CustomLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> doubly = new DoublyLinkedList<int>();

            doubly.AddFirst(5);
            doubly.AddFirst(4);
            doubly.AddFirst(3);

            doubly.AddLast(5);
            doubly.AddLast(4);
            doubly.AddLast(3);

            foreach (var item in doubly)
            {
                Console.WriteLine(item);
            }
        }
    }
}
