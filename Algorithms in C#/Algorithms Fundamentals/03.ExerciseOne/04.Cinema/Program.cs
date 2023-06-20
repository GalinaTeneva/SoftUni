using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Cinema
{
    internal class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            while(true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "generate")
                {
                    break;
                }

                string[] personInfo = inputLine.Split(" - ");
                string name = personInfo[0];
                int position = int.Parse(personInfo[1]) - 1;

                people[position] = name;
                locked[position] = true;

                nonStaticPeople.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                PrintPermutation();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintPermutation()
        {
            int nonStaticIdx = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = nonStaticPeople[nonStaticIdx++];
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static void Swap(int first, int second)
        {
            string temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}