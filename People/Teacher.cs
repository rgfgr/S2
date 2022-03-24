using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Teacher : Person
    {
        public static readonly string role = "Lærer";
        public Teacher(string name, int age, string køn, string email, string telfnr) : base(name, age, køn, role, email, telfnr)
        {
        }
    }
}
