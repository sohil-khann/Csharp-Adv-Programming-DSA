using System;

/* 
Scenario 16: Workflow Engine with Dynamic Steps
Use Case: A document approval workflow system executes multiple steps (validate, review, approve) in sequence.
Why LinkedList? Each step is a node; can be dynamically inserted/removed.
*/

// Interface for workflow steps (Interface)
interface IWorkflowStep
{
    bool Process(string document);
    string GetStepName();
}

// Concrete Step: Validation (Polymorphism)
class ValidationStep : IWorkflowStep
{
    public string GetStepName() { return "Document Validation"; }
    public bool Process(string document)
    {
        Console.WriteLine("Step [" + GetStepName() + "]: Checking if document is not empty...");
        return !string.IsNullOrEmpty(document);
    }
}

// Concrete Step: Review (Polymorphism)
class ReviewStep : IWorkflowStep
{
    public string GetStepName() { return "Manager Review"; }
    public bool Process(string document)
    {
        Console.WriteLine("Step [" + GetStepName() + "]: Reviewing document content...");
        return document.Contains("Approved"); // Simulate review logic
    }
}

// Concrete Step: Final Approval (Polymorphism)
class ApprovalStep : IWorkflowStep
{
    public string GetStepName() { return "Final Approval"; }
    public bool Process(string document)
    {
        Console.WriteLine("Step [" + GetStepName() + "]: Archiving document and notifying stakeholders...");
        return true;
    }
}

// Node for the Workflow (LinkedList)
class WorkflowNode
{
    public IWorkflowStep Step;
    public WorkflowNode Next;

    public WorkflowNode(IWorkflowStep step)
    {
        Step = step;
        Next = null;
    }
}

// Workflow Engine
class WorkflowEngine
{
    private WorkflowNode head = null; // Encapsulation: Workflow structure is private
    private WorkflowNode tail = null;

    // Abstraction: Simple method to add steps to the workflow
    public void AddStep(IWorkflowStep step)
    {
        WorkflowNode newNode = new WorkflowNode(step);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        Console.WriteLine("Workflow Step Added: " + step.GetStepName());
    }

    // Abstraction & Encapsulation: Execution logic is hidden
    public void ExecuteWorkflow(string document)
    {
        Console.WriteLine("\n--- Starting Workflow Execution ---");
        WorkflowNode current = head;
        bool success = true;

        while (current != null && success)
        {
            success = current.Step.Process(document); // Polymorphism: uniform call
            
            if (success)
            {
                Console.WriteLine(">>> Step [" + current.Step.GetStepName() + "] completed successfully.");
                current = current.Next;
            }
            else
            {
                Console.WriteLine(">>> Step [" + current.Step.GetStepName() + "] FAILED. Stopping workflow.");
            }
        }

        if (success)
        {
            Console.WriteLine("--- Workflow Completed Successfully ---\n");
        }
        else
        {
            Console.WriteLine("--- Workflow Aborted ---\n");
        }
    }
}

// Main class to demonstrate the Workflow Engine
class WorkflowEngineDemo
{
    public static void Run()
    {
        WorkflowEngine engine = new WorkflowEngine();

        engine.AddStep(new ValidationStep());
        engine.AddStep(new ReviewStep());
        engine.AddStep(new ApprovalStep());

        Console.WriteLine("\n--- Running Workflow with 'Draft' ---");
        engine.ExecuteWorkflow("This is a Draft."); // Should fail review

        Console.WriteLine("\n--- Running Workflow with 'Approved Document' ---");
        engine.ExecuteWorkflow("This is an Approved Document."); // Should pass all
    }
}
