using System;

/* 
Scenario 9: Undo/Redo Manager with Interface-Based Command Pattern
Use Case: Implement an undo/redo manager for operations like typing, deleting, etc.
Why LinkedList? Acts as a stack for undo and redo operations.
*/

// Command Interface (Interface)
interface ICommand
{
    void Execute();
    void Undo();
}

// Concrete Command for typing (Polymorphism)
class TypeCommand : ICommand
{
    private string text;
    private Document doc;

    public TypeCommand(Document doc, string text)
    {
        this.doc = doc;
        this.text = text;
    }

    public void Execute()
    {
        doc.Append(text);
    }

    public void Undo()
    {
        doc.Remove(text.Length);
    }
}

// Receiver class
class Document
{
    private string content = "";
    public void Append(string text) { content += text; }
    public void Remove(int length) { content = content.Substring(0, content.Length - length); }
    public void Show() { Console.WriteLine("Document Content: " + content); }
}

// Node for Command Stack (LinkedList)
class CommandNode
{
    public ICommand Command;
    public CommandNode Next;

    public CommandNode(ICommand cmd)
    {
        Command = cmd;
        Next = null;
    }
}

// Invoker and History Manager
class HistoryManager
{
    private CommandNode undoStack = null; // Encapsulation: Private stacks
    private CommandNode redoStack = null;

    // Abstraction: User doesn't see the inner workings of the stacks
    public void ExecuteCommand(ICommand cmd)
    {
        cmd.Execute();
        Push(ref undoStack, cmd);
        redoStack = null; // Clear redo stack on new command
    }

    public void Undo()
    {
        if (undoStack == null) return;

        ICommand cmd = Pop(ref undoStack);
        cmd.Undo();
        Push(ref redoStack, cmd);
        Console.WriteLine("Undo action performed.");
    }

    public void Redo()
    {
        if (redoStack == null) return;

        ICommand cmd = Pop(ref redoStack);
        cmd.Execute();
        Push(ref undoStack, cmd);
        Console.WriteLine("Redo action performed.");
    }

    // Helper methods for LinkedList as Stack
    private void Push(ref CommandNode stack, ICommand cmd)
    {
        CommandNode newNode = new CommandNode(cmd);
        newNode.Next = stack;
        stack = newNode;
    }

    private ICommand Pop(ref CommandNode stack)
    {
        if (stack == null) return null;
        ICommand cmd = stack.Command;
        stack = stack.Next;
        return cmd;
    }
}

// Main class to demonstrate the Command Pattern
class CommandPatternDemo
{
    public static void Run()
    {
        Document myDoc = new Document();
        HistoryManager history = new HistoryManager();

        Console.WriteLine("--- Starting Document Operations ---");
        
        ICommand cmd1 = new TypeCommand(myDoc, "Hello ");
        history.ExecuteCommand(cmd1);
        myDoc.Show();

        ICommand cmd2 = new TypeCommand(myDoc, "World!");
        history.ExecuteCommand(cmd2);
        myDoc.Show();

        history.Undo();
        myDoc.Show();

        history.Redo();
        myDoc.Show();
    }
}
