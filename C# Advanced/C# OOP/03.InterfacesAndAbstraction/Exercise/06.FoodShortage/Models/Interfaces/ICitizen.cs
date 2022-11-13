
namespace FoodShortage.Models.Interfaces
{
    public interface ICitizen : IPerson
    {
        string Id { get; }

        string Birthdate { get; }
    }
}
