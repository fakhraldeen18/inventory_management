using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace sda_onsite_2_inventory_management.src
{
    class Store
    {
        private List<Item> items;
        private readonly string name;
        public int maximumCapacity;
        public Store(string name, int maximumCapacity)
        {
            items = [];
            this.name = name;
            this.maximumCapacity = maximumCapacity;
        }

        public List<Item> GetItems()
        {
            return items;
        }
        public void AddItem(Item newItem)
        {
            int currentVolume = GetCurrentVolume();
            int availableCapacity = maximumCapacity - currentVolume;
            int comingInCapacity = newItem.GetQuantity();

            Console.WriteLine($"max cap {maximumCapacity} | volume {GetCurrentVolume()}");
            if (availableCapacity < comingInCapacity)
            {
                throw new Exception("You Can't overladed capacity!!");
            }

            else
            {

                Item? foundItem = items.Find((item) => item.GetName() == newItem.GetName());
                if (foundItem == null)
                    items.Add(newItem);
                else
                {
                    throw new Exception("Can't add same name of item!!");
                }
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

        public void FindItemByName(string ItemName)
        {
            Item? FindItems = items.Find((item) => item.GetName() == ItemName);
            if (FindItems != null)
            {
                Console.WriteLine($"Name = {FindItems.GetName()} Quantity = {FindItems.GetQuantity()} Date = {FindItems.GetDate()}");
            }
            else
            {
                throw new Exception("Can't find item");
            }
        }

        public void SortByNameAsc()
        {
            var sortbyName = items.OrderBy(item => item.GetName());
            foreach (var items in sortbyName)
            {
                Console.WriteLine($"Order By Asc Name {items.GetName()}");
            }
        }
    }

}