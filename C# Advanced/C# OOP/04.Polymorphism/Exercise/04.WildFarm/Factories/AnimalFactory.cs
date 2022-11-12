
namespace WildFarm.Factories
{
    using Interfaces;
    using Models.Interfaces;
    using Models.Animals;
    using Exceptions;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] cmdTokens)
        {
            string type = cmdTokens[0];
            string name = cmdTokens[1];
            double weight = double.Parse(cmdTokens[2]);
            string fourthToken = cmdTokens[3];

            IAnimal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(fourthToken));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(fourthToken));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, fourthToken);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, fourthToken);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, fourthToken, cmdTokens[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, fourthToken, cmdTokens[4]);
            }
            else
            {
                throw new InvalidAnimalTypeException();
            }

            return animal;
        }
    }
}
