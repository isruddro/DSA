BF:


using System;
using System.Collections.Generic;

public class Node
{
    public int Data;
    public Node Next;

    // Constructor with both data and next node as parameters
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Solution
{
    // Function to detect loop in the linked list
    public static bool DetectLoop(Node head)
    {
        // Initialize a pointer 'temp' at the head of the linked list
        Node temp = head;

        // Create a dictionary to keep track of encountered nodes
        HashSet<Node> nodeSet = new HashSet<Node>();

        // Traverse the linked list
        while (temp != null)
        {
            // If the node is already in the dictionary, there is a loop
            if (nodeSet.Contains(temp))
            {
                return true;
            }

            // Store the current node in the dictionary
            nodeSet.Add(temp);

            // Move to the next node
            temp = temp.Next;
        }

        // If the list is successfully traversed without a loop, return false
        return false;
    }

    static void Main()
    {
        // Create a sample linked list with a loop for testing
        Node head = new Node(1);
        Node second = new Node(2);
        Node third = new Node(3);
        Node fourth = new Node(4);
        Node fifth = new Node(5);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = fifth;

        // Create a loop
        fifth.Next = third;

        // Check if there is a loop in the linked list
        if (DetectLoop(head))
        {
            Console.WriteLine("Loop detected in the linked list.");
        }
        else
        {
            Console.WriteLine("No loop detected in the linked list.");
        }

        // Clean up memory (not strictly necessary in C# due to garbage collection)
    }
}



Optimal:


using System;

public class Node
{
    public int Data;
    public Node Next;

    // Constructor with both data and next node as parameters
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Solution
{
    // Function to detect a cycle in the linked list using the Tortoise and Hare Algorithm
    public static bool DetectCycle(Node head)
    {
        // Initialize two pointers, slow and fast, to the head of the linked list
        Node slow = head;
        Node fast = head;

        // Traverse the linked list with the slow and fast pointers
        while (fast != null && fast.Next != null)
        {
            // Move slow one step
            slow = slow.Next;
            // Move fast two steps
            fast = fast.Next.Next;

            // Check if slow and fast pointers meet
            if (slow == fast)
            {
                return true;  // Loop detected
            }
        }

        // If fast reaches the end of the list, there is no loop
        return false;
    }

    static void Main()
    {
        // Create a sample linked list with a loop for testing
        Node head = new Node(1);
        Node second = new Node(2);
        Node third = new Node(3);
        Node fourth = new Node(4);
        Node fifth = new Node(5);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = fifth;

        // Create a loop
        fifth.Next = third;

        // Check if there is a loop in the linked list
        if (DetectCycle(head))
        {
            Console.WriteLine("Loop detected in the linked list.");
        }
        else
        {
            Console.WriteLine("No loop detected in the linked list.");
        }

        // In C#, memory management is handled by garbage collection,
        // so manual delete is not necessary.
    }
}
