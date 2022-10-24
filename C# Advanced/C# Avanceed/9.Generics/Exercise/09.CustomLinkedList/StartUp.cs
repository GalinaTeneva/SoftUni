using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
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

            doubly.RemoveFirst();

            doubly.RemoveLast();

            doubly.ForEach(e => Console.WriteLine(e));
            int[] array = doubly.ToArray();
            Console.WriteLine();
        }
    }
}
