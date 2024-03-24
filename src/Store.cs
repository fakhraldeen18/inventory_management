using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_inventory_management.src
{
    class Store
    {
        private List<Item> items;
        private readonly string name;
        public Store(string name)
        {
            items = [];
            this.name = name;
        }

        public List<Item> GetItems()
        {
            return items;
        }
        public void AddItem(Item newItem)
        {
            Item? foundItem = items.Find((item) => item.GetName() == newItem.GetName());
            if (foundItem == null)
                items.Add(newItem);
            else
            {
                throw new Exception("Can't add same name of item!!");
            }

        }
        public void DeleteItem(Item item)
        {
            items.Remove(item);
        }
        public int GetCurrentVolume()
        {
            int totalVolume = 0;
            items.ForEach((currentItems) =>
            {
                totalVolume += currentItems.GetQuantity();
            });
            return totalVolume;
        }
    }

}