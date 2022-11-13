
namespace BirthdayCelebrations.Models
{
    using Interfaces;

    public class Robot : IRobot
    {
        public Robot (string id, string model)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}
