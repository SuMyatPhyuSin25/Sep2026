using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp
{
    public class Car
    {

        public string model;
        public string color;
        public int year;
        public string country;

        public decimal price2;//field

        public decimal Price2
        {// property
            get { return price2; }// get method
            set {
                Console.WriteLine("Old value: " + price2);
                price2 = value;
                Console.WriteLine("New value: " + price2);

            } // set method
        }

        

        public Car(string modelName, string carColor, int carYear, string countryName)//constructor
        {
            model = modelName;
            color = carColor;
            year = carYear;
            country = countryName;
           
        }

        public void Drive()
        {

            Console.WriteLine("This car can drive in 100 km per hour.");
        }
    }
}
