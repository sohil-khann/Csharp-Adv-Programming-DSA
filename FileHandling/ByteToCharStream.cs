/* 
Problem 1: Convert Byte Stream to Character Stream Using StreamReader
Problem: Write a program that uses StreamReader to read binary data from a file and print it as characters.
*/
using System;
using System.IO;
using System.Text;

namespace FileHandling
{
    public class ByteToCharStream
    {
        public static void Run()
        {
            
            string filePath = "byteData.bin";
            string content = "Hello, this is binary data being read as characters!";
            
            // First, let's create a binary file (byte stream)
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            File.WriteAllBytes(filePath, bytes);
            Console.WriteLine("Binary file created with some data.");

            // Now, use StreamReader to read the byte stream as characters
            try
            {
                // Open the file using a FileStream (byte stream)
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Wrap the FileStream in a StreamReader to convert bytes to characters
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        Console.WriteLine("Reading data from StreamReader:");
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
            Console.WriteLine();
        }
    }
}
