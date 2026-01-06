/*2. Insertion Sort - Sort Employee IDs
Problem Statement:
A company stores employee IDs in an unsorted array. Implement Insertion Sort in C# to sort
the employee IDs in ascending order.
Hint:
 Divide the array into sorted and unsorted parts.
 Pick an element from the unsorted part and insert it into its correct position in the
sorted part.
 Repeat for all elements*/
using System;
internal class InsertionSort
{
    public void Call()
            {
		// Example employee IDs
		int[] employeeIDs = { 105, 42, 78, 90, 56, 73, 88 };
		// Display original and sorted employee IDs
		Console.WriteLine("Original Employee IDs: " + string.Join(", ", employeeIDs));
        InsertionSortArray(employeeIDs);
        Console.WriteLine("Sorted Employee IDs: " + string.Join(", ", employeeIDs));
	}
    private void InsertionSortArray(int[] ids)
    {
        int n = ids.Length;
        for (int i = 1; i < n; i++)
        {
            int key = ids[i];
            int j = i - 1;
            // Move elements of ids[0..i-1], that are greater than key,
            // to one position ahead of their current position
            while (j >= 0 && ids[j] > key)
            {
                ids[j + 1] = ids[j];
                j = j - 1;
            }
            ids[j + 1] = key;
        }
	}

}