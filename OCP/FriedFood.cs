using System;

namespace OCP
{
    public class FriedFood : FoodItem
    {
        public FriedFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Frying {this.Name}...");
        }
    }
}
