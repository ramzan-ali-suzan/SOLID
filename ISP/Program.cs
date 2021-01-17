using System;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var newJeans = new Jeans { Weight = 1.7, Inseam = 27, Stock = 10, WaistSize = 30 };
            var newCaps = new BaseballCap { Weight = .3, Stock = 15, HatSize = 22 };
        }
    }
}
