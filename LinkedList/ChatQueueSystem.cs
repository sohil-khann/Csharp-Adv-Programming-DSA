using System;

/* 
Scenario 13: Customer Support Chat Queue System
Use Case: Customers are put in a queue to chat with the next available agent.
Why LinkedList? FIFO nature helps maintain order of service.
*/

// Interface for any type of user request (Interface)
interface IUserRequest
{
    void HandleRequest();
    string GetCustomerName();
}

// Concrete Chat Request (Polymorphism)
class ChatRequest : IUserRequest
{
    private string customerName;
    public ChatRequest(string name) { customerName = name; }
    public string GetCustomerName() { return customerName; }
    public void HandleRequest()
    {
        Console.WriteLine("Connecting " + customerName + " to a live chat agent...");
    }
}

// Concrete Call Request (Polymorphism)
class CallRequest : IUserRequest
{
    private string customerName;
    public CallRequest(string name) { customerName = name; }
    public string GetCustomerName() { return customerName; }
    public void HandleRequest()
    {
        Console.WriteLine("Routing phone call from " + customerName + " to the next available agent...");
    }
}

// Node for the Chat Queue (LinkedList)
class RequestNode
{
    public IUserRequest Request;
    public RequestNode Next;

    public RequestNode(IUserRequest request)
    {
        Request = request;
        Next = null;
    }
}

// Chat Queue Manager
class ChatQueueManager
{
    private RequestNode head = null; // Encapsulation: Queue is managed privately
    private RequestNode tail = null;

    // Abstraction: Simple API to add service
    public void EnqueueRequest(IUserRequest request)
    {
        RequestNode newNode = new RequestNode(request);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Request from " + request.GetCustomerName() + " added to the queue.");
    }

    // Abstraction: Simple API to request service
    public void ServeNextCustomer()
    {
        if (head == null)
        {
            Console.WriteLine("No customers waiting in the queue.");
            return;
        }

        IUserRequest nextRequest = head.Request;
        head = head.Next;

        if (head == null)
        {
            tail = null;
        }

        nextRequest.HandleRequest(); // Polymorphism in action
    }

    public void DisplayQueueStatus()
    {
        Console.WriteLine("\n--- Current Chat Queue ---");
        if (head == null)
        {
            Console.WriteLine("Queue is empty.");
        }
        else
        {
            RequestNode temp = head;
            int position = 1;
            while (temp != null)
            {
                Console.WriteLine(position + ". " + temp.Request.GetCustomerName());
                temp = temp.Next;
                position++;
            }
        }
        Console.WriteLine("--------------------------\n");
    }
}

// Main class to demonstrate the Chat Queue System
class ChatQueueDemo
{
    public static void Run()
    {
        ChatQueueManager manager = new ChatQueueManager();

        manager.EnqueueRequest(new ChatRequest("sohil"));
        manager.EnqueueRequest(new CallRequest("Raj"));
        manager.EnqueueRequest(new ChatRequest("Tanuj"));

        manager.DisplayQueueStatus();

        manager.ServeNextCustomer();
        manager.ServeNextCustomer();

        manager.DisplayQueueStatus();

        manager.ServeNextCustomer();
        manager.ServeNextCustomer(); // Should be empty
    }
}
