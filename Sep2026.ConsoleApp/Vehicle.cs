using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp
{
    //inheritance
    class Vehicle
    {
        public string brand = "Ford";
        public void honk()
        {
            Console.WriteLine("Tutt, tutt");
        }
    }

    class MyCar : Vehicle
    {
        public string modelName = "Mustang";
    }
}
