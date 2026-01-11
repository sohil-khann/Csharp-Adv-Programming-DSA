using System;

namespace HashMapManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("   REAL-WORLD HASHMAP (DICTIONARY) USE CASES (OOP)   ");
            Console.WriteLine("======================================================\n");

            // 1. Inventory Management System
            InventoryDemo.Run();

            // 2. Role-Based Access Control (RBAC)
            RBACDemo.Run();

            // 3. Student Grade Book
            GradeBookDemo.Run();

            // 4. URL Shortener Service
            URLShortenerDemo.Run();

            Console.WriteLine("======================================================");
            Console.WriteLine("   All HashMap Management Demos Completed   ");
            Console.WriteLine("======================================================");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
