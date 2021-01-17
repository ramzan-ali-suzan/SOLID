using OCP.Models;
using System.Collections.Generic;

namespace OCP.Services
{
    public class KitchenService
    {
        public void PrepareItems(List<FoodItem> foodItems)
        {
            foreach (var item in foodItems)
            {
                item.Prepare();
            }
        }
    }
}
