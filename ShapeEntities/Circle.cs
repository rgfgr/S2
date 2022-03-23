using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEntities
{
    public class Circle : Shape
    {
        protected double radius;

        public double Radius { get => radius; set => radius = value; }

        public Circle(int x, int y, double radius) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * (Radius * Radius);
        }
        public override double CalculateCircumference()
        {
            return 2 * Radius * Math.PI;
        }
        public override string ToString()
        {
            return $"Position: ({X},{Y}), Radius: {Radius}\nArea: {CalculateArea()}, Circumference: {CalculateCircumference()}";
        }
    }
}
