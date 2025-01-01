BF:


using System;
using System.Collections.Generic;

public class Node
{
    public int Data;
    public Node Next;
    public Node Child;

    // Constructors to initialize the data, next, and child pointers
    public Node() 
    { 
        Data = 0; 
        Next = null; 
        Child = null; 
    }
    
    public Node(int x)
    {
        Data = x;
        Next = null;
        Child = null;
    }
    
    public Node(int x, Node nextNode, Node childNode)
    {
        Data = x;
        Next = nextNode;
        Child = childNode;
    }
}

class Solution
{
    // Function to convert a list to a linked list
    public static Node ConvertListToLinkedList(List<int> arr)
    {
        // Create a dummy node to serve as the head of the linked list
        Node dummyNode = new Node(-1);
        Node temp = dummyNode;

        // Iterate through the list and create nodes with list elements
        foreach (int num in arr)
        {
            temp.Child = new Node(num);  // Create a new node with the element
            temp = temp.Child;           // Move to the newly created node
        }

        // Return the linked list starting from the next of the dummy node
        return dummyNode.Child;
    }

    // Function to flatten a linked list with child pointers
    public static Node FlattenLinkedList(Node head)
    {
        List<int> arr = new List<int>();

        // Traverse through the linked list
        while (head != null)
        {
            // Traverse through the child nodes of each head node
            Node t2 = head;
            while (t2 != null)
            {
                // Store each node's data in the array
                arr.Add(t2.Data);
                t2 = t2.Child;  // Move to the next child node
            }

            head = head.Next;  // Move to the next head node
        }

        // Sort the array containing node values in ascending order
        arr.Sort();

        // Convert the sorted array back to a linked list
        return ConvertListToLinkedList(arr);
    }

    // Print the linked list by traversing through child pointers
    public static void PrintLinkedList(Node head)
    {
        while (head != null)
        {
            Console.Write(head.Data + " ");
            head = head.Child;
        }
        Console.WriteLine();
    }

    // Print the original linked list in a grid-like structure
    public static void PrintOriginalLinkedList(Node head, int depth)
    {
        while (head != null)
        {
            Console.Write(head.Data);

            // If child exists, recursively print it with indentation
            if (head.Child != null)
            {
                Console.Write(" -> ");
                PrintOriginalLinkedList(head.Child, depth + 1);
            }

            // Add vertical bars for each level in the grid
            if (head.Next != null)
            {
                Console.WriteLine();
                for (int i = 0; i < depth; i++)
                {
                    Console.Write("| ");
                }
            }

            head = head.Next;
        }
    }

    static void Main()
    {
        // Create a linked list with child pointers
        Node head = new Node(5);
        head.Child = new Node(14);

        head.Next = new Node(10);
        head.Next.Child = new Node(4);

        head.Next.Next = new Node(12);
        head.Next.Next.Child = new Node(20);
        head.Next.Next.Child.Child = new Node(13);

        head.Next.Next.Next = new Node(7);
        head.Next.Next.Next.Child = new Node(17);

        // Print the original linked list structure
        Console.WriteLine("Original linked list:");
        PrintOriginalLinkedList(head, 0);

        // Flatten the linked list and print the flattened list
        Node flattened = FlattenLinkedList(head);
        Console.WriteLine("\nFlattened linked list: ");
        PrintLinkedList(flattened);
    }
}





Optimal:


using System;

class Node
{
    public int data;
    public Node next;
    public Node child;

    // Constructors to initialize the data, next, and child pointers
    public Node()
    {
        data = 0;
        next = null;
        child = null;
    }

    public Node(int x)
    {
        data = x;
        next = null;
        child = null;
    }

    public Node(int x, Node nextNode, Node childNode)
    {
        data = x;
        next = nextNode;
        child = childNode;
    }
}

class LinkedList
{
    // Merges two linked lists based on their data values
    public static Node Merge(Node list1, Node list2)
    {
        // Create a dummy node as a placeholder for the result
        Node dummyNode = new Node(-1);
        Node res = dummyNode;

        // Merge the lists based on data values
        while (list1 != null && list2 != null)
        {
            if (list1.data < list2.data)
            {
                res.child = list1;
                res = list1;
                list1 = list1.child;
            }
            else
            {
                res.child = list2;
                res = list2;
                list2 = list2.child;
            }
            res.next = null;
        }

        // Connect the remaining elements if any
        if (list1 != null)
        {
            res.child = list1;
        }
        else
        {
            res.child = list2;
        }

        // Break the last node's link to prevent cycles
        if (dummyNode.child != null)
        {
            dummyNode.child.next = null;
        }

        return dummyNode.child;
    }

    // Flattens a linked list with child pointers
    public static Node FlattenLinkedList(Node head)
    {
        // If head is null or there is no next node, return head
        if (head == null || head.next == null)
        {
            return head;
        }

        // Recursively flatten the rest of the linked list
        Node mergedHead = FlattenLinkedList(head.next);
        head = Merge(head, mergedHead);
        return head;
    }

    // Print the linked list by traversing through child pointers
    public static void PrintLinkedList(Node head)
    {
        while (head != null)
        {
            Console.Write(head.data + " ");
            head = head.child;
        }
        Console.WriteLine();
    }

    // Print the linked list in a grid-like structure
    public static void PrintOriginalLinkedList(Node head, int depth)
    {
        while (head != null)
        {
            Console.Write(head.data);

            // If child exists, recursively print it with indentation
            if (head.child != null)
            {
                Console.Write(" -> ");
                PrintOriginalLinkedList(head.child, depth + 1);
            }

            // Add vertical bars for each level in the grid
            if (head.next != null)
            {
                Console.WriteLine();
                for (int i = 0; i < depth; ++i)
                {
                    Console.Write("| ");
                }
            }
            head = head.next;
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a linked list with child pointers
        Node head = new Node(5);
        head.child = new Node(14);

        head.next = new Node(10);
        head.next.child = new Node(4);

        head.next.next = new Node(12);
        head.next.next.child = new Node(20);
        head.next.next.child.child = new Node(13);

        head.next.next.next = new Node(7);
        head.next.next.next.child = new Node(17);

        // Print the original linked list structure
        Console.WriteLine("Original linked list:");
        LinkedList.PrintOriginalLinkedList(head, 0);

        // Flatten the linked list and print the flattened list
        Node flattened = LinkedList.FlattenLinkedList(head);
        Console.WriteLine("\nFlattened linked list: ");
        LinkedList.PrintLinkedList(flattened);
    }
}
