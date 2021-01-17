using LSP.Models;
using System;
using System.Collections.Generic;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var birds = new List<Bird>
            {
                new Duck(),
                new Ostrich()
            };

            // Let the birds fly
            foreach (var bird in birds)
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
