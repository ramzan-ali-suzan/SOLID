using System;

namespace OCP.Models
{
    public class FriedFood : FoodItem
    {
        public FriedFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Frying {Name}...");
        }
    }
}
