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
    // Function to check if the linked list is a palindrome
    public static bool IsPalindrome(Node head)
    {
        // Create an empty stack to store values
        Stack<int> stack = new Stack<int>();

        // Initialize a temporary pointer to the head of the linked list
        Node temp = head;

        // Traverse the linked list and push values onto the stack
        while (temp != null)
        {
            stack.Push(temp.Data);
            temp = temp.Next;
        }

        // Reset the temporary pointer back to the head of the linked list
        temp = head;

        // Compare values by popping from the stack and checking against linked list nodes
        while (temp != null)
        {
            if (temp.Data != stack.Pop())
            {
                // If values don't match, it's not a palindrome
                return false;
            }

            // Move to the next node in the linked list
            temp = temp.Next;
        }

        // If all values match, it's a palindrome
        return true;
    }

    // Function to print the linked list
    public static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        // Create a linked list with values 1, 5, 2, 5, and 1 (15251, a palindrome)
        Node head = new Node(1);
        head.Next = new Node(5);
        head.Next.Next = new Node(2);
        head.Next.Next.Next = new Node(5);
        head.Next.Next.Next.Next = new Node(1);

        // Print the original linked list
        Console.WriteLine("Original Linked List:");
        PrintLinkedList(head);

        // Check if the linked list is a palindrome
        if (IsPalindrome(head))
        {
            Console.WriteLine("The linked list is a palindrome.");
        }
        else
        {
            Console.WriteLine("The linked list is not a palindrome.");
        }
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
    // Function to reverse a linked list using recursion
    public static Node ReverseLinkedList(Node head)
    {
        // Check if the list is empty or has only one node
        if (head == null || head.Next == null)
        {
            // No change is needed; return the current head
            return head;
        }

        // Recursive step: Reverse the remaining part of the list
        Node newHead = ReverseLinkedList(head.Next);

        // Store the next node to reverse the link
        Node front = head.Next;

        // Update the next pointer of front to point to the current head
        front.Next = head;

        // Set the current head's next pointer to null
        head.Next = null;

        // Return the new head obtained from the recursion
        return newHead;
    }

    // Function to check if the linked list is a palindrome
    public static bool IsPalindrome(Node head)
    {
        // Check if the list is empty or has only one node
        if (head == null || head.Next == null)
        {
            // It's a palindrome by definition
            return true;
        }

        // Initialize two pointers, slow and fast, to find the middle of the list
        Node slow = head;
        Node fast = head;

        // Traverse the linked list to find the middle using slow and fast pointers
        while (fast.Next != null && fast.Next.Next != null)
        {
            // Move slow pointer one step at a time
            slow = slow.Next;

            // Move fast pointer two steps at a time
            fast = fast.Next.Next;
        }

        // Reverse the second half of the linked list starting from the middle
        Node newHead = ReverseLinkedList(slow.Next);

        // Pointer to the first half
        Node first = head;

        // Pointer to the reversed second half
        Node second = newHead;

        // Compare the two halves
        while (second != null)
        {
            // If values do not match, the list is not a palindrome
            if (first.Data != second.Data)
            {
                // Reverse the second half back to its original state
                ReverseLinkedList(newHead);

                // Not a palindrome
                return false;
            }

            // Move the first pointer
            first = first.Next;

            // Move the second pointer
            second = second.Next;
        }

        // Reverse the second half back to its original state
        ReverseLinkedList(newHead);

        // The linked list is a palindrome
        return true;
    }

    // Function to print the linked list
    public static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        // Create a linked list with values 1, 5, 2, 5, and 1 (15251, a palindrome)
        Node head = new Node(1);
        head.Next = new Node(5);
        head.Next.Next = new Node(2);
        head.Next.Next.Next = new Node(5);
        head.Next.Next.Next.Next = new Node(1);

        // Print the original linked list
        Console.WriteLine("Original Linked List:");
        PrintLinkedList(head);

        // Check if the linked list is a palindrome
        if (IsPalindrome(head))
        {
            Console.WriteLine("The linked list is a palindrome.");
        }
        else
        {
            Console.WriteLine("The linked list is not a palindrome.");
        }
    }
}
