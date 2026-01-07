/*
Binary Search Problem 1: Find the Rotation Point in a Rotated Sorted Array
Problem: You are given a rotated sorted array. Write a program that performs Binary Search to find the index of the smallest element in the array.
*/
using System;

namespace FileHandling
{
    public class RotationPointSearch
    {
        public static void Run()
        {

            // A sorted array [1, 2, 3, 4, 5] rotated might look like this:
            int[] rotatedArray = { 4, 5, 1, 2, 3 };
            Console.WriteLine("Rotated Array: " + string.Join(", ", rotatedArray));

            int index = FindRotationPoint(rotatedArray);
            Console.WriteLine($"The rotation point (smallest element) is at index: {index}");
            Console.WriteLine($"Smallest value: {rotatedArray[index]}");
            Console.WriteLine();
        }

        private static int FindRotationPoint(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            // If the array is not rotated at all
            if (arr[low] <= arr[high]) return low;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // Check if mid+1 is the rotation point
                if (mid < high && arr[mid] > arr[mid + 1])
                {
                    return mid + 1;
                }

                // Check if mid is the rotation point
                if (mid > low && arr[mid] < arr[mid - 1])
                {
                    return mid;
                }

                // Decide which half to search next
                if (arr[mid] >= arr[low])
                {
                    // Smallest must be in the right half
                    low = mid + 1;
                }
                else
                {
                    // Smallest must be in the left half
                    high = mid - 1;
                }
            }

            return 0;
        }
    }
}
