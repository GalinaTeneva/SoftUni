using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle (double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public sealed override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public sealed override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
