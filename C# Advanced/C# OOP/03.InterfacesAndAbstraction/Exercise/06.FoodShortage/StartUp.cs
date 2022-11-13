
namespace FoodShortage
{
    using FoodShortage.Core;
    using FoodShortage.Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
