using System;

namespace OCP
{
    public class GrilledFood : FoodItem
    {
        public GrilledFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Grilling {this.Name}...");
        }
    }
}
