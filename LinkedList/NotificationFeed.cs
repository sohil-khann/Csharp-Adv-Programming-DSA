using System;

/* 
Scenario 7: Social Media Notification Feed
Use Case: Store and display recent notifications for a user in reverse chronological order (most recent first).
Why LinkedList? Fast insert at the beginning and sequential traversal.
*/

// Base class for notifications (Inheritance)
abstract class BaseNotification
{
    public string Message;
    public DateTime CreatedAt;

    public BaseNotification(string message)
    {
        Message = message;
        CreatedAt = DateTime.Now;
    }

    // Polymorphism: Different notification display styles
    public abstract void Display();
}

// Specific notification types (Polymorphism)
class LikeNotification : BaseNotification
{
    public string LikerName;
    public LikeNotification(string likerName) : base(likerName + " liked your post.")
    {
        LikerName = likerName;
    }
    public override void Display()
    {
        Console.WriteLine("[LIKE] " + Message + " (" + CreatedAt.ToShortTimeString() + ")");
    }
}

class CommentNotification : BaseNotification
{
    public string CommenterName;
    public string CommentText;
    public CommentNotification(string commenterName, string text) : base(commenterName + " commented: " + text)
    {
        CommenterName = commenterName;
        CommentText = text;
    }
    public override void Display()
    {
        Console.WriteLine("[COMMENT] " + Message + " (" + CreatedAt.ToShortTimeString() + ")");
    }
}

// Node for the Notification Feed (LinkedList)
class FeedNode
{
    public BaseNotification Notification;
    public FeedNode Next;

    public FeedNode(BaseNotification notification)
    {
        Notification = notification;
        Next = null;
    }
}

// Notification Feed Manager
class UserFeed
{
    private FeedNode head = null; // Encapsulation: Feed is managed privately

    // Abstraction: API-style access to add notification (always at start for LIFO)
    public void AddNotification(BaseNotification notification)
    {
        FeedNode newNode = new FeedNode(notification);
        newNode.Next = head;
        head = newNode;
        Console.WriteLine("New notification added.");
    }

    // Abstraction: Simple method to display feed
    public void DisplayFeed()
    {
        Console.WriteLine("\n--- Your Notification Feed ---");
        if (head == null)
        {
            Console.WriteLine("No notifications yet.");
        }
        else
        {
            FeedNode temp = head;
            while (temp != null)
            {
                temp.Notification.Display(); // Polymorphism in action
                temp = temp.Next;
            }
        }
    }
}

// Main class to demonstrate the Notification Feed
class NotificationFeedDemo
{
    public static void Run()
    {
        UserFeed myFeed = new UserFeed();

        myFeed.AddNotification(new LikeNotification("Sohil"));
        myFeed.AddNotification(new CommentNotification("Raj", "Great photo!"));
        myFeed.AddNotification(new LikeNotification("Charan"));

        myFeed.DisplayFeed();
    }
}
