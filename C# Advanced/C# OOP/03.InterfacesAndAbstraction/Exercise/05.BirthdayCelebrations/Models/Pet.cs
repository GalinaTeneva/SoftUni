
namespace BirthdayCelebrations.Models
{
    using BirthdayCelebrations.Models.Interfaces;

    public class Pet : IPet
    {
        public Pet (string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

        public override string ToString()
        {
            return Birthdate;
        }
    }
}
