
namespace BirthdayCelebrations.Models.Interfaces
{
    public interface ICitizen : IIdable, ILivingCreature
    {
        int Age { get; }
    }
}
