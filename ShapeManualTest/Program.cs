using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeEntities;
namespace ShapeManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            while (true)
            {
                Console.WriteLine("Hvad vil du ha.");
                Console.WriteLine("Cirkel tryk på c");
                Console.WriteLine("Regtangel tryk på r");
                Console.WriteLine("Kvadrat tryk på k");
                char key = Console.ReadKey().KeyChar;
                Console.Write("Giv x position: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Giv så y position: ");
                int y = int.Parse(Console.ReadLine());
                switch (key){
                    case 'c':
                        Console.Write("Giv radius: ");
                        Circle circle = new Circle(x, y, double.Parse(Console.ReadLine()));
                        Console.WriteLine(circle.ToString());
                        shapes.Add(circle);
                        break;
                    case 'r':
                        Console.Write("Giv length og så width: ");
                        Rectangle rectangle = new Rectangle(x, y, double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                        Console.WriteLine(rectangle.ToString());
                        shapes.Add(rectangle);
                        break;
                    case 'k':
                        Console.Write("Giv length: ");
                        Square square = new Square(x, y, double.Parse(Console.ReadLine()));
                        Console.WriteLine(square.ToString());
                        shapes.Add(square);
                        break;

                }
                Console.WriteLine("tryk på knap");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
