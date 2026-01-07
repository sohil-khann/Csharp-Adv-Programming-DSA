/*
Problem 5: Recursive vs Iterative Fibonacci Computation
Objective: Compare Recursive (O(2^N)) vs Iterative (O(N)) Fibonacci solutions.

Approach:
- Recursive: Classic double recursion.
- Iterative: Loop-based calculation.

Expected Result: Recursive approach is infeasible for large values of N due to exponential growth. 
The iterative approach is significantly faster and memory-efficient.
*/

using System;
using System.Diagnostics;

namespace RuntimeAnalysis
{
    public class FibonacciAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("--- Problem 5: Fibonacci (Recursive vs Iterative) ---");

            int[] testValues = { 10, 30, 40 }; // 50 is unfeasible for recursion

            foreach (int n in testValues)
            {
                Console.WriteLine($"\nCalculating Fibonacci({n}):");

                // 1. Iterative
                Stopwatch sw = Stopwatch.StartNew();
                long iterativeResult = FibonacciIterative(n);
                sw.Stop();
                Console.WriteLine($"Iterative (O(N)) : Result={iterativeResult}, Time={sw.Elapsed.TotalMilliseconds:F4} ms");

                // 2. Recursive
                sw.Restart();
                long recursiveResult = FibonacciRecursive(n);
                sw.Stop();
                Console.WriteLine($"Recursive (O(2^N)): Result={recursiveResult}, Time={sw.Elapsed.TotalMilliseconds:F4} ms");
            }

            Console.WriteLine("\nNote: For N=50, the recursive approach would take over an hour, while iterative takes < 0.1ms.");
            Console.WriteLine();
        }

        public static long FibonacciRecursive(int n)
        {
            if (n <= 1) return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        public static long FibonacciIterative(int n)
        {
            if (n <= 1) return n;
            long a = 0, b = 1, sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }
    }
}
