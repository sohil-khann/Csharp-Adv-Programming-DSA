/*
2. Ticket Booking System Queue
Use Case: Ticket requests (flight, train, bus) are processed in the sequence they arrive.
OOP Concepts:
- Interface: ITicketRequest
- Encapsulation: Request queue managed inside a service.
- Abstraction & Polymorphism: Works for bus, train, and flight tickets with a common interface.
*/

using System;
using System.Collections.Generic;

namespace QueueManagement
{
    // Interface defining the behavior of a ticket request
    public interface ITicketRequest
    {
        string PassengerName { get; }
        string TransportType { get; }
        void ProcessBooking();
    }

    // Concrete implementation for Flight
    public class FlightTicket : ITicketRequest
    {
        public string PassengerName { get; }
        public string TransportType { get { return "Flight"; } }
        public FlightTicket(string name) { PassengerName = name; }
        public void ProcessBooking() { Console.WriteLine($"[Flight] Booking confirmed for {PassengerName}. Checking passport details..."); }
    }

    // Concrete implementation for Train
    public class TrainTicket : ITicketRequest
    {
        public string PassengerName { get; }
        public string TransportType { get { return "Train"; } }
        public TrainTicket(string name) { PassengerName = name; }
        public void ProcessBooking() { Console.WriteLine($"[Train] Booking confirmed for {PassengerName}. Assigning seat in Coach A..."); }
    }

    // Service class for managing the queue
    public class BookingService
    {
        private Queue<ITicketRequest> _requestQueue = new Queue<ITicketRequest>();

        public void EnqueueRequest(ITicketRequest request)
        {
            _requestQueue.Enqueue(request);
            Console.WriteLine($"Received request: {request.TransportType} for {request.PassengerName}");
        }

        public void ProcessAllRequests()
        {
            Console.WriteLine("\nProcessing Ticket Requests...");
            while (_requestQueue.Count > 0)
            {
                ITicketRequest current = _requestQueue.Dequeue();
                current.ProcessBooking();
            }
            Console.WriteLine("All bookings processed.");
        }
    }

    public class TicketBookingDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 2: Ticket Booking System ---");
            BookingService service = new BookingService();

            service.EnqueueRequest(new FlightTicket("Sohil"));
            service.EnqueueRequest(new TrainTicket("ravi"));
            service.EnqueueRequest(new FlightTicket("kishan"));

            service.ProcessAllRequests();
            Console.WriteLine();
        }
    }
}
