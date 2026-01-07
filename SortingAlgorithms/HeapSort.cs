/*6. Heap Sort - Sort Job Applicants by Salary
Problem Statement:
A company receives job applications with different expected salary demands. Implement
Heap Sort in C# to sort these salary demands in ascending order.
Hint:
 Build a Max Heap from the array.
 Extract the largest element (root) and place it at the end.
 Reheapify the remaining elements and repeat until sorted.*/

using System;
internal static class HeapSort
{
    internal static void Call()
    {
        int[] salaryDemands = { 60000, 45000, 75000, 50000, 90000, 30000, 80000,-5000 };
        int n = salaryDemands.Length;
        // Build heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(salaryDemands, n, i);
        // One by one extract an element from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = salaryDemands[0];
            salaryDemands[0] = salaryDemands[i];
            salaryDemands[i] = temp;
            // call max heapify on the reduced heap
            heapify(salaryDemands, i, 0);
        }
        // Print sorted array
        for (int i = 0; i < n; i++)
            Console.Write(salaryDemands[i] + " ");
        Console.WriteLine();
    }
    
    static void heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // left = 2*i + 1
        int right = 2 * i + 2; // right = 2*i + 2
        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;
        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;
        // If largest is not root
        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;
            heapify(arr, n, largest);
        }
    }
}
