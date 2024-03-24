using System.Net.WebSockets;
using sda_onsite_2_inventory_management.src;

internal class Program
{
    private static void Main(string[] args)
    {
        var waterBottle = new Item("Water Bottle", 10, Convert.ToString(new DateTime(2023, 1, 1)));
        var chocolateBar = new Item("Chocolate Bar", 15, Convert.ToString(new DateTime(2023, 2, 1)));
        var notebook = new Item("Notebook", 5, Convert.ToString(new DateTime(2023, 3, 1)));
        var pen = new Item("Pen", 20, Convert.ToString(new DateTime(2023, 4, 1)));
        var tissuePack = new Item("Tissue Pack", 30, Convert.ToString(new DateTime(2023, 5, 1)));
        var chipsBag = new Item("Chips Bag", 25, Convert.ToString(new DateTime(2023, 6, 1)));
        var sodaCan = new Item("Soda Can", 8, Convert.ToString(new DateTime(2023, 7, 1)));
        var soap = new Item("Soap", 12, Convert.ToString(new DateTime(2023, 8, 1)));
        var shampoo = new Item("Shampoo", 40, Convert.ToString(new DateTime(2023, 9, 1)));
        var toothbrush = new Item("Toothbrush", 50, Convert.ToString(new DateTime(2023, 10, 1)));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);


        Store store = new Store("Mandrin");
        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(notebook);
        List<Item> items = store.GetItems();
        items.ForEach((item) =>
        {
            Console.WriteLine($"Name = {item.GetName()} Quantity = {item.GetQuantity()} Date = {item.GetDate()}");
        });

        
    }
}
