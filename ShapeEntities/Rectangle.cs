using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEntities
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(int x, int y, double length, double width) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.Length = length;
            this.Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }

        public override double CalculateCircumference()
        {
            return Length * 2 + Width * 2;
        }

        public override string ToString()
        {
            return $"Position: ({X},{Y}), Length: {Length}, Width: {Width}\nArea: {CalculateArea()}, Circumference: {CalculateCircumference()}";
        }
    }
}
