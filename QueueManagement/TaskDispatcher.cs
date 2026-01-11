/*
3. Task Dispatcher for Background Workers
Use Case: Queue tasks like file uploads, analytics, or logs to be processed by workers.
OOP Concepts:
- Interface: IBackgroundTask
- Encapsulation: TaskQueue shields the internal queue logic.
- Polymorphism: Different tasks (upload, report) use the same interface.
*/

using System;
using System.Collections.Generic;

namespace QueueManagement
{
    // Interface for background tasks
    public interface IBackgroundTask
    {
        string TaskName { get; }
        void Execute();
    }

    // Task for file uploads
    public class FileUploadTask : IBackgroundTask
    {
        public string TaskName
        {
            get { return "File Upload"; }
        }

        private string _fileName;

        public FileUploadTask(string file)
        {
            _fileName = file;
        }

        public void Execute()
        {
            Console.WriteLine("Executing " + TaskName + ": Uploading " + _fileName + " to the cloud...");
        }
    }

    // Task for analytics
    public class AnalyticsReportTask : IBackgroundTask
    {
        public string TaskName
        {
            get { return "Analytics Report"; }
        }

        public void Execute()
        {
            Console.WriteLine("Executing " + TaskName + ": Generating monthly usage statistics...");
        }
    }

    // The Dispatcher class
    public class TaskDispatcher
    {
        private Queue<IBackgroundTask> _taskQueue = new Queue<IBackgroundTask>();

        public void ScheduleTask(IBackgroundTask task)
        {
            _taskQueue.Enqueue(task);
            Console.WriteLine("Scheduled: " + task.TaskName);
        }

        public void RunWorkers()
        {
            Console.WriteLine("\nWorkers starting to process tasks...");
            while (_taskQueue.Count > 0)
            {
                IBackgroundTask task = _taskQueue.Dequeue();
                task.Execute();
            }
            Console.WriteLine("All background tasks finished.");
        }
    }

    public class TaskDispatcherDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 3: Task Dispatcher for Background Workers ---");
            TaskDispatcher dispatcher = new TaskDispatcher();

            dispatcher.ScheduleTask(new FileUploadTask("profile_pic.png"));
            dispatcher.ScheduleTask(new AnalyticsReportTask());
            dispatcher.ScheduleTask(new FileUploadTask("data_dump.csv"));

            dispatcher.RunWorkers();
            Console.WriteLine();
        }
    }
}
