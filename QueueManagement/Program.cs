using System;

namespace QueueManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1. Print Job Manager
            PrintJobManagerDemo.Run();

            // 2. Ticket Booking System
            TicketBookingDemo.Run();

            // 3. Task Dispatcher for Background Workers
            TaskDispatcherDemo.Run();

            // 4. Call Center Management System
            CallCenterDemo.Run();

            Console.ReadKey();
        }
    }
}
