/*
Problem 2: Sorting Large Data Efficiently
Objective: Compare sorting algorithms Bubble Sort (O(N²)), Merge Sort (O(N log N)), and Quick Sort (O(N log N)).

Approach:
- Bubble Sort: Repeated swapping (inefficient for large data).
- Merge Sort: Divide & Conquer approach (stable).
- Quick Sort: Partition-based approach (fast but unstable).

Expected Result: Bubble Sort is impractical for large datasets. Merge Sort & Quick Sort perform well.
*/

using System;
using System.Diagnostics;

namespace RuntimeAnalysis
{
    public class SortingAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("--- Problem 2: Sorting Performance ---");

            int[] sizes = { 1000, 10000 }; // We avoid 1,000,000 for Bubble Sort as it's unfeasible

            foreach (int n in sizes)
            {
                Console.WriteLine($"\nTesting with Dataset Size (N): {n:N0}");

                int[] original = GenerateRandomArray(n);

                // 1. Bubble Sort
                int[] data1 = (int[])original.Clone();
                Stopwatch sw = Stopwatch.StartNew();
                BubbleSort(data1);
                sw.Stop();
                Console.WriteLine($"Bubble Sort: {sw.Elapsed.TotalMilliseconds:F2} ms");

                // 2. Merge Sort
                int[] data2 = (int[])original.Clone();
                sw.Restart();
                MergeSort(data2, 0, data2.Length - 1);
                sw.Stop();
                Console.WriteLine($"Merge Sort : {sw.Elapsed.TotalMilliseconds:F2} ms");

                // 3. Quick Sort
                int[] data3 = (int[])original.Clone();
                sw.Restart();
                QuickSort(data3, 0, data3.Length - 1);
                sw.Stop();
                Console.WriteLine($"Quick Sort : {sw.Elapsed.TotalMilliseconds:F2} ms");
            }
            Console.WriteLine("\nNote: For N=1,000,000, Bubble Sort would take over an hour, while Merge/Quick Sort take a few seconds.");
            Console.WriteLine();
        }

        private static int[] GenerateRandomArray(int n)
        {
            Random rand = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = rand.Next(0, n * 10);
            return arr;
        }

        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];
            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) arr[k++] = L[i++];
                else arr[k++] = R[j++];
            }
            while (i < n1) arr[k++] = L[i++];
            while (j < n2) arr[k++] = R[j++];
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            return i + 1;
        }
    }
}
