using System;
using System.Collections.Generic;

namespace OOP
{

    //public class Vehicle
    //{
    //    public int numPassengers;

    //    // CLASS CONSTRUCTOR
    //    public Vehicle(int num)
    //    {
    //        numPassengers = num;
    //    }
    //}

    public class Human
    {
        //fields
        public string name;
        public int stregnth;
        public int intelligence;
        public int dexterity;
        // changed to protected to access in child classes
        public int health;

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

        public virtual int Attack(Human target)
        {
            target.health = target.health - (5 * stregnth);
            return target.Health;
        }
    }

    public class Wizard : Human
    {

        public Wizard(string name) : base(name)
        {
            intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            
            int dmg = 5 * intelligence;
            target.health -= dmg;
            health += dmg;
            return target.health;
        }

        public void Heal(Human target)
        {
            target.health += 10 * intelligence;
        }


    }

    public class Assassin : Human
    {
        public Assassin(string name) : base(name)
        {
            dexterity = 175;
        }

        public override int Attack(Human target)
        {

            int dmg = 5 * dexterity;
            target.health -= dmg;
            
            return target.health;
        }

        public void Steal(Human target)
        {
            target.health -= 5;
            health = +5;
        }

    }

    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }


        public override int Attack(Human target)
        {

            if (target.health <= 50)
            {
                target.health = 0;
            } else
            {
                base.Attack(target);
            }
            
            return target.health;
        }

        public void Meditate()
        {
            health = 200;
        }

    }










    interface IConsumable
    {
        string Name { get; set; }
        int Calories { get; set; }
        bool IsSpicy { get; set; }
        bool IsSweet { get; set; }
        string GetInfo();
    }

    public class Food : IConsumable
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }
        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int calories, bool spicy, bool sweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    public class Drink : IConsumable
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }

        public string GetInfo()
        {
            return $"{Name} ; Calories {Calories} ; Spicy? {IsSpicy} ;  Sweet {IsSweet}. ";
        }

        public Drink(string name, int calories, bool spicy)
        {
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = true;
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


    // old ninja
    //public class Ninja
    //{
    //    private int calorieIntake;
    //    public List<Food> FoodHistory = new List<Food>();

    //    public void Cal()
    //    {
    //        calorieIntake = 0;
    //    }

    //    public bool IsFull
    //    {
    //        get
    //        {
    //            if (calorieIntake > 1200)
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }

    //        }
    //    }

    //    public void Eat(Food food)
    //    {
    //        if (IsFull)
    //        {
    //            Console.WriteLine("This Ninja is Full.");
    //        }
    //        else
    //        {
    //            calorieIntake = calorieIntake + food.Calories;
    //            FoodHistory.Add(food);
    //            Console.WriteLine($"{food.Name}; Spicy:{food.IsSpicy}; Sweet:{food.IsSweet}.");
    //            Console.WriteLine(calorieIntake);

    //            for (int i = 0; i < FoodHistory.Count; i++)
    //            {
    //                Console.WriteLine(FoodHistory[i].Name);
    //            }
    //            Console.WriteLine(FoodHistory.Count);
    //        }

    //    }

    //}

    abstract class Ninja
    {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        public abstract bool IsFull { get; }
        public abstract void Consume(IConsumable item);
    }

    class SweetTooth : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull
        {
            get
            {
                if (calorieIntake >= 1500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public override void Consume(IConsumable item)
        {
            // provide override for Consume
            if (IsFull)
            {
                Console.WriteLine("Sorry I am full");
            } else
            {
                calorieIntake += item.Calories;
                ConsumptionHistory.Add(item);
            }


        }
    }










    public class Card
    {
        private string stringVal;
        private string suit;
        private int val;

        public Card(string StringVal, string Suit, int Val)
        {
            stringVal = StringVal;
            suit = Suit;
            val = Val;
        }
    }

    public class Deck
    {
        public List<Card> cards = new List<Card>()
        {
            new Card("Ace", "Spades", 1),
            new Card("2", "Spades", 2),
            new Card("3", "Spades", 3),
            new Card("4", "Spades", 4),
            new Card("5", "Spades", 5),
            new Card("6", "Spades", 6),
            new Card("7", "Spades", 7),
            new Card("8", "Spades", 8),
            new Card("9", "Spades", 9),
            new Card("10", "Spades", 10),
            new Card("Jack", "Spades", 11),
            new Card("Queen", "Spades", 12),
            new Card("King", "Spades", 13),
            new Card("Ace", "Clubs", 1),
            new Card("2", "Clubs", 2),
            new Card("3", "Clubs", 3),
            new Card("4", "Clubs", 4),
            new Card("5", "Clubs", 5),
            new Card("6", "Clubs", 6),
            new Card("7", "Clubs", 7),
            new Card("8", "Clubs", 8),
            new Card("9", "Clubs", 9),
            new Card("10", "Clubs", 10),
            new Card("Jack", "Clubs", 11),
            new Card("Queen", "Clubs", 12),
            new Card("King", "Clubs", 13),
            new Card("Ace", "Hearts", 1),
            new Card("2", "Hearts", 2),
            new Card("3", "Hearts", 3),
            new Card("4", "Hearts", 4),
            new Card("5", "Hearts", 5),
            new Card("6", "Hearts", 6),
            new Card("7", "Hearts", 7),
            new Card("8", "Hearts", 8),
            new Card("9", "Hearts", 9),
            new Card("10", "Hearts", 10),
            new Card("Jack", "Hearts", 11),
            new Card("Queen", "Hearts", 12),
            new Card("King", "Hearts", 13),
            new Card("Ace", "Diamonds", 1),
            new Card("2", "Diamods", 2),
            new Card("3", "Diamods", 3),
            new Card("4", "Diamods", 4),
            new Card("5", "Diamods", 5),
            new Card("6", "Diamods", 6),
            new Card("7", "Diamods", 7),
            new Card("8", "Diamods", 8),
            new Card("9", "Diamods", 9),
            new Card("10", "Diamonds", 10),
            new Card("Jack", "Diamonds", 11),
            new Card("Queen", "Diamonds", 12),
            new Card("King", "Diamonds", 13),
        };
        
        public Card deal()
        {
            cards.Remove(cards[0]);

            return cards[0];
        }

        public void reset()
        {
            cards = new List<Card>()
        {
            new Card("Ace", "Spades", 1),
            new Card("2", "Spades", 2),
            new Card("3", "Spades", 3),
            new Card("4", "Spades", 4),
            new Card("5", "Spades", 5),
            new Card("6", "Spades", 6),
            new Card("7", "Spades", 7),
            new Card("8", "Spades", 8),
            new Card("9", "Spades", 9),
            new Card("10", "Spades", 10),
            new Card("Jack", "Spades", 11),
            new Card("Queen", "Spades", 12),
            new Card("King", "Spades", 13),
            new Card("Ace", "Clubs", 1),
            new Card("2", "Clubs", 2),
            new Card("3", "Clubs", 3),
            new Card("4", "Clubs", 4),
            new Card("5", "Clubs", 5),
            new Card("6", "Clubs", 6),
            new Card("7", "Clubs", 7),
            new Card("8", "Clubs", 8),
            new Card("9", "Clubs", 9),
            new Card("10", "Clubs", 10),
            new Card("Jack", "Clubs", 11),
            new Card("Queen", "Clubs", 12),
            new Card("King", "Clubs", 13),
            new Card("Ace", "Hearts", 1),
            new Card("2", "Hearts", 2),
            new Card("3", "Hearts", 3),
            new Card("4", "Hearts", 4),
            new Card("5", "Hearts", 5),
            new Card("6", "Hearts", 6),
            new Card("7", "Hearts", 7),
            new Card("8", "Hearts", 8),
            new Card("9", "Hearts", 9),
            new Card("10", "Hearts", 10),
            new Card("Jack", "Hearts", 11),
            new Card("Queen", "Hearts", 12),
            new Card("King", "Hearts", 13),
            new Card("Ace", "Diamonds", 1),
            new Card("2", "Diamods", 2),
            new Card("3", "Diamods", 3),
            new Card("4", "Diamods", 4),
            new Card("5", "Diamods", 5),
            new Card("6", "Diamods", 6),
            new Card("7", "Diamods", 7),
            new Card("8", "Diamods", 8),
            new Card("9", "Diamods", 9),
            new Card("10", "Diamonds", 10),
            new Card("Jack", "Diamonds", 11),
            new Card("Queen", "Diamonds", 12),
            new Card("King", "Diamonds", 13),
        };
        }
}

    class Vehicle
    {
        public int NumPassengers;
        public string Color;
        public double Odometer;
        // Say Vechicle has two overloaded constructors
        // We will either need to pass up two values (int, string), from Car ...
        public Vehicle(int numPas, string col)
        {
            NumPassengers = numPas;
            Color = col;
            Odometer = 0;
        }
        // Or just one string value.  
        public Vehicle(string col)
        {
            NumPassengers = 5;
            Color = col;
            Odometer = 0;
        }

    }
    // Defining a child class of Vehicle
    class Car : Vehicle
    {
        // We can add members that are unique to Cars, things that won't describe ALL vehicles
        public string Make;
        public string Model;
        // but when we define a constructor for Car, we need to satisfy any constructor requirements
        // for at least ONE constructor on the parent Vehicle class
        public Car(string color, string make, string model) : base(color)
        {
            Make = make;
            Model = model;
        }
    }











    class Program
    {
        static void Main(string[] args)
        {

            Food apple = new Food("Apple", 25, false, true);
            Console.WriteLine(apple.GetInfo());













            //Wizard devin = new Wizard("devin");
            //Assassin chrisy = new Assassin("christy");

            //devin.Attack(chrisy);
            
            








            //Deck myDeck = new Deck();
            //Console.WriteLine(myDeck.deal());
            //Console.WriteLine(myDeck.deal());
            //Console.WriteLine(myDeck.deal());
            //Console.WriteLine(myDeck.deal());

            //Console.WriteLine(myDeck.cards.Count);

            //myDeck.reset();
            //Console.WriteLine(myDeck.cards.Count);






            // hungry ninja, use Food, Buffet, and Ninja classes
            //Buffet buffet = new Buffet();
            //Ninja devin = new Ninja();
            //devin.Eat(buffet.Serve());
            //devin.Eat(buffet.Serve());
            //devin.Eat(buffet.Serve());
            //devin.Eat(buffet.Serve());
            //devin.Eat(buffet.Serve());
            //devin.Eat(buffet.Serve());





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
