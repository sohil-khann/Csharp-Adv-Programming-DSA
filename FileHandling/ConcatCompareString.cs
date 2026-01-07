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
    public void Call()
    {
        //takiing a large string for better benchmarking
        String s = "Data Structures are an important part of programming language." +
            " When we are creating solutions for real-world problems, choosing the right data structure" +
            " is critical because it can impact the performance of algorithms. If we know the fundamentals of " +
            "data structures and know how to use them effectively," +
            " then we can build the optimal solutions, and we can also create effective applications. In C#, data" +
            "" +
            " structures can be built using arrays, lists, stacks, queues, linked lists, trees, graphs, hash tables, and more" +
            ". C# provides built-in data structures through the System.Collections namespace.\r\n\r\nDataStructures\r\nIn this article, " +
            "we will discuss the Data Structures in C# Programming Language and their relationship with specific C# Data Types." +
            " We will discuss all the built-in data structures such as arrays, lists, dictionaries, and more. Additionally, " +
            "we will also cover some of the advanced data structures like trees, graphs, and others.\r\n\r\n1. " +
            "Linear Data Structure\r\nArray\r\nList\r\nLinkedList\r\nStack\r\nQueue\r\nPriorityQueue\r\nArrays\r\nIn C# arrays are" +
            " an important data structure which is used to store collection of elements of the same type. It is used to store the multiple " +
            "variables in a single variable as shown in the below example, we create a single variable arr and store multiple values in it." +
            " The elements in an array are stored in contiguous memory locations, and each element can be accessed using an index starting from 0. " +
            "For example, if we want to access the value of arr[2], we get the value 6 from the array shown in the below image.";

        string[] stringsToConcat = s.Split(' ');
        // Problem 1: Concatenate strings using StringBuilder
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        var sb = new System.Text.StringBuilder();
        foreach (var str in stringsToConcat)
        {
            sb.Append(str);
        }
        stopwatch.Stop();
        Console.WriteLine("Concatenated String: " + sb.ToString());
        Console.WriteLine("Time taken using StringBuilder: " + stopwatch.ElapsedMilliseconds + " ms");
        // Problem 2: Compare performance with regular string concatenation
        stopwatch.Restart();
        string regularConcat = "";
        foreach (var str in stringsToConcat)
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
