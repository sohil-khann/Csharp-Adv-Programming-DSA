/*4.Undo Functionality in Drawing App
Use Case: Maintain stack of actions (line drawn, shape added) and support undo.
OOP Concepts:
 Interface: DrawingAction
 Polymorphism: Multiple actions (line, circle, erase) handled uniformly.
 Encapsulation: Undo stack wrapped inside the app logic*/
using System;
using System.Collections.Generic;
interface DrawingAction //interface for drawing actions
{
    void Execute();     //perform the action
    void Undo();//undo the action
}
class DrawLineAction : DrawingAction//concrete action for drawing a line
{
    private string lineDetails;

    public DrawLineAction(string details)
    {
        lineDetails = details;
    }

    public void Execute()
    {
        Console.WriteLine($"Drawing line: {lineDetails}");
    }

    public void Undo()
    {
        Console.WriteLine($"Undoing line: {lineDetails}");
    }
}

// Drawing application managing actions and undo functionality  
class DrawingApp
{
    private Stack<DrawingAction> actionStack;

    public DrawingApp()//constructor
    {
        actionStack = new Stack<DrawingAction>();
    }

    public void PerformAction(DrawingAction action)//perform and store action
    {
        action.Execute();
        actionStack.Push(action);
    }

    public void Undo()      //undo last action
    {
        if (actionStack.Count > 0)
        {
            DrawingAction lastAction = actionStack.Pop();
            lastAction.Undo();
        }
        else
        {
            Console.WriteLine("No actions to undo.");
        }
    }
}
class UndoFunc
{
    public void Call()//demo method
    {
        DrawingApp app = new DrawingApp();
        DrawingAction line1 = new DrawLineAction("Line from (0,0) to (1,1)");
        DrawingAction line2 = new DrawLineAction("Line from (1,1) to (2,2)");

        app.PerformAction(line1);
        app.PerformAction(line2);

        app.Undo();
        app.Undo();
        app.Undo(); // No actions to undo
    }
}