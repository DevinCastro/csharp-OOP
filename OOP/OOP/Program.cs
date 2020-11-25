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

    public class Human
    {
        //fields
        public string name;
        public int stregnth;
        public int intelligence;
        public int dexterity;
        private int health;

        public int Health
        {
            get
            {
                return health;
            }
        }

        public Human(string humanName)
        {
            name = humanName;
            stregnth = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string Name, int Str, int Int, int Dex, int Healthh )
        {
            name = Name;
            stregnth = Str;
            intelligence = Int;
            dexterity = Dex;
            health = Healthh;
        }

        public int Attack(Human target)
        {
            target.health = target.health - (5 * stregnth);
            return target.Health;
        }
    }





    class Program
    {
        static void Main(string[] args)
        {

            Human Devin = new Human("Devin");
            Human Christy = new Human("Christy", 5, 5, 2, 150);

            Console.WriteLine(Christy.Attack(Devin));
            Console.ReadLine();


            //Vehicle mustang = new Vehicle(5);

            //Console.WriteLine($"Hello World! My car can hold {mustang.numPassengers} people");
        }
    }
}
