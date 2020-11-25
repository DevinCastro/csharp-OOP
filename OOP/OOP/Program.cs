using System;

namespace OOP
{

    public class Vehicle
    {
        public int numPassengers;

        // CLASS CONSTRUCTOR
        public Vehicle(int num)
        {
            numPassengers = num;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Vehicle mustang = new Vehicle(5);

            Console.WriteLine($"Hello World! My car can hold {mustang.numPassengers} people");
        }
    }
}
