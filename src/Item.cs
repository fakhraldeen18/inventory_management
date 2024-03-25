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
        private DateTime date;



        public Item(string name, int quantity, DateTime? date = null)
        {
            this.name = name;
            if (quantity < 0)
            {
                throw new Exception("The quantity con't be negative");
            }
            else { this.quantity = quantity; }

            if (date == null)
            {
                this.date = DateTime.Now;
            }
            else
            {
                this.date = (DateTime)date;
            }
        }
        public string GetName()
        {
            return name;
        }
        public DateTime GetDate()
        {
            return date;
        }
        public void SetDate(DateTime value)
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