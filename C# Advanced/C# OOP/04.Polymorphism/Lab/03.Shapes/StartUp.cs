using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            Shape shape = null;
            if (type == "Circle")
            {
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
            }
            else if (type == "Rectangle")
            {
                double height = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());

                shape = new Rectangle(height, width);
            }

            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
        }
    }
}
