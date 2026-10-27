// See https://aka.ms/new-console-template for more information
using Sep2026.ConsoleApp;

Console.Write("Enter number1: ");
string num1 = Console.ReadLine()!;
int number1 = Convert.ToInt32(num1);

Console.Write("Enter number2: ");
string num2 = Console.ReadLine()!;

 int number2 = Convert.ToInt32(num2);

int result = number1 + number2;

Console.WriteLine($"Result is {result}");




Car Toyota = new Car("Mustang", "Red", 2015, "Germany");

Console.WriteLine(Toyota.model);
Toyota.Drive();

//Toyota.Price2 = 3000;
//Toyota.Price2 = 2000;

//Console.Write(Toyota.Price2);
Toyota.Price2 = 3000;
Toyota.Price2 = 2000;




MyCar newCar = new MyCar();
newCar.honk();
Console.WriteLine(newCar.brand + " " + newCar.modelName);


Animal myAnimal = new Animal();
myAnimal.makeSound();

Dog dogAnimal = new Dog();
dogAnimal.makeSound();

Cat catAnimal = new Cat();
catAnimal.makeSound();




Pig smallPig = new Pig();
smallPig.animalSound();


Student newStudent = new Student();
newStudent.sleep();

EnumTransfer enumTransferType = EnumTransfer.TransferOther;

switch (enumTransferType)

{

    case EnumTransfer.TransferOther:
        break;
    case EnumTransfer.OrderTransfer:
        break;

    default:
        break;
}

enum EnumTransfer
{

    None,
     TransferOther,
    OrderTransfer,
    TakeOther


}






