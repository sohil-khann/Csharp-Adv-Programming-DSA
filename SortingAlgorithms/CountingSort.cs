/*7. Counting Sort - Sort Student Ages
Problem Statement:
A school collects students’ ages (ranging from 10 to 18) and wants them sorted. Implement
Counting Sort in C# for this task.
Hint:
 Create a count array to store the frequency of each age.
 Compute cumulative frequencies to determine positions.
 Place elements in their correct positions in the output array.*/
using System;
internal static class  CountingSort
{
    internal static void Call()
    {
        int[] studentAges = { 15, 12, 14, 13, 15, 16, 12, 18, 11, 14, 13, 17,-5 };
        int maxAge = 18;
        int minAge = 10;
        int range = maxAge - minAge + 1;
        int n = studentAges.Length;
        int[] output = new int[n];
        int[] count = new int[range];
        // Store count of each age
        for (int i = 0; i < n; i++)
            count[studentAges[i] - minAge]++;
        // Change count[i] so that it now contains actual
        // position of this age in output array
        for (int i = 1; i < count.Length; i++)
            count[i] += count[i - 1];
        // Build the output array
        for (int i = n - 1; i >= 0; i--)
        {
            output[count[studentAges[i] - minAge] - 1] = studentAges[i];
            count[studentAges[i] - minAge]--;
        }
        // Copy the output array to studentAges,
        // so that studentAges now contains sorted ages
        for (int i = 0; i < n; i++)
            studentAges[i] = output[i];
        // Print sorted array
        for (int i = 0; i < n; i++)
            Console.Write(studentAges[i] + " ");
        Console.WriteLine();
    }

}