using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("45 Rue de la Paix", "Paris", "Ile-de-France", "France");
        Address address3 = new Address("789 Oak Ave", "Springfield", "IL", "USA");
        Address address4 = new Address("Unit 7, High Street", "London", "Greater London", "United Kingdom"); // Another international customer

        Customer customer1 = new Customer("Sarah Jones", address1);        // USA
        Customer customer2 = new Customer("Pierre Dubois", address2);      // France
        Customer customer3 = new Customer("Emily White", address3);        // USA
        Customer customer4 = new Customer("Elizabeth Green", address4);    // UK

        
        // Scriptures
        Product p1 = new Product("Quadruple Combination", "SCR-Q01", 35.00m, 1);
        Product p2 = new Product("Triple Combination", "SCR-T02", 28.50m, 2);
        Product p3 = new Product("Book of Mormon (Paperback)", "SCR-BM1", 5.00m, 5); 

        //music
        Product p4 = new Product("Hymns", "MUSIC-H01", 12.00m, 1);
        Product p5 = new Product("Children's Songbook", "MUSIC-CS2", 10.00m, 1);

        // Temple & Missionary
        Product p6 = new Product("Temple Recommend Holder", "ACC-TRH", 8.00m, 1);
        Product p7 = new Product("Preach My Gospel (Missionary Guide)", "MAN-PMG", 7.50m, 3); // For missionaries

        // Gospel Art & Resources
        Product p8 = new Product("Christus Statue (Small)", "ART-CHS", 75.00m, 1);
        Product p9 = new Product("Family History Guide", "RES-FHG", 15.00m, 1);


        // Order 1 (USA Customer: Sarah Jones)
        Order order1 = new Order(customer1);
        order1.AddProduct(p1); // Quadruple Combination
        order1.AddProduct(p3); // Book of Mormon (Paperback) x5
        order1.AddProduct(p6); // Temple Recommend Holder

        // Order 2 (International Customer: Pierre Dubois)
        Order order2 = new Order(customer2);
        order2.AddProduct(p4); // Hymns
        order2.AddProduct(p7); // Preach My Gospel x3
        order2.AddProduct(p5); // Children's Songbook

        // Order 3 (Another USA Customer: Emily White)
        Order order3 = new Order(customer3);
        order3.AddProduct(p8); // Christus Statue
        order3.AddProduct(p2); // Triple Combination x2

        // Order 4 (Another International Customer: Elizabeth Green)
        Order order4 = new Order(customer4);
        order4.AddProduct(p3); // Book of Mormon (Paperback) x5
        order4.AddProduct(p9); // Family History Guide

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);
        orders.Add(order4);


        Console.WriteLine("--- Distribution Services Order Report ---");
        Console.WriteLine("----------------------------------------------\n");

        int orderCount = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"===== Order {orderCount} =====");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("\n"); 
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"\nTotal Order Cost: ${order.GetTotalCost():0.00}"); // Format to 2 decimal places
            Console.WriteLine("\n===============================\n");
            orderCount++;
        }
    }
}