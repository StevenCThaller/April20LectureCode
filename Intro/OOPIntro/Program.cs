using System;
using System.Collections.Generic;

namespace OOPIntro
{
    class IceCream
    {
        public string Flavor;
        public string Color;
        private List<string> Ingredients;

        public IceCream()
        {
            Flavor = "Vanilla";
            Color = "Off-White";
            Ingredients = new List<string>{"Vanilla extract", "Milk", "Sugar", "Ice", "Cream" };
        }
        public IceCream(string flava)
        {
            Flavor = flava;
            Color = "Puke Green";
            Ingredients = new List<string>{"Ice", "Cream", "Mystery Chemical #72"};
        }
        public IceCream(string flava, List<string> ingreeds, string color = "White")
        {
            Flavor = flava;
            Color = color;
            if(ingreeds == null)
            {
                Ingredients = new List<string>();
            }
            else 
            {
                Ingredients = ingreeds;
            }
        }

        public List<IceCream> MassProduce(int quantity)
        {
            List<IceCream> forStores = new List<IceCream>();

            for(int i = 0; i < quantity; i++)
            {
                for(int j = 0; j < this.Ingredients.Count; j++)
                {
                    System.Console.WriteLine($"Adding {this.Ingredients[j]} to the Ice Cream!");
                }
                System.Console.WriteLine($"{i+1} Ice Creams have been produced!");
                forStores.Add(this);
            }
            System.Console.WriteLine($"Now shipping out {quantity} of {Flavor} Ice cream");
            return forStores;
        }

    }


    class Human 
    {
        public string Name;
        private DateTime birthDay;

        public DateTime BirthDay
        {
            get { return birthDay; }
        }

        public Human(string name)
        {
            Name = name;
            birthDay = new DateTime(1990, 1, 1);
        }        
    }



    class Program
    {
        static void Main(string[] args)
        {
            // List<string> ingredients = new List<string>{"Apples", "Graham Crackers", "Sugar", "Ice", "Cream"};
            // IceCream grannysIceCream = new IceCream("Apple Pie", ingredients);
            
            // grannysIceCream.MassProduce(10);

            Human Joe = new Human("Joe Exotic");
            System.Console.WriteLine(Joe.Name);
            System.Console.WriteLine(Joe.BirthDay);
        }
    }
}
