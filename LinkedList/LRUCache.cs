using System;

/* 
Scenario 8: LRU (Least Recently Used) Cache System
Use Case: Design an LRU Cache system where the most recently accessed item moves to the front.
Why LinkedList? Efficient removal from middle and addition to front when accessed.
*/

// Node class for the Cache (Doubly LinkedList for easier removal)
class CacheNode
{
    public string Key;
    public string Value;
    public CacheNode Prev;
    public CacheNode Next;

    public CacheNode(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

// LRU Cache Manager
class LRUCache
{
    private int capacity;
    private int currentSize;
    private CacheNode head; // Most recently used
    private CacheNode tail; // Least recently used

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.currentSize = 0;
        this.head = null;
        this.tail = null;
    }
    public string Get(string key)
    {
        CacheNode node = FindNode(key);
        if (node == null)
        {
            return "Not Found";
        }

        // Move the accessed node to front (Most Recently Used)
        MoveToFront(node);
        return node.Value;
    }

    public void Put(string key, string value)
    {
        CacheNode existingNode = FindNode(key);
        if (existingNode != null)
        {
            // Update value and move to front
            existingNode.Value = value;
            MoveToFront(existingNode);
        }
        else
        {
            // Add new node
            CacheNode newNode = new CacheNode(key, value);
            if (currentSize >= capacity)
            {
                RemoveLRU(); // Remove least recently used from tail
            }

            AddToFront(newNode);
            currentSize++;
        }
        Console.WriteLine("Put: [" + key + " = " + value + "]");
    }

    private CacheNode FindNode(string key)
    {
        CacheNode temp = head;
        while (temp != null)
        {
            if (temp.Key == key) return temp;
            temp = temp.Next;
        }
        return null;
    }

    private void AddToFront(CacheNode node)
    {
        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
            head.Prev = null;
        }
    }

    private void MoveToFront(CacheNode node)
    {
        if (node == head) return;

        // Remove from current position
        if (node.Prev != null) node.Prev.Next = node.Next;
        if (node.Next != null) node.Next.Prev = node.Prev;

        if (node == tail)
        {
            tail = node.Prev;
        }

        // Add to front
        node.Next = head;
        node.Prev = null;
        if (head != null) head.Prev = node;
        head = node;
    }

    private void RemoveLRU()
    {
        if (tail == null) return;

        Console.WriteLine("Cache full. Removing LRU: " + tail.Key);
        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        currentSize--;
    }

    public void DisplayCache()
    {
        Console.WriteLine("\n--- Current Cache (Most Recent First) ---");
        CacheNode temp = head;
        while (temp != null)
        {
            Console.Write("[" + temp.Key + ":" + temp.Value + "] ");
            temp = temp.Next;
        }
    }
}

// Main class to demonstrate LRU Cache
class LRUCacheDemo
{
    public static void Run()
    {
        LRUCache cache = new LRUCache(3); // Capacity of 3

        cache.Put("URL1", "Google.com");
        cache.Put("URL2", "Facebook.com");
        cache.Put("URL3", "YouTube.com");
        cache.DisplayCache();

        Console.WriteLine("Accessing URL1: " + cache.Get("URL1"));
        cache.DisplayCache(); // URL1 should be at front

        cache.Put("URL4", "OpenAI.com"); // Should remove URL2 (LRU)
        cache.DisplayCache();

        Console.WriteLine("Accessing URL3: " + cache.Get("URL3"));
        cache.DisplayCache(); // URL3 should move to front
    }
}
