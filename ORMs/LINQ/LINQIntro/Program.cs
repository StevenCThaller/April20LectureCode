using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQIntro
{
    class Hat
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public Hat(string color, string type)
        {
            Color = color;
            Type = type;
        }
    }
    class CatsInHats
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Hat> Hats { get; set; }
        public CatsInHats(string name, string color, List<Hat> hats)
        {
            Name = name;
            Color = color;
            Hats = hats;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hat redTopHat = new Hat("Red", "Top hat");
            Hat greenFedora = new Hat("Green", "Fedora");
            Hat blackBaseball = new Hat("Black", "Baseball cap");
            Hat greenSnapback = new Hat("Green", "Snapback");
            Hat chartreuseGoose = new Hat("Chartreuse", "Goose");
            Hat blackRoo = new Hat("Black", "Kangol");
            
            CatsInHats nelson = new CatsInHats("Nelson", "Orange and Black", new List<Hat>(){blackBaseball, greenSnapback});
            CatsInHats arthur = new CatsInHats("Arthur", "Black", new List<Hat>(){greenFedora, redTopHat, blackRoo});
            CatsInHats steve = new CatsInHats("Steve", "Grey", new List<Hat>(){chartreuseGoose, greenSnapback});
            CatsInHats leela = new CatsInHats("Leela", "Black and Tan", new List<Hat>(){redTopHat, blackBaseball});
            
            List<CatsInHats> allCats = new List<CatsInHats>(){nelson, arthur, steve, leela};

            /* **************** .Where() ==> all items in the collection matching the query **************** */
            
            // Cats named Arthur
            // Linq way
            List<CatsInHats> arthurs = allCats.Where(c => c.Name == "Arthur").ToList();
            
            // Non-Linq way            
            List<CatsInHats> arthurNL = new List<CatsInHats>();
            foreach(CatsInHats cat in allCats)
            {
                if(cat.Name == "Arthur")
                {
                    arthurNL.Add(cat);
                }
            }
            System.Console.WriteLine("********** Arthurs -- The Linq way ***********");
            arthurs.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("******** Arthurs -- The Non-Linq Way *********");
            arthurNL.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("**********************************************");
            // Cats with SOME black coloring
            // Linq way
            List<CatsInHats> kindaBlack = allCats
                .Where(c => c.Color.Contains("Black"))
                .ToList();

            // Non-Linq way
            List<CatsInHats> kindaBlackNL = new List<CatsInHats>();
            foreach(CatsInHats cat in allCats)
            {
                if(cat.Color.Contains("Black"))
                {
                    kindaBlackNL.Add(cat);
                }
            }
            System.Console.WriteLine("********** kindaBlack -- The Linq way ***********");
            kindaBlack.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("******** kindaBlack -- The Non-Linq Way *********");
            kindaBlackNL.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("**********************************************");

            // Cats with some black coloring and also have a black baseball cap
            // Linq-way
            List<CatsInHats> blackOnBlack = allCats
                .Where(c => c.Color.Contains("Black") && c.Hats.FirstOrDefault(h => h.Color == "Black" && h.Type == "Baseball cap") != null)
                .ToList();

            // Non-Linq way
            List<CatsInHats> blackOnBlackNL = new List<CatsInHats>();
            foreach(CatsInHats cat in allCats)
            {
                if(cat.Color.Contains("Black"))
                {
                    foreach(Hat hat in cat.Hats)
                    {
                        if(hat.Color == "Black" && hat.Type == "Baseball cap")
                        {
                            blackOnBlackNL.Add(cat);
                        }
                    }
                }
            }
            System.Console.WriteLine("********** blackOnBlack -- The Linq way ***********");
            blackOnBlack.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("******** blackOnBlack -- The Non-Linq Way *********");
            blackOnBlackNL.ForEach(a => Console.WriteLine(a.Name));
            System.Console.WriteLine("**********************************************");



            /* ********************* .FirstOrDefault() ==> first item matching the query, defaults to null if no match exists ************* */
            // One cat with black coloring
            // Linq way
            CatsInHats oneBlackCat = allCats.FirstOrDefault(c => c.Color.Contains("Black"));

            // Non-linq way
            CatsInHats oneBlackCatNL = new CatsInHats("test", "test", new List<Hat>());

            foreach(CatsInHats cat in allCats)
            {
                if(cat.Color.Contains("Black"))
                {
                    oneBlackCatNL = cat;
                    break;
                }
            }
            System.Console.WriteLine("********** oneBlackCat -- The Linq way ***********");
            System.Console.WriteLine(oneBlackCat.Name);
            System.Console.WriteLine("******** oneBlackCat -- The Non-Linq Way *********");
            System.Console.WriteLine(oneBlackCatNL.Name);
            System.Console.WriteLine("**********************************************");

            // One cat whose name starts with the letter S
            // Linq way
            CatsInHats sName = allCats.FirstOrDefault(c => c.Name[0] == 'S');

            // Non-linq way
            CatsInHats sNameNL = new CatsInHats("test", "test", new List<Hat>());
            
            foreach(CatsInHats cat in allCats)
            {
                if(cat.Name[0] == 'S')
                {
                    sNameNL = cat;
                    break;
                }
            }
            System.Console.WriteLine("********** sName -- The Linq way ***********");
            System.Console.WriteLine(sName.Name);
            System.Console.WriteLine("******** sName -- The Non-Linq Way *********");
            System.Console.WriteLine(sNameNL.Name);
            System.Console.WriteLine("**********************************************");

            // Something that doesn't exist
            // Linq way
            CatsInHats dne = allCats.FirstOrDefault(c => c.Name == "Bill Gates");

            // Non-linq way
            CatsInHats dneNL = null;

            foreach(CatsInHats cat in allCats)
            {
                if(cat.Name == "Bill Gates")
                {
                    dneNL = cat;
                    break;
                }
            }

            System.Console.WriteLine("********** dne -- The Linq way ***********");
            if(dne != null)
            {
                System.Console.WriteLine(dne.Name);
            }
            else 
            {
                System.Console.WriteLine("No cat exists");
            }
            System.Console.WriteLine("******** dne -- The Non-Linq Way *********");
            if(dneNL != null)
            {
                System.Console.WriteLine(dneNL.Name);
            }
            else 
            {
                System.Console.WriteLine("No cat exists");
            }
            System.Console.WriteLine("**********************************************");


            // .Select() ==> returns specific values rather than whole objects

            // Colors of all of arthur's hats
            // Linq way
            List<string> arthurColors = allCats
                .FirstOrDefault(c => c.Name =="Arthur")
                .Hats
                .Select(h => h.Color)
                .ToList();

            // Non-Linq way
            List<string> arthurColorsNL = new List<string>();
            foreach(CatsInHats cat in allCats)
            {
                if(cat.Name == "Arthur")
                {
                    foreach(Hat hat in cat.Hats)
                    {
                        arthurColorsNL.Add(hat.Color);
                    }
                    break;
                }
            }

            System.Console.WriteLine("********** arthurColors -- The Linq way ***********");
            arthurColors.ForEach(Console.WriteLine);
            System.Console.WriteLine("******** arthurColorsNL -- The Non-Linq Way *********");
            arthurColorsNL.ForEach(Console.WriteLine);
            System.Console.WriteLine("**********************************************");

            // Names of all the cats
            // Linq way
            List<string> catNames = allCats.Select(c => c.Name).ToList();

            // Non-Linq way
            List<string> catNamesNL = new List<string>();

            foreach(CatsInHats cat in allCats)
            {
                catNamesNL.Add(cat.Name);
            }
            System.Console.WriteLine("********** catNames -- The Linq way ***********");
            catNames.ForEach(Console.WriteLine);
            System.Console.WriteLine("******** catNamesNL -- The Non-Linq Way *********");
            catNamesNL.ForEach(Console.WriteLine);
            System.Console.WriteLine("**********************************************");


            // .Min() .Max() .Sum()

            // How many hats is the most
            int swaggiest = allCats.Max(c => c.Hats.Count);        

            System.Console.WriteLine($"The swaggiest cat has {swaggiest} hats");
            // How collectively swaggy are these cats? (i.e. how many hats total among said cats)
            int swaglection = allCats.Sum(c => c.Hats.Count);    

            System.Console.WriteLine($"The collective swag of these cool cats is {swaglection}");


        }
    }
}
