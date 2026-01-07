/*
Challenge Problem (for both Linear and Binary Search)
Problem: You are given a list of integers. Write a program that uses Linear Search to find the first missing positive integer in the list and Binary Search to find the index of a given target number.

Approach:
1. Linear Search for the first missing positive integer:
   - Iterate through the list and mark each number in the list as visited (you can use negative marking or a separate array).
   - Traverse the array again to find the first positive integer that is not marked.
2. Binary Search for the target index:
   - After sorting the array, perform binary search to find the index of the given target number.
   - Return the index if found, otherwise return -1.
*/
using System;

namespace FileHandling
{
    public static class MissingPositiveAndTargetSearch
    {
        public static void Run()
        {

            int[] nums = { 3, 4, -1, 1 };
            int target = 4;
            Console.WriteLine("Original Array: " + string.Join(", ", nums));

            // 1. Find first missing positive using Linear Search logic
            int missing = FindFirstMissingPositive(nums);
            Console.WriteLine($"1. The first missing positive integer is: {missing}");

            // 2. Find target index using Binary Search (requires sorting)
            int[] sortedNums = (int[])nums.Clone();
            Array.Sort(sortedNums);
            Console.WriteLine("Sorted Array for Binary Search: " + string.Join(", ", sortedNums));
            
            int index = BinarySearch(sortedNums, target);
            Console.WriteLine($"2. Index of target '{target}' in sorted array is: {index}");
            Console.WriteLine();
        }

        private static int FindFirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            // Mark numbers as visited by placing them in their correct positions (1 at index 0, 2 at index 1, etc.)
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    // Swap nums[i] and nums[nums[i] - 1]
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }

            // After rearranging, find the first index where the number doesn't match
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

        private static int BinarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == target)
                    return mid;
                
                if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
