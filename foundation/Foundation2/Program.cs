class Program
{
    static void Main(string[] args)
    {   
        Address address1 = new("1st Street", "Salt Lake City", "Utah", "USA");
        Customer customer1 = new("John Doe", address1);
        Product o1p1 = new("apple", 1, 0.49, 12);
        Product o1p2 = new("banana", 2, 0.33, 4);
        List<Product> products1 = [o1p1, o1p2];
        Order order1 = new(products1, customer1);

        Address address2 = new("2nd Street", "Tokyo", "Kanto", "Japan");
        Customer customer2 = new("Jane Doe", address2);
        Product o2p1 = new("cherry", 3, 3.99, 1);
        Product o2p2 = new("apple", 1, 0.49, 6);
        List<Product> products2 = [o2p1, o2p2];
        Order order2 = new(products2, customer2);

        Console.WriteLine("Packing Label:\n" + order1.CreatePackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.CreateShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.OrderCost()}\n\n");

        Console.WriteLine("Packing Label:\n" + order2.CreatePackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.CreateShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.OrderCost()}\n\n");
    }
}