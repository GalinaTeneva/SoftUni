
namespace BorderControl
{
    using Core;
    using Core.Interfaces;

    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
