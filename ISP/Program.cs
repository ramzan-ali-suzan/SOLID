using ISP.Models;
using System;
using System.Reflection;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var newJeans = new Jeans { Weight = 1.7, Inseam = 27, Stock = 10, WaistSize = 30 };
            var newCaps = new BaseballCap { Weight = .3, Stock = 15, HatSize = 22 };

            Console.WriteLine("Jeans details:");
            foreach (PropertyInfo property in typeof(Jeans).GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(newJeans)}");
            }

            Console.WriteLine("\nCap details:");
            foreach (PropertyInfo property in typeof(BaseballCap).GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(newCaps)}");
            }
        }
    }
}
