
namespace BirthdayCelebrations
{
    using BirthdayCelebrations.Core;
    using BirthdayCelebrations.Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
