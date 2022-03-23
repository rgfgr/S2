using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEntities
{
    public class Square : Rectangle
    {
        private static readonly double width;

        public Square(int x, int y, double length) : base(x, y, length, width)
        {
            this.X = x;
            this.Y = y;
            this.Length = length;
        }

        public override string ToString()
        {
            return $"Position: ({X},{Y}), Length: {Length}\nArea: {CalculateArea()}, Circumference: {CalculateCircumference()}";
        }
    }
}
