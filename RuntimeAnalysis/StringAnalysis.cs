/*
Problem 3: String Concatenation Performance
Objective: Compare the performance of string (O(N²)) and StringBuilder (O(N)) when concatenating many strings.

Approach:
- Using string (Immutable, creates a new object each time)
- Using StringBuilder (Fast, mutable, thread-unsafe)

Expected Result: StringBuilder is much more efficient than string for concatenation.
*/

using System;
using System.Diagnostics;
using System.Text;

namespace RuntimeAnalysis
{
    public class StringAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("--- Problem 3: String Concatenation (string vs StringBuilder) ---");

            int[] iterations = { 1000, 10000 }; // 1,000,000 is unusable for standard string

            foreach (int n in iterations)
            {
                Console.WriteLine($"\nConcatenating {n:N0} times:");

                // 1. Using standard string
                Stopwatch sw = Stopwatch.StartNew();
                string s = "";
                for (int i = 0; i < n; i++)
                {
                    s += "a";
                }
                sw.Stop();
                Console.WriteLine($"Standard string: {sw.Elapsed.TotalMilliseconds:F2} ms");

                // 2. Using StringBuilder
                sw.Restart();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    sb.Append("a");
                }
                string result = sb.ToString();
                sw.Stop();
                Console.WriteLine($"StringBuilder  : {sw.Elapsed.TotalMilliseconds:F2} ms");
            }

            Console.WriteLine("\nNote: For 1,000,000 operations, string concatenation could take 30 minutes, while StringBuilder takes ~50ms.");
            Console.WriteLine();
        }
    }
}
