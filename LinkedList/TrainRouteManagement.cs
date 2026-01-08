using System;

/* 
Scenario 5: Train Route Management System
Use Case: A railway system manages stations as linked stops in a train's route. 
You can dynamically insert, remove, or reverse the route.
Why LinkedList? Allows dynamic insertion/removal of stations and easy traversal.
*/

// Node class for a Railway Station
class Station
{
    public string Name;
    public Station Next;

    public Station(string name)
    {
        Name = name;
        Next = null;
    }
}

// Base class for a Route (Encapsulation)
class TrainRoute
{
    protected Station head = null; // Encapsulation: Station list is protected

    // Abstraction: Public methods to hide internal pointer logic
    public void AddStation(string name)
    {
        Station newStation = new Station(name);
        if (head == null)
        {
            head = newStation;
        }
        else
        {
            Station temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newStation;
        }
        Console.WriteLine("Added Station: " + name);
    }

    public void RemoveStation(string name)
    {
        if (head == null) return;

        if (head.Name == name)
        {
            head = head.Next;
            Console.WriteLine("Removed Station: " + name);
            return;
        }

        Station temp = head;
        while (temp.Next != null && temp.Next.Name != name)
        {
            temp = temp.Next;
        }

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Removed Station: " + name);
        }
    }

    // Dynamic reverse logic (LinkedList benefit)
    public void ReverseRoute()
    {
        Station prev = null;
        Station current = head;
        Station next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = prev;
        Console.WriteLine("Route has been reversed.");
    }

    // Polymorphism: Method to be overridden
    public virtual void Travel()
    {
        Console.WriteLine("Traveling through route...");
        Station temp = head;
        while (temp != null)
        {
            Console.Write(temp.Name + (temp.Next != null ? " -> " : ""));
            temp = temp.Next;
        }
        Console.WriteLine();
    }
}

// Specialized train route (Inheritance)
class ExpressRoute : TrainRoute
{
    // Polymorphism: Overriding travel rules
    public override void Travel()
    {
        Console.WriteLine("Express Train is skipping minor stops... ");
        base.Travel();
    }
}

// Main class to demonstrate Route Management
class TrainRouteDemo
{
    public static void Run()
    {
        ExpressRoute myRoute = new ExpressRoute();

        myRoute.AddStation("Vrindavan Road");
        myRoute.AddStation("Mathura junction");
        myRoute.AddStation("Agra Cantt");
        myRoute.AddStation("Raja ki mandi");

        myRoute.Travel();

        myRoute.ReverseRoute();
        myRoute.Travel();

        myRoute.RemoveStation("Agra Cantt");
        myRoute.Travel();
    }
}
