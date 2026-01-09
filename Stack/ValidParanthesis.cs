/*3.Syntax Checker for Code Editors
Use Case: Validate matched parentheses, brackets, or braces ({}, [], ()).
OOP Concepts:
 Interface: SyntaxChecker
 Encapsulation: Stack logic is hidden inside the implementation.
 Polymorphism: Can create multiple syntax checkers for different file types.*/
using System;
interface SyntaxChecker
{
    bool IsValid(string code);
}
class ParenthesisChecker : SyntaxChecker
{
    public bool IsValid(string code)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in code)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0) return false;
                char last = stack.Pop();
                if (!IsMatchingPair(last, ch)) return false;
            }
        }
        return stack.Count == 0;
    }

    private bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
}
class ValidParanthesis
{
    public void Call()
    {
        SyntaxChecker checker = new ParenthesisChecker();
        string codeSample = "{ [ (( ) ] }";
        bool isValid = checker.IsValid(codeSample);
        Console.WriteLine($"The code sample \"{codeSample}\" is valid: {isValid}");
    }
}