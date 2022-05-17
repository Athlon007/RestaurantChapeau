using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;

namespace RestaurantChapeau
{
    internal class OrderBasket
    {
        private static OrderBasket instance;
        public static OrderBasket Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderBasket();
                }

                return instance;
            }
        }

        // ItemID. Quantity.
        private Dictionary<int, int> itemsInBasket;

        private OrderBasket() 
        {
            itemsInBasket = new Dictionary<int, int>();
        }

        
        public void Add(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                itemsInBasket[item.Id]++;
            }
            else
            {
                itemsInBasket.Add(item.Id, 1);
            }
        }

        public void Subtract(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                itemsInBasket[item.Id]--;

                if (itemsInBasket[item.Id] == 0)
                {
                    itemsInBasket.Remove(item.Id);
                }
            }
        }

        public void Set(MenuItem item, int quantity)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                itemsInBasket[item.Id] = quantity;
            }
            else
            {
                itemsInBasket.Add(item.Id, quantity);
            }
        }

        public int ItemCount(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                return itemsInBasket[item.Id];
            }
            else
            {
                return 0;
            }
        }
    }
}
