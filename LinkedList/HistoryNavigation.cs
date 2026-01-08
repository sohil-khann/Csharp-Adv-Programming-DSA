/*Scenario 1: Browser History Navigation
Use Case: Maintain a user�s browsing history with the ability to move back and forth.
Why LinkedList? Doubly linked list makes it easy to navigate both backward and forward.
OOP Concepts:
 Encapsulation: Browser history data is wrapped inside a class.
 Abstraction: Navigation methods hide internal implementation.
Inheritance & Polymorphism: Reusable navigation for other apps like music players.
*/
//without using collections
using System;
using System.Collections.Generic;
// BrowserHistory class to manage browsing history

public class BrowserHistory
{
    private class Node// Node class for doubly linked list
    {
        public string Url;
        public Node Prev;
        public Node Next;
        public Node(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }
    private Node current;
    public BrowserHistory(string homepage)// Constructor initializes the browser history with the homepage
    {
        current = new Node(homepage);
    }
    public void Visit(string url)
    {// Visit a new URL 
        
        Node newNode = new Node(url);
        current.Next = newNode;
        newNode.Prev = current;
        current = newNode;
    }
    public string Back(int steps)// Move back in history
    {
        while (steps > 0 && current.Prev != null)
        {
            current = current.Prev;
            steps--;
        }
        return current.Url;
    }
    public string Forward(int steps)// Move forward in history
    {
        while (steps > 0 && current.Next != null)
        {
            current = current.Next;
            steps--;
        }
        return current.Url;
    }
}
