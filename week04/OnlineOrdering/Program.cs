using System;

class Program
{
    static void Main(string[] args)
    {
        var product1 = new Product("P001", "Laptop", 750, 1);
        var product2 = new Product("P002", "Mouse", 20, 2);

        var address1 = new Address("123 Main St", "New York", "USA");
        var customer1 = new Customer("Juan Perez", address1);
        var order1 = new Order(new List<Product> { product1, product2 }, customer1);

        var product3 = new Product("P003", "Smartphone", 500, 1);
        var product4 = new Product("P004", "Headphones", 100, 1);
        var product5 = new Product("P005", "Charger", 25, 1);

        var address2 = new Address("456 Central Ave", "Toronto", "Canada");
        var customer2 = new Customer("Ana Gómez", address2);
        var order2 = new Order(new List<Product> { product3, product4, product5 }, customer2);

        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("TOTAL PRICE: " + order1.GetTotalPrice());
        Console.WriteLine();

        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("TOTAL PRICE: " + order2.GetTotalPrice());
    }
}