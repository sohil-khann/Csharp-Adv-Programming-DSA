/*
Problem 2: Read User Input and Write to File Using StreamReader
Problem: Write a program that reads user input from the console and writes it to a file.
*/
using System;
using System.IO;

namespace FileHandling
{
    public class UserInputToFile
    {
        public static void Run()
        {
            
            string filePath = "userInput.txt";

            Console.WriteLine("Enter some text to save to a file (press Enter to finish):");
            string input = Console.ReadLine();

            // Writing user input to a file using StreamWriter
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(input);
                }
                Console.WriteLine($"Successfully saved your input to '{filePath}'.");

                // Reading it back using StreamReader as per the problem hint
                Console.WriteLine("Reading back from the file:");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine($"File Content: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling file: {ex.Message}");
            }
          
            Console.WriteLine();
        }
    }
}
