using System;

namespace OCP.Models
{
    public class BakedFood : FoodItem
    {
        public BakedFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Baking {Name}...");
        }
    }
}
