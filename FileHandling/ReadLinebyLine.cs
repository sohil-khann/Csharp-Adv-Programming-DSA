/*Problem 1: Read a File Line by Line Using StreamReader
Problem: Write a program that uses StreamReader to read a text file line by line and print
each line to the console.*/
using System;
using System.IO;
internal class ReadLinebyLine
{
    public void Call()
    {
        try
        {
            using (StreamReader sr = new StreamReader("sample.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                { // Read
                Console.WriteLine(line);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }


    }
}