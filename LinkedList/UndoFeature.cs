using System;

/* 
Scenario 3: Undo Feature in Text Editor
Use Case: Every edit is stored and can be undone step-by-step.
Why LinkedList? LIFO structure fits Stack backed by LinkedList.
*/

// Base class for any document change (Inheritance)
class EditorState
{
    public string Content;
    public DateTime Timestamp;

    public EditorState(string content)
    {
        Content = content;
        Timestamp = DateTime.Now;
    }
}

// Specific state for text editing (Inheritance)
class TextState : EditorState
{
    public TextState(string content) : base(content)
    {
    }
}

// Node class for the Undo Stack (LinkedList)
class StateNode
{
    public EditorState State; // Encapsulation: State is wrapped
    public StateNode Next;

    public StateNode(EditorState state)
    {
        State = state;
        Next = null;
    }
}

// The Editor class manages the history
class TextEditor
{
    private string currentText = "";
    private StateNode historyHead = null; // Encapsulation: History is private

    // Abstraction: Simple method to type text
    public void Type(string newText)
    {
        // Save current state before changing (Encapsulation)
        SaveToHistory();
        currentText += newText;
        Console.WriteLine("Typed: \"" + newText + "\". Current Content: " + currentText);
    }

    private void SaveToHistory()
    {
        EditorState state = new TextState(currentText);
        StateNode newNode = new StateNode(state);
        newNode.Next = historyHead;
        historyHead = newNode;
    }

    // Abstraction: Simple method to undo (Abstraction)
    public void Undo()
    {
        if (historyHead != null)
        {
            currentText = historyHead.State.Content;
            historyHead = historyHead.Next;
            Console.WriteLine("Undo performed. Current Content: " + currentText);
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    public void ShowCurrentContent()
    {
        Console.WriteLine("Current Editor Content: " + currentText);
    }
}

// Main class to demonstrate the Undo Feature
class UndoFeatureDemo
{
    public static void Run()
    {
        TextEditor myEditor = new TextEditor();

        myEditor.Type("Hello ");
        myEditor.Type("World!");
        myEditor.Type(" How are you?");

        myEditor.ShowCurrentContent();

        myEditor.Undo();
        myEditor.Undo();

        myEditor.ShowCurrentContent();
    }
}
