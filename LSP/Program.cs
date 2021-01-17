using LSP.Models;
using System;
using System.Collections.Generic;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var flyingBirds = new List<FlyingBird>
            {
                new Duck(),
                new Sparrow()
            };

            // Let the birds fly
            foreach (var bird in flyingBirds)
            {
                try
                {
                    bird.Fly();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
