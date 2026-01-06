/*3. Merge Sort - Sort an Array of Book Prices
Problem Statement:
A bookstore maintains a list of book prices in an array. Implement Merge Sort in C# to sort
the prices in ascending order.
Hint:
Divide the array into two halves recursively.
 Sort both halves individually.
 Merge the sorted halves by comparing elements*/

using System;
using System.Linq;
internal static class MergeSort
{
    internal static void Call()
    {
        int[] bookPrice = {111, 225, 1025, 221, 1025, 55, 259, 654,-25};
        
        mergeSort(bookPrice, 0, bookPrice.Length - 1);
        int n = bookPrice.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(bookPrice[i] + " ");
        Console.WriteLine(); 
    
    }
        // Merges two subarrays of arr[].
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        static void merge(int[] arr, int l, int m, int r)
        {

            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using merge()
        static void mergeSort(int[] arr, int l, int r)
        {

            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

    }
