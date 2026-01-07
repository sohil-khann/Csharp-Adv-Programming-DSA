/*
Linear Search Problem 1: Search for the First Negative Number
Problem: You are given an integer array. Write a program that performs Linear Search to find the first negative number in the array.
*/
using System;

namespace FileHandling
{
    public class FirstNegativeSearch
    {
        public static void Run()
        {
            int[] numbers = { 10, 5, 8, -3, 12, -7, 0 };
            Console.WriteLine("Array elements: " + string.Join(", ", numbers));

            int result = FindFirstNegative(numbers);

            if (result != int.MaxValue)
            {
                Console.WriteLine($"The first negative number is: {result}");
            }
            else
            {
                Console.WriteLine("No negative number found in the array.");
            }
            Console.WriteLine();
        }

        private static int FindFirstNegative(int[] arr)
        {
            // Simple linear search through the array
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    return arr[i]; // Return the first negative value found
                }
            }
            return int.MaxValue; // Indicator that no negative number was found
        }
    }
}
