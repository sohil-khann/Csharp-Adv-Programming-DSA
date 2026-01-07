/*Problem 1: Read a File Line by Line Using StreamReader
Problem: Write a program that uses StreamReader to read a text file line by line and print
each line to the console.Problem 2: Count the Occurrence of a Word in a File Using StreamReader
Problem: Write a program that reads a file and counts how many times a specific word
appears in the file.*/
using System;
using System.IO;
using System.Threading;
internal class ReadLinebyLine
{//For problem 1
    public void Call()
    {//exception handling
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
    //for problem 2
    public void Call2()
    {
        try
        {
            using (StreamReader sr = new StreamReader("sample.txt"))
            {
                String filepath = "sample.txt";
                //int cnt = 0;
                //string line;
                string[] sp = ReadWordsFromFile("sample.txt");

                //while ((line = sr.ReadLine()) != null)
                //{ // Read
                //    if (line == " ") cnt++;
                //    //Console.WriteLine(line);
                //}
                Console.WriteLine(sp.Length-1);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static string[] ReadWordsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found.");
            return Array.Empty<string>();
        }

        // ReadAllText is generally the fastest for getting entire file content
        string content = File.ReadAllText(filePath);

        // Split using StringSplitOptions to handle multiple spaces/newlines
        return content.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    }

}