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
                try
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(newJeans)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
