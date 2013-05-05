using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain
{
    public class ItemList
    {
        private IList<Item> items = new List<Item>();

        public void Add(Item item)
        {
            items.Add(item);
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        public double CalcultateTotalItemsPrice()
        {
            double totalPrice = 0;

            foreach (Item item in items)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }
    }
}
