using System.Net.WebSockets;
using sda_onsite_2_inventory_management.src;

internal class Program
{
    private static void Main(string[] args)
    {
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2024, 5, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2024, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2024, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 10, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);


        Store store = new Store("Mandrin", 90);
        store.AddItem(chipsBag);
        store.AddItem(notebook);
        store.AddItem(chocolateBar);
        store.AddItem(waterBottle);
        store.AddItem(tissuePack);
        store.AddItem(pen);


        var groupByDate = store.GroupByDate();
        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($" - {item.GetName()}, Created: {item.GetDate().ToShortDateString()}");
            }
        }
        var Sort = store.SortByDate(SortOrder.DESC);
        foreach (var item in Sort)
        {
            Console.WriteLine($"Date {item.GetDate()}");
        }

    }
}
