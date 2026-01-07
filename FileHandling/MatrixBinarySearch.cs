/*
Binary Search Problem 3: Search for a Target Value in a 2D Sorted Matrix
Problem: You are given a 2D matrix where each row is sorted in ascending order. Write a program that performs Binary Search to find a target value in the matrix.
*/
using System;

namespace FileHandling
{
    public class MatrixBinarySearch
    {
        public static void Run()
        {

            int[][] matrix = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            };

            int target = 3;
            Console.WriteLine("Matrix:");
            foreach (var row in matrix)
            {
                Console.WriteLine("  [" + string.Join(", ", row) + "]");
            }
            Console.WriteLine($"Searching for: {target}");

            bool found = SearchMatrix(matrix, target);
            Console.WriteLine(found ? "Target found in matrix." : "Target not found.");
            Console.WriteLine();
        }

        private static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            // We can treat the 2D matrix as a virtual 1D array
            int low = 0;
            int high = rows * cols - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                
                // Convert virtual 1D index back to 2D row and column
                int midValue = matrix[mid / cols][mid % cols];

                if (midValue == target)
                {
                    return true;
                }
                else if (midValue < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }
    }
}
