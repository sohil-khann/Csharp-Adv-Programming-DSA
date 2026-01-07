/*1. StringBuilder Problem 1: 
 * 
 Reverse a String Using StringBuilder
Problem: Write a program that uses StringBuilder to reverse a given string. For example, if
the input is "hello", the output should be "olleh".



StringBuilder Problem 2:
Remove Duplicates from a String Using StringBuilder
Problem: Write a program that uses StringBuilder to remove all duplicate characters from a
given string while maintaining the original order.*/
using System.Text;
using System;
// Define an interface for string manipulation
interface IStringManipulation{    string ReverseString(string input);    string RemoveDuplicates(string input);}// Implement the interface in a classpublic class StringManipulation : IStringManipulation{    public string ReverseString(string input)    {
        // Using StringBuilder to reverse the string
        StringBuilder sb = new StringBuilder(input);        int left = 0;        int right = sb.Length - 1;

        // Swap characters from both ends
        while (left < right)        {            char temp = sb[left];            sb[left] = sb[right];            sb[right] = temp;            left++;            right--;        }        return sb.ToString();// Return the reversed string
    }
    
    public string RemoveDuplicates(string input)    {// Using StringBuilder to remove duplicates
        StringBuilder sb = new StringBuilder();        foreach (char c in input)        {            if (sb.ToString().IndexOf(c) == -1)            {                sb.Append(c);// Append only if character is not already present
            }        }        return sb.ToString();// Return the string without duplicates

    }}