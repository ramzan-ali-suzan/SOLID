using System;

namespace OCP.Models
{
    public class GrilledFood : FoodItem
    {
        public GrilledFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Grilling {Name}...");
        }
    }
}
