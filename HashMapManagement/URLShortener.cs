/*
 4. URL Shortener Service
 Use Case: Map short URLs to long URLs.
 OOP Concepts:
 - Interface: IURLStorage (Abstraction for storage mechanism)
 - Abstraction & Encapsulation: Only Shorten() and GetLongURL() methods exposed.
 - Polymorphism: Can be implemented as InMemory, FileBased, or Database storage.
*/

using System;
using System.Collections.Generic;

namespace HashMapManagement
{
    // Interface for URL storage operations
    public interface IURLStorage
    {
        void SaveURL(string shortCode, string longURL);
        string RetrieveURL(string shortCode);
    }

    // In-Memory implementation of the storage
    public class InMemoryStorage : IURLStorage
    {
        // HashMap for ShortCode -> LongURL
        private Dictionary<string, string> _urlMap = new Dictionary<string, string>();

        public void SaveURL(string shortCode, string longURL)
        {
            _urlMap[shortCode] = longURL;
        }

        public string RetrieveURL(string shortCode)
        {
            if (_urlMap.ContainsKey(shortCode))
            {
                return _urlMap[shortCode];
            }
            return null;
        }
    }

    // Shortener service that uses the storage
    public class URLShortenerService
    {
        private IURLStorage _storage;
        private const string Domain = "http://short.ly/";

        public URLShortenerService(IURLStorage storage)
        {
            _storage = storage;
        }

        public string Shorten(string longURL)
        {
            // Simple logic for short code generation
            // In a real app, this would be a hash or unique string
            string shortCode = Math.Abs(longURL.GetHashCode()).ToString("X");
            _storage.SaveURL(shortCode, longURL);
            return Domain + shortCode;
        }

        public void Redirect(string shortURL)
        {
            string code = shortURL.Replace(Domain, "");
            string original = _storage.RetrieveURL(code);

            if (original != null)
            {
                Console.WriteLine($"Short URL: {shortURL} --> Redirecting to: {original}");
            }
            else
            {
                Console.WriteLine($"Error: Short URL {shortURL} is invalid.");
            }
        }
    }

    public class URLShortenerDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 4: URL Shortener Service ---");
            
            // Using In-Memory Storage (Polymorphism)
            IURLStorage myStorage = new InMemoryStorage();
            URLShortenerService shortener = new URLShortenerService(myStorage);

            string url1 = "https://www.google.com/search?q=csharp+dictionary";
            string url2 = "https://www.github.com/sohil-khan/dsa-projects";

            string short1 = shortener.Shorten(url1);
            string short2 = shortener.Shorten(url2);

            Console.WriteLine($"Generated: {short1}");
            Console.WriteLine($"Generated: {short2}");

            Console.WriteLine("\nTesting Redirection:");
            shortener.Redirect(short1);
            shortener.Redirect(short2);
            shortener.Redirect("http://short.ly/INVALID");
            Console.WriteLine();
        }
    }
}
