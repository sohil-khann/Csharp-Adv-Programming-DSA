/*
Problem 4: Large File Reading Efficiency
Objective: Compare StreamReader and FileStream when reading a file.

Approach:
- StreamReader: Reads character by character (convenient for text).
- FileStream: Reads bytes (more direct, often faster for raw access).

Expected Result: FileStream is generally more efficient for large files when handling raw bytes. 
StreamReader is preferable for text-based data due to encoding handling.
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RuntimeAnalysis
{
    public class FileReadingAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("--- Problem 4: File Reading (StreamReader vs FileStream) ---");

            string testFile = "large_test_file.txt";
            CreateDummyFile(testFile, 10); // Create a 10MB file for testing

            Console.WriteLine($"Testing with a 10MB file...");

            // 1. Using StreamReader
            Stopwatch sw = Stopwatch.StartNew();
            ReadWithStreamReader(testFile);
            sw.Stop();
            Console.WriteLine($"StreamReader: {sw.Elapsed.TotalMilliseconds:F2} ms");

            // 2. Using FileStream
            sw.Restart();
            ReadWithFileStream(testFile);
            sw.Stop();
            Console.WriteLine($"FileStream  : {sw.Elapsed.TotalMilliseconds:F2} ms");

            // Clean up
            if (File.Exists(testFile)) File.Delete(testFile);
            Console.WriteLine();
        }

        private static void CreateDummyFile(string path, int sizeInMB)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                byte[] data = Encoding.UTF8.GetBytes("This is some dummy text to fill the file. ");
                long totalBytes = sizeInMB * 1024 * 1024;
                for (long i = 0; i < totalBytes; i += data.Length)
                {
                    fs.Write(data, 0, (int)Math.Min(data.Length, totalBytes - i));
                }
            }
        }

        private static void ReadWithStreamReader(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.ReadLine() != null) { /* Just read */ }
            }
        }

        private static void ReadWithFileStream(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];
                while (fs.Read(buffer, 0, buffer.Length) > 0) { /* Just read */ }
            }
        }
    }
}
