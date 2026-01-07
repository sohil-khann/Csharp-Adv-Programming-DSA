/*
Linear Search Problem 2: Search for a Specific Word in a List of Sentences
Problem: You are given an array of sentences. Write a program that performs Linear Search to find the first sentence containing a specific word.
*/
using System;

namespace FileHandling
{
    public class WordSearchInSentences
    {
        public static void Run()
        {
            string[] sentences = {
                "The quick brown fox jumps over the lazy dog.",
                "C# is a powerful programming language.",
                "Data structures and algorithms are essential.",
                "Learning to code is fun and rewarding."
            };

            string targetWord = "essential";
            Console.WriteLine($"Target word: '{targetWord}'");

            string foundSentence = SearchWord(sentences, targetWord);

            if (foundSentence != null)
            {
                Console.WriteLine("Sentence found:");
                Console.WriteLine(foundSentence);
            }
            else
            {
                Console.WriteLine($"The word '{targetWord}' was not found in any sentence.");
            }
            Console.WriteLine();
        }

        private static string SearchWord(string[] list, string word)
        {
            // Iterate through each sentence in the array
            for (int i = 0; i < list.Length; i++)
            {
                // Check if the current sentence contains the word (case-insensitive for better results)
                if (list[i].Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    return list[i]; // Return the first matching sentence
                }
            }
            return null; // Return null if no sentence contains the word
        }
    }
}
