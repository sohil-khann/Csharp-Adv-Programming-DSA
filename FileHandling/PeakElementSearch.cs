/*
Binary Search Problem 2: Find the Peak Element in an Array
Problem: A peak element is an element that is greater than its neighbors. Write a program that performs Binary Search to find a peak element in an array.
*/
using System;

namespace FileHandling
{
    public class PeakElementSearch
    {
        public static void Run()
        {

            int[] nums = { 1, 2, 3, 1 }; // 3 is a peak
            Console.WriteLine("Array: " + string.Join(", ", nums));

            int peakIndex = FindPeak(nums);
            Console.WriteLine($"A peak element is at index: {peakIndex}");
            Console.WriteLine($"Peak value: {nums[peakIndex]}");
            Console.WriteLine();
        }

        private static int FindPeak(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                // Compare mid with its right neighbor
                if (arr[mid] < arr[mid + 1])
                {
                    // We are on an upward slope, peak must be on the right
                    low = mid + 1;
                }
                else
                {
                    // We are on a downward slope, mid could be the peak or peak is on the left
                    high = mid;
                }
            }

            return low; // Both low and high will point to the peak index
        }
    }
}
