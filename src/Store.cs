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

        public List<Item> SortByNameAsc()
        {
            var sortbyName = items.OrderBy(item => item.GetName()).ToList();
            return sortbyName;
        }


        public List<Item> SortByDate(string SortOrder)
        {
            if (SortOrder.ToUpper() == "ASC")
            {
                var SortByDate = items.OrderBy(item => item.GetDate()).ToList();
                Console.WriteLine("Sorting date by Ascending");
                return SortByDate;
            }

            if (SortOrder.ToUpper() == "DESC")
            {
                var SortByDate = items.OrderByDescending(item => item.GetDate()).ToList();
                Console.WriteLine("Sorting date by Descending");
                return SortByDate;
            }
            else
            {
                Console.WriteLine("Wrong input Please type 'ASC' or 'DESC' to sorting this list with no sorting!!! ");
                return items;
            }

        }

        public Dictionary<string, List<Item>> GroupByDate()
        {
            Dictionary<string, List<Item>> grouped = new();
            DateTime currentDate = DateTime.Now;
            foreach (var item in items)
            {
                if ((currentDate - item.GetDate()).TotalDays <= 90)
                {
                    if (!grouped.ContainsKey("new"))
                    {
                        grouped.Add("new", []);

                    }
                    grouped["new"].Add(item);
                }
                else
                {
                    if (!grouped.ContainsKey("old"))
                    {
                        grouped.Add("old", []);

                    }
                    grouped["old"].Add(item);
                }
            }
            return (grouped);
        }
    }
}