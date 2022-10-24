using System;

namespace PetStore
{
    class Program
    {
        static void Main(string[] args)
        {
            int packageForDogs = int.Parse(Console.ReadLine());
            int packageForCats = int.Parse(Console.ReadLine());
            
            double moneyForDogFood = packageForDogs * 2.50;
            int moneyForCatFood = packageForCats * 4;

            Console.WriteLine(moneyForDogFood + moneyForCatFood + " lv.");

            /*
            OR
            double totalMoney = moneyForDogFood + moneyForCatFood;
            Console.WriteLine(totalMoney + " lv.");
            */
        }
    }
}
