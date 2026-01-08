using System;

/* 
Scenario 10: Custom Notification System with Interface and LinkedList
Use Case: Deliver notifications of different types (Email, SMS, Push) and store them in a delivery queue.
*/

// Notification Interface (Interface)
interface INotification
{
    void Send();
}

// Concrete Notification Types (Polymorphism)
class EmailNotification : INotification
{
    private string email;
    public EmailNotification(string email) { this.email = email; }
    public void Send()
    {
        Console.WriteLine("Sending Email to: " + email);
    }
}

class SmsNotification : INotification
{
    private string phone;
    public SmsNotification(string phone) { this.phone = phone; }
    public void Send()
    {
        Console.WriteLine("Sending SMS to: " + phone);
    }
}

class PushNotification : INotification
{
    private string userId;
    public PushNotification(string userId) { this.userId = userId; }
    public void Send()
    {
        Console.WriteLine("Sending Push Notification to User ID: " + userId);
    }
}

// Node for the Notification Queue (LinkedList)
class DeliveryNode
{
    public INotification Data;
    public DeliveryNode Next;

    public DeliveryNode(INotification data)
    {
        Data = data;
        Next = null;
    }
}

// Notification Queue Manager
class NotificationQueue
{
    private DeliveryNode head = null; // Encapsulation: Internal structure is hidden
    private DeliveryNode tail = null;

    // Abstraction: Only add() and sendAll() are exposed
    public void Add(INotification notification)
    {
        DeliveryNode newNode = new DeliveryNode(notification);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Notification added to the queue.");
    }

    public void SendAll()
    {
        Console.WriteLine("\n--- Starting Bulk Notification Delivery ---");
        DeliveryNode current = head;
        while (current != null)
        {
            current.Data.Send(); // Polymorphism: Each type handles delivery differently
            current = current.Next;
        }
        head = tail = null; // Clear queue after sending
        Console.WriteLine("--- All notifications sent ---\n");
    }
}

// Main class to demonstrate the Notification System
class NotificationSystemDemo
{
    public static void Run()
    {
        NotificationQueue queue = new NotificationQueue();

        queue.Add(new EmailNotification("user1@example.com"));
        queue.Add(new SmsNotification("+123456789"));
        queue.Add(new PushNotification("user_abc_123"));

        queue.SendAll();
    }
}
