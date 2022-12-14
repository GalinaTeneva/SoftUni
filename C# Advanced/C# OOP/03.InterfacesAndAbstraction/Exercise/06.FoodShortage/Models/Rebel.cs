
namespace FoodShortage.Models
{
    using Interfaces;

    public class Rebel : IRebel, IBuyer
    {
        private const int RebelFoodIncreaser = 5;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Group { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += RebelFoodIncreaser;
        }
    }
}
