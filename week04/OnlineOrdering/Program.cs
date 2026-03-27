using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Maple Street",
            "Rexburg",
            "ID",
            "USA"
        );
        Customer customer1 = new Customer("Jordan Smith", address1);

        List<Product> products1 = new List<Product>
        {
            new Product("Notebook", "NB1001", 3.50m, 4),
            new Product("Pencil Set", "PS2002", 5.25m, 2),
            new Product("Backpack", "BP3003", 29.99m, 1)
        };

        Order order1 = new Order(products1, customer1);

        Address address2 = new Address(
            "88 King Street",
            "Toronto",
            "ON",
            "Canada"
        );
        Customer customer2 = new Customer("Avery Chen", address2);

        List<Product> products2 = new List<Product>
        {
            new Product("Water Bottle", "WB4004", 12.95m, 1),
            new Product("Lunch Box", "LB5005", 18.75m, 1)
        };

        Order order2 = new Order(products2, customer2);

        DisplayOrder(order1, "Order 1");
        DisplayOrder(order2, "Order 2");
    }

    static void DisplayOrder(Order order, string title)
    {
        Console.WriteLine(title);
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: {order.GetTotalCost():C}");
        Console.WriteLine();
    }
}
