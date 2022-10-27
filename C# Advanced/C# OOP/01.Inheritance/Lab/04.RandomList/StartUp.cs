using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("6");
            list.Add("8");
            list.Add("10");

            Console.WriteLine(list.RandomString());
        }
    }
}
