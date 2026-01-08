using System;

/* 
Scenario 12: Job Execution System with Executable Interface
Use Case: Background service that executes various jobs like data sync, email alerts, cleanup, etc.
*/

// Executable Interface (Interface)
interface IExecutable
{
    void Execute();
    string GetJobName();
}

// Concrete Job Types (Polymorphism)
class DataSyncJob : IExecutable
{
    public string GetJobName() { return "Data Synchronization"; }
    public void Execute()
    {
        Console.WriteLine("Running [Data Synchronization]: Syncing local database with cloud...");
    }
}

class EmailAlertJob : IExecutable
{
    public string GetJobName() { return "Email Alerts"; }
    public void Execute()
    {
        Console.WriteLine("Running [Email Alerts]: Sending pending system notifications...");
    }
}

class CleanupJob : IExecutable
{
    public string GetJobName() { return "System Cleanup"; }
    public void Execute()
    {
        Console.WriteLine("Running [System Cleanup]: Deleting temporary logs and cache files...");
    }
}

// Node for Job Queue (LinkedList)
class JobNode
{
    public IExecutable Job;
    public JobNode Next;

    public JobNode(IExecutable job)
    {
        Job = job;
        Next = null;
    }
}

// Job Scheduler / Execution Engine
class JobExecutionEngine
{
    private JobNode head = null;
    private JobNode tail = null;

    // Abstraction: Simple method to add jobs
    public void QueueJob(IExecutable job)
    {
        JobNode newNode = new JobNode(job);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Job Queued: " + job.GetJobName());
    }

    // Abstraction & Polymorphism: Uniform execution loop
    public void RunAllJobs()
    {
        Console.WriteLine("\n--- Starting Background Job Execution ---");
        while (head != null)
        {
            Console.WriteLine("Executing next job...");
            head.Job.Execute(); // Polymorphism: logic varies per job
            head = head.Next;
        }
        tail = null;
        Console.WriteLine("--- All background jobs completed ---\n");
    }
}

// Main class to demonstrate Job Execution
class JobExecutionDemo
{
    public static void Run()
    {
        JobExecutionEngine engine = new JobExecutionEngine();

        engine.QueueJob(new DataSyncJob());
        engine.QueueJob(new EmailAlertJob());
        engine.QueueJob(new CleanupJob());

        engine.RunAllJobs();
    }
}
