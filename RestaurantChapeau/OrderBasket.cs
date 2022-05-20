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
        private Dictionary<int, int> itemsInBasket = new Dictionary<int, int>();

        const int MaximumQuantity = 100;

        private OrderBasket() { }

        /// <summary>
        /// Add ONE of the specified item.
        /// </summary>
        /// <param name="item"></param>
        public void Add(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                // Do not allow setting item count above allowed quantity.
                if (itemsInBasket[item.Id] >= MaximumQuantity)
                {
                    return;
                }

                itemsInBasket[item.Id]++;
            }
            else
            {
                itemsInBasket.Add(item.Id, 1);
            }
        }

        /// <summary>
        /// Subtract ONE of thespecified item.
        /// </summary>
        /// <param name="item"></param>
        public void Subtract(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                itemsInBasket[item.Id]--;

                if (itemsInBasket[item.Id] == 0)
                {
                    // Is the item count 0?
                    // Remove the item from the list.
                    itemsInBasket.Remove(item.Id);
                }
            }
        }

        /// <summary>
        /// Sets the item count in the basket to a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
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

            if (itemsInBasket[item.Id] == 0)
            {
                // Is the item count 0?
                // Remove the item from the basket.
                itemsInBasket.Remove(item.Id);
            }
            else if (itemsInBasket[item.Id] > MaximumQuantity)
            {
                // Is the item count larger than maximum allowed?
                // Set the count to the max allowed.
                itemsInBasket[item.Id] = MaximumQuantity;
            }
        }

        /// <summary>
        /// Returns how many times specific item is in the basket.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ItemCount(MenuItem item)
        {
            if (itemsInBasket.ContainsKey(item.Id))
            {
                return itemsInBasket[item.Id];
            }

            // If the item is not in the basket, return 0.
            return 0;
        }

        /// <summary>
        /// Clears the basket.
        /// </summary>
        public void Clear()
        {
            itemsInBasket.Clear();
        }

        /// <summary>
        /// Returns all items in the basket.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> GetAll()
        {
            return itemsInBasket;
        }
    }
}
