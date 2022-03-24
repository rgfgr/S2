using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public abstract class Person
    {
        public string Navn { get; set; }
        public int Alder { get; set; }
        public string Køn { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Telfnr { get; set; }

        protected Person(string name, int age, string køn, string role, string email, string telfnr)
        {
            Navn = name;
            Alder = age;
            Køn = køn;
            Role = role;
            Email = email;
            Telfnr = telfnr;
        }
    }
}
