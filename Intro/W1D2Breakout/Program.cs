using System;
using System.Collections.Generic;

namespace W1D2Breakout
{
    class Program
    {
        public static void InnerFunc()
        {
            System.Console.WriteLine("o hai");
        }
        public static void OuterFunc()
        {
            System.Console.WriteLine("This is the outer function");
            InnerFunc();
            System.Console.WriteLine("We done here");
        }
        static void Main(string[] args)
        {
            IceCream GrannysFamousIceCream = new IceCream();        
            System.Console.WriteLine(GrannysFamousIceCream.IsDelicious);
            GrannysFamousIceCream.Flavor = "Rocky Road";
            System.Console.WriteLine(GrannysFamousIceCream.IsDelicious);


            int[][] jaggedarray = new int[10][];

            jaggedarray[0] = new int[]{1,2,3,4,5,6,7,8,9,10};


            int[,] multidarray = new int[10,10];


            for(int i = 0; i < 10; i++)
            {
                multidarray[0, i] = i+1;
            }
            
        }
    }
}
