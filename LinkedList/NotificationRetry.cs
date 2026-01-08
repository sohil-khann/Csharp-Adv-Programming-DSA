using System;

/* 
Scenario 14: Notification Retry Mechanism
Use Case: Failed notifications (e.g., SMS or email) are retried after failure in FIFO order.
Why LinkedList? Keeps retry order simple and efficient.
*/

// Interface for various retry operations (Interface)
interface IRetryableTask
{
    bool Retry();
    string GetTaskDescription();
}

// Concrete Email Retry (Polymorphism)
class EmailRetryTask : IRetryableTask
{
    private string email;
    private int attempts = 0;

    public EmailRetryTask(string email) { this.email = email; }
    public string GetTaskDescription() { return "Email to " + email; }

    public bool Retry()
    {
        attempts++;
        Console.WriteLine("Retrying Email to " + email + "... (Attempt #" + attempts + ")");
        // Simulate success on 2nd attempt
        return attempts >= 2;
    }
}

// Concrete SMS Retry (Polymorphism)
class SmsRetryTask : IRetryableTask
{
    private string phone;
    private int attempts = 0;

    public SmsRetryTask(string phone) { this.phone = phone; }
    public string GetTaskDescription() { return "SMS to " + phone; }

    public bool Retry()
    {
        attempts++;
        Console.WriteLine("Retrying SMS to " + phone + "... (Attempt #" + attempts + ")");
        // Simulate success on 3rd attempt
        return attempts >= 3;
    }
}

// Node for the Retry Queue (LinkedList)
class RetryNode
{
    public IRetryableTask Task;
    public RetryNode Next;

    public RetryNode(IRetryableTask task)
    {
        Task = task;
        Next = null;
    }
}

// Notification Retry Manager
class RetryManager
{
    private RetryNode head = null; // Encapsulation: Retry queue is private
    private RetryNode tail = null;

    // Abstraction: Simple method to add tasks for retry
    public void AddForRetry(IRetryableTask task)
    {
        RetryNode newNode = new RetryNode(task);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Added to retry queue: " + task.GetTaskDescription());
    }

    // Abstraction: Retry logic is hidden from the user
    public void ProcessRetries()
    {
        Console.WriteLine("\n--- Starting Retry Processing Cycle ---");
        RetryNode current = head;
        RetryNode previous = null;

        while (current != null)
        {
            bool success = current.Task.Retry(); // Polymorphism: uniform retry call
            
            if (success)
            {
                Console.WriteLine("SUCCESS: " + current.Task.GetTaskDescription() + " completed.");
                // Remove from queue
                if (previous == null)
                {
                    head = current.Next;
                    if (head == null) tail = null;
                }
                else
                {
                    previous.Next = current.Next;
                    if (current.Next == null) tail = previous;
                }
                current = current.Next;
            }
            else
            {
                Console.WriteLine("FAILED: " + current.Task.GetTaskDescription() + " will be retried again later.");
                previous = current;
                current = current.Next;
            }
        }
        Console.WriteLine("--- End of Retry Cycle ---\n");
    }
}

// Main class to demonstrate the Retry Mechanism
class NotificationRetryDemo
{
    public static void Run()
    {
        RetryManager manager = new RetryManager();

        manager.AddForRetry(new EmailRetryTask("user@example.com"));
        manager.AddForRetry(new SmsRetryTask("+123456789"));

        // Process retries until queue is empty
        manager.ProcessRetries(); // Attempt 1
        manager.ProcessRetries(); // Attempt 2 (Email should succeed)
        manager.ProcessRetries(); // Attempt 3 (SMS should succeed)
    }
}
