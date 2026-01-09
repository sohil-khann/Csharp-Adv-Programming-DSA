   
using System;
namespace Stack{
    class Program
    {
        static void Main(string[] args)
        {
            //for expression evaluation

            // ExpressionEvaluation eval = new ExpressionEvaluation();
            // eval.Call();

            //for tab navigation
            // TabNavigationMain tabNav = new TabNavigationMain();
            // tabNav.Call();

            //for valid paranthesis
            // ValidParanthesis vp = new ValidParanthesis();
            // vp.Call();

            //for undo functionality
            UndoFunc undoDemo = new UndoFunc();
            undoDemo.Call();

            Console.ReadLine();
        }
    }
}

