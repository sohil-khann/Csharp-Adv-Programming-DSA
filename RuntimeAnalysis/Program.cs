using System;

namespace RuntimeAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Problem 1: Search Analysis
            SearchAnalysis.Run();

            // Problem 2: Sorting Analysis
            SortingAnalysis.Run();

            // Problem 3: String Analysis
            StringAnalysis.Run();

            // Problem 4: File Reading Analysis
            FileReadingAnalysis.Run();

            // Problem 5: Fibonacci Analysis
            FibonacciAnalysis.Run();
            Console.ReadKey();
        }
    }
}
