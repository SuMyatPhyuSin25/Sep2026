using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ConsoleApp
{
     class Animal //polymorphism
    {
        public virtual void makeSound()
        {
            Console.WriteLine("Animal can make sound!");
        }

        
    }

    class Dog : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Dog can make Woof Woof!");
        }
    }

    class Cat : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Cat can make Meow Meow!");
        }
    }
}
