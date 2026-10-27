using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp
{
    //interface
    interface IHuman
    {
        void sleep();


    }


    class Student : IHuman
    {
        //public void sleep()
        //{
        //    Console.WriteLine("The student sleeps!");
        //}
        public void sleep()
        {
            Console.WriteLine("The student sleeps!");

        }
    }
}
