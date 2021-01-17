using OCP.Models;
using System;
using System.Collections.Generic;

namespace OCP.Services
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
