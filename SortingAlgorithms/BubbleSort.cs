/*1. Bubble Sort - Sort Student Marks
Problem Statement:
A school maintains student marks in an array. Implement Bubble Sort in C# to sort the
student marks in ascending order.
Hint:
 Traverse through the array multiple times.
 Compare adjacent elements and swap them if needed.
 Repeat the process until no swaps are required.*/
using System;
internal class BubbleSort
{
    public static void Call()
    {
        int[] studentMarks = { 85, 42, 78, 90, 56, 73, 88 };
        Console.WriteLine("Original Student Marks: " + string.Join(", ", studentMarks));
        BubbleSortArray(studentMarks);
        Console.WriteLine("Sorted Student Marks: " + string.Join(", ", studentMarks));
    }
    private static void BubbleSortArray(int[] marks)
    {
        int n = marks.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (marks[j] > marks[j + 1])
                {
                    // Swap marks[j] and marks[j + 1]
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                    swapped = true;
                }
            }
            // If no two elements were swapped in the inner loop, then break
            if (!swapped)
                break;
        }
    }

}