
namespace FoodShortage.Models.Interfaces
{
    public interface IPerson : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}
