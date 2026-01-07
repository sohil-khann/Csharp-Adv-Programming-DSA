/*
Binary Search Problem 4: Find the First and Last Occurrence of an Element in a Sorted Array
Problem: Given a sorted array and a target element, write a program that uses Binary Search to find the first and last occurrence of the target element in the array.
*/
using System;

namespace FileHandling
{
    public class FirstLastOccurrenceSearch
    {
        public static void Run()
        {

            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 8;
            Console.WriteLine("Array: " + string.Join(", ", nums));
            Console.WriteLine($"Target: {target}");

            int first = FindIndex(nums, target, true);
            int last = FindIndex(nums, target, false);

            if (first != -1)
            {
                Console.WriteLine($"First occurrence at index: {first}");
                Console.WriteLine($"Last occurrence at index: {last}");
            }
            else
            {
                Console.WriteLine("Target not found in array.");
            }
            Console.WriteLine();
        }

        private static int FindIndex(int[] arr, int target, bool findFirst)
        {
            int low = 0;
            int high = arr.Length - 1;
            int result = -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == target)
                {
                    result = mid; // Candidate found
                    if (findFirst)
                    {
                        high = mid - 1; // Keep looking left for first
                    }
                    else
                    {
                        low = mid + 1; // Keep looking right for last
                    }
                }
                else if (arr[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }
    }
}
