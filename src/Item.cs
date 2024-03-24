using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_inventory_management.src
{
    class Item
    {
        private readonly string name;
        private int quantity;
        private string date;



        public Item(string name, int quantity, string? date = null)
        {
            this.name = name;
            if (quantity < 0)
            {
                throw new Exception("The quantity con't be negative");
            }
            else { this.quantity = quantity; }

            if (date == null)
            {
                this.date = Convert.ToString(DateTime.Now);
            }
            else
            {
                this.date = date;
            }
        }
        public string GetName()
        {
            return name;
        }
        public string GetDate()
        {
            return date;
        }
        public void SetDate(string value)
        {
            date = value;
        }
        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity(int value)
        {
            quantity = value;
        }

    }
}