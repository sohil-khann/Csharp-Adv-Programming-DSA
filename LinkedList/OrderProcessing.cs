using System;

/* 
Scenario 11: Order Processing System with Interface for Order Types
Use Case: Process different types of orders: online, offline, subscription.
Why LinkedList? Orders arrive sequentially and are processed in FIFO order.
*/

// Order Interface (Interface)
interface IOrder
{
    void Process();
    int GetOrderId();
}

// Concrete Order Types (Polymorphism)
class OnlineOrder : IOrder
{
    private int orderId;
    public OnlineOrder(int id) { this.orderId = id; }
    public int GetOrderId() { return orderId; }
    public void Process()
    {
        Console.WriteLine("Processing Online Order #" + orderId + ": Validating payment and scheduling delivery.");
    }
}

class OfflineOrder : IOrder
{
    private int orderId;
    public OfflineOrder(int id) { this.orderId = id; }
    public int GetOrderId() { return orderId; }
    public void Process()
    {
        Console.WriteLine("Processing Offline Order #" + orderId + ": Printing receipt and updating store inventory.");
    }
}

class SubscriptionOrder : IOrder
{
    private int orderId;
    public SubscriptionOrder(int id) { this.orderId = id; }
    public int GetOrderId() { return orderId; }
    public void Process()
    {
        Console.WriteLine("Processing Subscription Order #" + orderId + ": Renewing subscription and sending access keys.");
    }
}

// Node for the Order Queue (LinkedList)
class OrderNode
{
    public IOrder Order;
    public OrderNode Next;

    public OrderNode(IOrder order)
    {
        Order = order;
        Next = null;
    }
}

// Order Processor class
class OrderProcessor
{
    private OrderNode head = null; // Encapsulation: Order queue is wrapped
    private OrderNode tail = null;

    public void ReceiveOrder(IOrder order)
    {
        OrderNode newNode = new OrderNode(order);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Received Order #" + order.GetOrderId());
    }

    public void ProcessAllOrders()
    {
        Console.WriteLine("\n--- Starting Order Processing ---");
        while (head != null)
        {
            head.Order.Process(); // Polymorphism in action
            head = head.Next;
        }
        tail = null;
        Console.WriteLine("--- All orders processed ---\n");
    }
}

// Main class to demonstrate the Order Processing System
class OrderProcessingDemo
{
    public static void Run()
    {
        OrderProcessor processor = new OrderProcessor();

        processor.ReceiveOrder(new OnlineOrder(5001));
        processor.ReceiveOrder(new SubscriptionOrder(9001));
        processor.ReceiveOrder(new OfflineOrder(1001));

        processor.ProcessAllOrders();
    }
}
