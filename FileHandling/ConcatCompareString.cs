/*Problem 1: Concatenate Strings Efficiently Using StringBuilder
Problem: You are given an array of strings. Write a program that uses StringBuilder to
concatenate all the strings in the array efficiently.


Problem 2: Compare StringBuilder Performance
Problem: Write a program that compares the performance of StringBuilder for
concatenating strings multiple times.*/
using System;
using System.Diagnostics;
internal class ConcatCompareString
{
    public void Call(int num)
    {
       

        string str = "Sohil";
        // Problem 1: Concatenate strings using StringBuilder
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        var sb = new System.Text.StringBuilder();
        for(int i=0;i<num;i++ )
        {
            sb.Append(str);
        }
        stopwatch.Stop();
        Console.WriteLine("Concatenated String: " + sb.ToString());
        Console.WriteLine("Time taken using StringBuilder: " + stopwatch.ElapsedMilliseconds + " ms");
        // Problem 2: Compare performance with regular string concatenation
        stopwatch.Restart();
        string regularConcat = "";
        for (int j = 0; j < num; j++)
        {
            regularConcat += str;
        }
        stopwatch.Stop();
        Console.WriteLine("Concatenated String using regular concatenation: " + regularConcat);
        Console.WriteLine("Time taken using regular concatenation: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}

/*Timing and Benchmarking Classes
System.Diagnostics.Stopwatch: A high-resolution timer designed to measure elapsed time for performance profiling.
StartNew(): A static method that creates a new Stopwatch instance and starts it immediately.
Restart(): Stops the current interval measurement, resets the elapsed time to zero, and starts it again.
Stop(): Pauses the measurement.
ElapsedMilliseconds: A property that returns the total elapsed time measured by the current instance in whole milliseconds. */
