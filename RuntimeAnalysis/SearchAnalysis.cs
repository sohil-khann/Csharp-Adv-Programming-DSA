/*
Problem 1: Search a Target in a Large Dataset
Objective: Compare the performance of Linear Search (O(N)) and Binary Search (O(log N)) on different dataset sizes.

Approach:
- Linear Search: Scan each element until the target is found.
- Binary Search: Sort the data first (O(N log N)), then perform O(log N) search.



Expected Result: Binary Search performs much better for large datasets, provided data is sorted.
*/

using System;
using System.Diagnostics;
using System.Linq;

namespace RuntimeAnalysis
{
    public class SearchAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("--- Problem 1: Search Performance (Linear vs Binary) ---");
            
            int[] sizes = { 1000, 10000, 1000000 };
            
            foreach (int n in sizes)
            {
                Console.WriteLine($"\nTesting with Dataset Size (N): {n:N0}");
                
                // Create a sorted array for fair comparison
                int[] data = Enumerable.Range(0, n).ToArray();
                int target = n - 1; // Search for the last element (worst case for Linear)

                // 1. Linear Search
                Stopwatch sw = Stopwatch.StartNew();
                LinearSearch(data, target);
                sw.Stop();
                double linearTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Linear Search: {linearTime:F4} ms");

                // 2. Binary Search
                sw.Restart();
                BinarySearch(data, target);
                sw.Stop();
                double binaryTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Binary Search: {binaryTime:F4} ms");
            }
            Console.WriteLine();
        }

        private static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target) return i;
            }
            return -1;
        }

        private static int BinarySearch(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == target) return mid;
                if (arr[mid] < target) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }
    }
}
