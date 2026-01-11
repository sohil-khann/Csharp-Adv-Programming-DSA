/*
 1. Inventory Management System
 Use Case: Maintain a mapping of product IDs to product information.
 OOP Concepts:
 - Interface: IProduct (Defines basic product properties)
 - Encapsulation: InventoryManager manages the internal Dictionary.
 - Abstraction: Simple AddProduct(), GetProduct() methods.
 - Polymorphism: Different product types (Electronics, Clothing) implement IProduct.
*/

using System;
using System.Collections.Generic;

namespace HashMapManagement
{
    // Interface for different types of products
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        void DisplayDetails();
    }

    // Concrete implementation for Electronics
    public class Electronics : IProduct
    {
        public string Name { get; }
        public double Price { get; }
        public string Brand { get; }

        public Electronics(string name, double price, string brand)
        {
            Name = name;
            Price = price;
            Brand = brand;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"[Electronics] {Name} by {Brand} - Price: ${Price}");
        }
    }

    // Concrete implementation for Clothing
    public class Clothing : IProduct
    {
        public string Name { get; }
        public double Price { get; }
        public string Size { get; }

        public Clothing(string name, double price, string size)
        {
            Name = name;
            Price = price;
            Size = size;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"[Clothing] {Name} (Size: {Size}) - Price: ${Price}");
        }
    }

    // Manager class demonstrating Encapsulation and Abstraction
    public class InventoryManager
    {
        // Using Dictionary as a HashMap to map ID -> Product
        private Dictionary<int, IProduct> _products = new Dictionary<int, IProduct>();

        public void AddProduct(int id, IProduct product)
        {
            if (!_products.ContainsKey(id))
            {
                _products.Add(id, product);
                Console.WriteLine($"Product ID {id} ({product.Name}) added to inventory.");
            }
            else
            {
                Console.WriteLine($"Error: Product ID {id} already exists.");
            }
        }

        public void GetProduct(int id)
        {
            if (_products.ContainsKey(id))
            {
                IProduct product = _products[id];
                product.DisplayDetails();
            }
            else
            {
                Console.WriteLine($"Product ID {id} not found.");
            }
        }
    }

    public class InventoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 1: Inventory Management System ---");
            InventoryManager inventory = new InventoryManager();

            // Adding products (Polymorphism)
            inventory.AddProduct(101, new Electronics("Smartphone", 799.99, "Samsung"));
            inventory.AddProduct(102, new Clothing("Winter Jacket", 120.50, "XL"));
            inventory.AddProduct(103, new Electronics("Laptop", 1200.00, "Dell"));

            Console.WriteLine("\nRetrieving products by ID:");
            inventory.GetProduct(101);
            inventory.GetProduct(102);
            inventory.GetProduct(105); // Not in inventory
            Console.WriteLine();
        }
    }
}
