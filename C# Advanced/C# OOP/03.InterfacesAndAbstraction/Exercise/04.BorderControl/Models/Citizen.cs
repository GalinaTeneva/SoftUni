
namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IVisitor, ICitizen
    {
        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
