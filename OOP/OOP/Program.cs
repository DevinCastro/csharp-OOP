using System;
using System.Collections.Generic;

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

    public class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string name, int cal, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }

    public class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Sushi", 300, true, false),
                new Food("steak", 300, false, false),
                new Food("chicken", 300, false, false),
                new Food("Shrimp", 300, true, false),
                new Food("noodles", 500, true, false),
                new Food("banana", 100, false, true),
                new Food("apple", 100, false, true),
            };

        }
        public Food Serve()
        {
            Random rand = new Random();
            Food food = Menu[rand.Next(1, 7)];
            return food;
        }

    }

    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory = new List<Food>();

        public void Cal()
        {
            calorieIntake = 0;
        }

        public bool IsFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public void Eat(Food food)
        {
            if (IsFull)
            {
                Console.WriteLine("This Ninja is Full.");
            }
            else
            {
                calorieIntake = calorieIntake + food.Calories;
                FoodHistory.Add(food);
                Console.WriteLine($"{food.Name}; Spicy:{food.IsSpicy}; Sweet:{food.IsSweet}.");
                Console.WriteLine(calorieIntake);

                for (int i = 0; i < FoodHistory.Count; i++)
                {
                    Console.WriteLine(FoodHistory[i].Name);
                }
                Console.WriteLine(FoodHistory.Count);
            }

        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            //Console.WriteLine(buffet.Serve());
            Ninja devin = new Ninja();
            devin.Eat(buffet.Serve());
            devin.Eat(buffet.Serve());
            devin.Eat(buffet.Serve());
            devin.Eat(buffet.Serve());
            devin.Eat(buffet.Serve());
            devin.Eat(buffet.Serve());





            //Human Devin = new Human("Devin");
            //Human Christy = new Human("Christy", 5, 5, 2, 150);
            //Console.WriteLine(Christy.Attack(Devin));
            //Console.WriteLine(Devin.Attack(Christy));
            Console.ReadLine();


            //Vehicle mustang = new Vehicle(5);

            //Console.WriteLine($"Hello World! My car can hold {mustang.numPassengers} people");
        }
    }
}
