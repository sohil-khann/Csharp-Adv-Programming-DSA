using System;

/* 
Scenario 6: Task Scheduler with Prioritization
Use Case: A system schedules tasks based on priority, dynamically updating the task queue.
Why LinkedList? Enables dynamic insertion at any position (based on priority).
*/

// Base class for tasks (Encapsulation)
abstract class BaseTask
{
    public string TaskName;
    public int Priority; // Higher number means higher priority

    public BaseTask(string name, int priority)
    {
        TaskName = name;
        Priority = priority;
    }

    // Polymorphism: Different tasks execute differently
    public abstract void Execute();
}

// Specific Task types (Polymorphism)
class EmailTask : BaseTask
{
    public EmailTask(string name, int priority) : base(name, priority) { }
    public override void Execute()
    {
        Console.WriteLine("Executing Email Task: " + TaskName + " (Priority: " + Priority + ")");
    }
}

class ReportTask : BaseTask
{
    public ReportTask(string name, int priority) : base(name, priority) { }
    public override void Execute()
    {
        Console.WriteLine("Executing Report Task: " + TaskName + " (Priority: " + Priority + ")");
    }
}

// Node class for Priority Queue (LinkedList)
class TaskNode
{
    public BaseTask Task;
    public TaskNode Next;

    public TaskNode(BaseTask task)
    {
        Task = task;
        Next = null;
    }
}

// Task Scheduler class
class TaskScheduler
{
    private TaskNode head = null; // Encapsulation: Task list is private

    // Abstraction: Hide complexity of inserting by priority
    public void ScheduleTask(BaseTask task)
    {
        TaskNode newNode = new TaskNode(task);

        // If list is empty or new task has higher priority than head
        if (head == null || task.Priority > head.Task.Priority)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            // Traverse to find the correct position
            TaskNode current = head;
            while (current.Next != null && current.Next.Task.Priority >= task.Priority)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        Console.WriteLine("Scheduled: " + task.TaskName);
    }

    public void RunNextTask()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks scheduled.");
            return;
        }

        BaseTask taskToRun = head.Task;
        head = head.Next;
        taskToRun.Execute();
    }

    public void DisplayTasks()
    {
        Console.WriteLine("\n--- Pending Tasks (Priority Order) ---");
        TaskNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("- [" + temp.Task.Priority + "] " + temp.Task.TaskName);
            temp = temp.Next;
        }
    }
}

// Main class to demonstrate the Task Scheduler
class TaskSchedulerDemo
{
    public static void Run()
    {
        TaskScheduler scheduler = new TaskScheduler();

        scheduler.ScheduleTask(new EmailTask("Send Welcome Email", 1));
        scheduler.ScheduleTask(new ReportTask("Generate Monthly Report", 5)); // High priority
        scheduler.ScheduleTask(new EmailTask("Send Password Reset", 10)); // Very high priority
        scheduler.ScheduleTask(new ReportTask("Cleanup Temp Files", 2));

        scheduler.DisplayTasks();

        scheduler.RunNextTask(); // Should be Password Reset
        scheduler.RunNextTask(); // Should be Monthly Report

        scheduler.DisplayTasks();
    }
}
