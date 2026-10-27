using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp
{
    abstract class Pet
    { // abstraction

        public abstract void animalSound();//abstract method

        public void sleep()
        {
            Console.WriteLine("Zzp!");
        }
    }

    class Pig : Pet
    {
        public override void animalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }

    }
}
