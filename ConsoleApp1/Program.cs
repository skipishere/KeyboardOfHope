using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightMeUp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lights = new Light();

            Console.WriteLine($"You passed in {args[0]}");

            switch (args[0])
            {
                case "red":
                    lights.PulseRed();
                    break;

                case "green":
                    lights.SolidGreen();
                    break;

                case "blue":
                    lights.SolidBlue();
                    break;

                default:
                    break;
            }

            //Console.WriteLine("Hello World!");

            //var lights = new Light();
            ////lights.Black();
            ////Console.WriteLine("Black?");
            ////Console.ReadKey();

            ////lights.Go();
            ////Console.WriteLine("Working?");
            ////Console.ReadKey();

            //lights.PulseRed();
            //Console.WriteLine("Pulse Red?");
            //Console.ReadKey();

            //lights.SolidGreen();
            //Console.WriteLine("Go Green?");
            //Console.ReadKey();

            //lights.SolidBlue();
            //Console.WriteLine("Pulse Yellow?");
            //Console.ReadKey();

            //lights.PulseRed();
            //Console.WriteLine("Pulse Red?");
            //Console.ReadKey();
        }
    }
}
