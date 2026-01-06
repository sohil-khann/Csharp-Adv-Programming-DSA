/*. Selection Sort - Sort Exam Scores
Problem Statement:
A university needs to sort students’ exam scores in ascending order. Implement Selection
Sort in C# to achieve this.
Hint:
 Find the minimum element in the array.
 Swap it with the first unsorted element.
 Repeat the process for the remaining elements.*/using System;internal static class SelectionSort{    internal static void Call()    {        int[] examScores = { 85, 42, 96, 73, 58, 91, 67,-10 };        int n = examScores.Length;        // One by one move boundary of unsorted subarray        for (int i = 0; i < n - 1; i++)        {            // Find the minimum element in unsorted array            int minIdx = i;            for (int j = i + 1; j < n; j++)                if (examScores[j] < examScores[minIdx])                    minIdx = j;            // Swap the found minimum element with the first element            int temp = examScores[minIdx];            examScores[minIdx] = examScores[i];            examScores[i] = temp;        }        // Print sorted array        for (int i = 0; i < n; i++)            Console.Write(examScores[i] + " ");        Console.WriteLine();    }}