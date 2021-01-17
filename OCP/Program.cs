using System.Collections.Generic;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodItems = new List<FoodItem>
            {
                new GrilledFood("steak"),
                new FriedFood("chicken")
            };

            KitchenService kitchenService = new KitchenService();
            kitchenService.PrepareItems(foodItems);
        }
    }
}
