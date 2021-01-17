using System;
using System.Collections.Generic;
using System.Text;

namespace OCP
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
