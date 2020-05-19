using System;

namespace LightupKeyboardStatus.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lights = new Lights();
            lights.Black();
            Console.WriteLine("Black?");
            Console.ReadKey();

            lights.Go();
            Console.WriteLine("Working?");
            Console.ReadKey();
        }
    }
}
