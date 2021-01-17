using System;
using System.Collections.Generic;

namespace OCP
{
    public class KitchenService
    {
        public void PrepareItems(List<FoodItem> foodItems)
        {
            foreach (var item in foodItems)
            {
                if (item is GrilledFood)
                    Console.WriteLine($"Grilling {item.Name}...");

                if (item is FriedFood)
                    Console.WriteLine($"Frying {item.Name}...");
            }
        }
    }
}
