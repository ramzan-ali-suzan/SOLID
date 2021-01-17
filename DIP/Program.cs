using System;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            
            Console.WriteLine(calculator.Add(5, 5));
            Console.WriteLine(calculator.Subtract(10, 5));
        }
    }
}
