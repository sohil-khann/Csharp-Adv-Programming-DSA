/*
1. Expression Evaluation Engine (Infix to Postfix + Evaluation)
Use Case: Parse and evaluate mathematical expressions in calculators or compilers.
OOP Concepts:
 Interface: ExpressionEvaluator Encapsulation: Stack operations hidden inside evaluator.
 Polymorphism: Different strategies like PostfixEvaluator, PrefixEvaluator.
*/
using System;
using System.Collections.Generic;
internal class ExpressionEvaluation
{
    public  void Call()
    {
        ExpressionEvaluator evaluator = new PostfixEvaluator();
        string expression = "3 4 + 2 * 7 /"; // Equivalent to ((3 + 4) * 2) / 7
        double result = evaluator.Evaluate(expression);
        Console.WriteLine($"The result of the expression '{expression}' is: {result}");
        ExpressionEvaluator prefixEvaluator = new PrefixEvaluator();
        string prefixExpression = "/ * + 3 4 2 7"; // Equivalent
        double prefixResult = prefixEvaluator.Evaluate(prefixExpression);
        Console.WriteLine($"The result of the prefix expression '{prefixExpression}' is: {prefixResult}");

    }
}
// Interface for expression evaluation
interface ExpressionEvaluator
{
    double Evaluate(string expression);// Method to evaluate expression
}
class PostfixEvaluator : ExpressionEvaluator
{
    private Stack<double> stack = new Stack<double>();

    public double Evaluate(string expression)
    {
        string[] tokens = expression.Split(' ');// Split expression into tokens
        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double number))// If token is a number
            {
                stack.Push(number);
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();
                double result = ApplyOperator(a, b, token);// Apply operator
                stack.Push(result);
            }
        }
        return stack.Pop();
    }

    private double ApplyOperator(double a, double b, string op)
    {
       switch (op)
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
            case "*":
                return a * b;
            case "/":
                return a / b;
            default:
                 Console.WriteLine("Invalid operator");
                return 0;

               
        }
    }

}
public class PrefixEvaluator : ExpressionEvaluator// Prefix expression evaluator
{
    private Stack<double> stack = new Stack<double>();
    public double Evaluate(string expression)// Evaluate prefix expression
    {
        string[] tokens = expression.Split(' ');
        Array.Reverse(tokens);
        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double a = stack.Pop();
                double b = stack.Pop();
                double result = ApplyOperator(a, b, token);// Apply operator
                stack.Push(result);
            }
        }
        return stack.Pop();
    }
    private double ApplyOperator(double a, double b, string op)// Apply operator to two numbers
    {
        switch (op)
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
            case "*":
                return a * b;
            case "/":
                return a / b;
            default:
                 Console.WriteLine("Invalid operator");
                return 0;
        }
    }
}
