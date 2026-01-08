using System;

/* 
Scenario 4: Customer Service Call Center Queue
Use Case: Handle customer support tickets in order of arrival.
Why LinkedList? FIFO nature can be modeled via a queue using LinkedList.
*/

// Base class for support tickets
abstract class Ticket
{
    public int TicketId;
    public string CustomerName;

    public Ticket(int id, string name)
    {
        TicketId = id;
        CustomerName = name;
    }

    // Polymorphism: Each ticket type can describe itself differently
    public abstract void Process();
}

// Specific ticket types (Polymorphism)
class PhoneTicket : Ticket
{
    public string PhoneNumber;
    public PhoneTicket(int id, string name, string phone) : base(id, name) 
    {
        PhoneNumber = phone;
    }
    public override void Process()
    {
        Console.WriteLine("Processing Phone Ticket #" + TicketId + " for " + CustomerName + " (Call: " + PhoneNumber + ")");
    }
}

class EmailTicket : Ticket
{
    public string EmailAddress;
    public EmailTicket(int id, string name, string email) : base(id, name)
    {
        EmailAddress = email;
    }
    public override void Process()
    {
        Console.WriteLine("Processing Email Ticket #" + TicketId + " for " + CustomerName + " (Email: " + EmailAddress + ")");
    }
}

// Node class for the Queue (LinkedList)
class TicketNode
{
    public Ticket Data; // Encapsulation: Ticket is stored in the node
    public TicketNode Next;

    public TicketNode(Ticket ticket)
    {
        Data = ticket;
        Next = null;
    }
}

// Queue class to manage tickets
class CallCenterQueue
{
    private TicketNode front = null; // Encapsulation: Internal structure is private
    private TicketNode rear = null;

    // Abstraction: Add a ticket to the queue
    public void AddTicket(Ticket ticket)
    {
        TicketNode newNode = new TicketNode(ticket);
        if (rear == null)
        {
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
        Console.WriteLine("Ticket #" + ticket.TicketId + " added to queue.");
    }

    // Abstraction: Process the next ticket in line (FIFO)
    public void ProcessNextTicket()
    {
        if (front == null)
        {
            Console.WriteLine("No tickets to process.");
            return;
        }

        Ticket ticketToProcess = front.Data;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        ticketToProcess.Process(); // Polymorphism in action
    }

    public void ShowQueueStatus()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine("\n--- Waiting Tickets ---");
        TicketNode temp = front;
        while (temp != null)
        {
            Console.WriteLine("- Ticket #" + temp.Data.TicketId + " (" + temp.Data.CustomerName + ")");
            temp = temp.Next;
        }
        Console.WriteLine("-----------------------\n");
    }
}

// Main class to demonstrate the Call Center Queue
class CustomerServiceDemo
{
    public static void Run()
    {
        CallCenterQueue myQueue = new CallCenterQueue();

        // Adding different types of tickets (Polymorphism)
        myQueue.AddTicket(new PhoneTicket(101, "Sohil", "555-0101"));
        myQueue.AddTicket(new EmailTicket(102, "Raj", "raj@example.com"));
        myQueue.AddTicket(new PhoneTicket(103, "Sai", "555-0103"));

        myQueue.ShowQueueStatus();

        myQueue.ProcessNextTicket();
        myQueue.ProcessNextTicket();

        myQueue.ShowQueueStatus();
        
        myQueue.ProcessNextTicket();
        myQueue.ProcessNextTicket(); // Should be empty
    }
}
