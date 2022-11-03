using System;
namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative, nameof(this.Length)));
                }

                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative, nameof(this.Width)));
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative, nameof(this.Height)));
                }
                height = value;
            }
        }

        public double SurfaceArea()
            => 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;

        public double LateralSurfaceArea()
            =>  2 * Length * Height + 2 * Width * Height;

        public double Volume()
           =>  Length * Width * Height;

    }
}
