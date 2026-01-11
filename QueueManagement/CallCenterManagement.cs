/*
4. Call Center Management System
Use Case: Incoming calls are queued for available agents.
OOP Concepts:
- Interface: ICallRequest
- Polymorphism: Calls could be SupportCall, SalesCall, etc.
- Encapsulation: Queue handling hidden inside CallCenterManager.
*/

using System;
using System.Collections.Generic;

namespace QueueManagement
{
    // Interface for incoming calls
    public interface ICallRequest
    {
        string CallerName { get; }
        string CallType { get; }
        void HandleCall();
    }

    // Support Call Implementation
    public class SupportCall : ICallRequest
    {
        public string CallerName { get; }
        public string CallType { get { return "Technical Support"; } }
        public SupportCall(string name) { CallerName = name; }
        public void HandleCall() { Console.WriteLine("Connecting " + CallerName + " to a Technical Support Agent..."); }
    }

    // Sales Call Implementation
    public class SalesCall : ICallRequest
    {
        public string CallerName { get; }
        public string CallType { get { return "Sales Inquiry"; } }
        public SalesCall(string name) { CallerName = name; }
        public void HandleCall() { Console.WriteLine("Connecting " + CallerName + " to a Sales Representative..."); }
    }

    // Manager class for the Call Center
    public class CallCenterManager
    {
        private Queue<ICallRequest> _waitingCalls = new Queue<ICallRequest>();

        public void AddCallToQueue(ICallRequest call)
        {
            _waitingCalls.Enqueue(call);
            Console.WriteLine("New incoming call from " + call.CallerName + " (" + call.CallType + ")");
        }

        public void AssignCallsToAgents()
        {
            Console.WriteLine("\nAssigning waiting calls to available agents...");
            if (_waitingCalls.Count == 0)
            {
                Console.WriteLine("No calls waiting in queue.");
                return;
            }

            while (_waitingCalls.Count > 0)
            {
                ICallRequest nextCall = _waitingCalls.Dequeue();
                nextCall.HandleCall();
            }
            Console.WriteLine("Queue is now empty.");
        }
    }

    public class CallCenterDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 4: Call Center Management System ---");
            CallCenterManager manager = new CallCenterManager();

            manager.AddCallToQueue(new SupportCall("Sohil"));
            manager.AddCallToQueue(new SalesCall("Ravi"));
            manager.AddCallToQueue(new SupportCall("Keshav"));

            manager.AssignCallsToAgents();
            Console.WriteLine();
        }
    }
}
