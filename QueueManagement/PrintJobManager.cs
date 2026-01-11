/*
1. Print Job Manager
Use Case: Print requests are handled in the order they are received.
OOP Concepts:
- Interface: IPrintable (Defines the print action)
- Encapsulation: PrintQueue class hides the internal Queue structure.
- Polymorphism: Different document types (TextDocument, ImageFile) implement the same interface.
*/

using System;
using System.Collections.Generic;

namespace QueueManagement
{
    // Interface for printable objects
    public interface IPrintable
    {
        string GetDocumentName();
        void Print();
    }

    // Concrete implementation: Text Document
    public class TextDocument : IPrintable
    {
        private string _name;
        public TextDocument(string name)
        {
            _name = name;
        }
        public string GetDocumentName()
        {
            return _name;
        }
        public void Print()
        {
            Console.WriteLine("Printing Text Document: " + _name + " (Formatting text...)");
        }
    }

    // Concrete implementation: Image File
    public class ImageFile : IPrintable
    {
        private string _name;
        public ImageFile(string name)
        {
            _name = name;
        }
        public string GetDocumentName()
        {
            return _name;
        }
        public void Print()
        {
            Console.WriteLine("Printing Image File: " + _name + " (Processing pixels...)");
        }
    }

    // Manager class demonstrating Encapsulation
    public class PrintQueueManager
    {
        private Queue<IPrintable> _jobs = new Queue<IPrintable>();

        public void AddJob(IPrintable job)
        {
            _jobs.Enqueue(job);
            Console.WriteLine("Added to Queue: " + job.GetDocumentName());
        }

        public void ProcessJobs()
        {
            Console.WriteLine("\nStarting Print Processing...");
            while (_jobs.Count > 0)
            {
                IPrintable currentJob = _jobs.Dequeue();
                currentJob.Print();
            }
            Console.WriteLine("All print jobs completed.");
        }
    }

    public class PrintJobManagerDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 1: Print Job Manager ---");
            PrintQueueManager manager = new PrintQueueManager();

            manager.AddJob(new TextDocument("Resume.pdf"));
            manager.AddJob(new ImageFile("VacationPhoto.jpg"));
            manager.AddJob(new TextDocument("Notes.txt"));

            manager.ProcessJobs();
            Console.WriteLine();
        }
    }
}
