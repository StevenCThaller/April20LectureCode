using System;

namespace TestingThings
{
    class Program
    {
        public static string SayHello(string firstName = "buddy")
        {
            return $"Hey {firstName}";
        }
        static void Main(string[] args)
        {
            string greeting;
            greeting = SayHello();
            Console.WriteLine(greeting);
            // Console.WriteLine("Hello World!");
        }
    }
}
