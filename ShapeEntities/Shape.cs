using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeEntities
{
    public abstract class Shape
    {
        //Fields of the shape parent class
        protected int x;
        protected int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Shape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        //Abstract funtions of the shape parent class
        public abstract double CalculateArea();
        public abstract double CalculateCircumference();
        public override string ToString()
        {
            return $"Position: ({X},{Y})";
        }
    }
}
