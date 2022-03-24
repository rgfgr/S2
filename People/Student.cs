using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Student : Person
    {
        public static readonly string role = "Elev";
        public Student(string name, int age, string køn, string email, string telfnr) : base(name, age, køn, role, email, telfnr)
        {
        }
    }
}
