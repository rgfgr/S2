using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        x++;
                    }
                }
            }
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
