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

        private List<MenuItem> itemsInBasket = new List<MenuItem>();

        private OrderBasket() { }

        private List<OrderView> listeners = new List<OrderView>();

        /// <summary>
        /// Add ONE of the specified item.
        /// </summary>
        /// <param name="item"></param>
        public void Add(MenuItem item)
        {
            bool itemFound = false;
            foreach (MenuItem basketItem in itemsInBasket)
            {
                if (basketItem.Id == item.Id)
                {
                    itemFound = true;
                    if (basketItem.Quantity >= basketItem.Stock)
                    {
                        break;
                    }    

                    basketItem.Quantity++;
                    break;
                }
            }

            // Item not in the basket? Add it!
            if (!itemFound)
            {
                item.Quantity = 1;
                itemsInBasket.Add(item);
            }

            UpdateListeners();
        }

        /// <summary>
        /// Subtract ONE of thespecified item.
        /// </summary>
        /// <param name="item"></param>
        public void Subtract(MenuItem item)
        {
            foreach (MenuItem basketItem in itemsInBasket)
            {
                if (basketItem.Id == item.Id)
                {
                    basketItem.Quantity--;
                    
                    if (basketItem.Quantity == 0)
                    {
                        // Is the item count 0?
                        // Remove the item from the list.
                        itemsInBasket.Remove(basketItem);
                    }

                    break;
                }
            }

            UpdateListeners();
        }

        /// <summary>
        /// Sets the item count in the basket to a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        public void Set(MenuItem item, int quantity)
        {
            if (quantity > item.Stock)
            {
                quantity = item.Stock;
            }

            bool itemFound = false;
            foreach (MenuItem basketItem in itemsInBasket)
            {
                if (basketItem.Id == item.Id)
                {
                    itemFound = true;
                    basketItem.Quantity = quantity;

                    if (basketItem.Quantity > item.Stock)
                    {
                        basketItem.Quantity = item.Stock;
                    }
                    else if (basketItem.Quantity == 0)
                    {
                        itemsInBasket.Remove(basketItem);
                    }
                    break;
                }
            }

            if (!itemFound && quantity > 0 && quantity <= item.Stock)
            {
                item.Quantity = quantity;
                itemsInBasket.Add(item);
            }

            UpdateListeners();
        }

        /// <summary>
        /// Returns how many times specific item is in the basket.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ItemCount(MenuItem item)
        {
            foreach (MenuItem basketItem in itemsInBasket)
            {
                if (item.Id == basketItem.Id)
                {
                    return basketItem.Quantity;
                }
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
        public List<MenuItem> GetAll()
        {
            return itemsInBasket;
        }

        /// <summary>
        /// Total amount of items in the order (including multiple instances of an unique item).
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                foreach (MenuItem item in itemsInBasket)
                {
                    count += item.Quantity;
                }

                return count;
            }
        }

        /// <summary>
        /// Returns the total value of the basket.
        /// </summary>
        public decimal Value
        {
            get
            {
                decimal total = 0;
                foreach (MenuItem item in itemsInBasket)
                {
                    total += item.Quantity * item.PriceBrutto;
                }
                return total;
            }
        }

        public void AddListener(OrderView view)
        {
            listeners.Add(view);

            UpdateListeners();
        }

        public void RemoveListener(OrderView view)
        {
            if (listeners.Contains(view))
            {
                listeners.Remove(view);
            }
        }

        private void UpdateListeners()
        {
            foreach (OrderView view in listeners)
            {
                view.UpdateUI();
            }
        }
    }
}
