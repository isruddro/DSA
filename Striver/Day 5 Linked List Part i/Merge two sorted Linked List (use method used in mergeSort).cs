BF:


using System;
using System.Collections.Generic;

class Node
{
    public int Data;  // Data stored in the node
    public Node Next; // Pointer to the next node in the list

    // Constructor with both data and next node as parameters
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Program
{
    // Function to convert a list to a linked list
    public static Node ConvertArrToLinkedList(List<int> arr)
    {
        // Create a dummy node to serve as the head of the linked list
        Node dummyNode = new Node(-1);
        Node temp = dummyNode;

        // Iterate through the list and create nodes with list elements
        foreach (int value in arr)
        {
            // Create a new node with the list element
            temp.Next = new Node(value);
            // Move the temporary pointer to the newly created node
            temp = temp.Next;
        }

        // Return the linked list starting from the next of the dummy node
        return dummyNode.Next;
    }

    // Function to merge two sorted linked lists
    public static Node SortTwoLinkedLists(Node list1, Node list2)
    {
        List<int> arr = new List<int>();
        Node temp1 = list1;
        Node temp2 = list2;

        // Storing elements of both lists into the list

        // Add elements from list1 to the list
        while (temp1 != null)
        {
            arr.Add(temp1.Data);
            temp1 = temp1.Next;
        }

        // Add elements from list2 to the list
        while (temp2 != null)
        {
            arr.Add(temp2.Data);
            temp2 = temp2.Next;
        }

        // Sorting the list in ascending order
        arr.Sort();

        // Converting the sorted list back to a linked list
        return ConvertArrToLinkedList(arr);
    }

    // Function to print the linked list
    public static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            // Print the data of the current node
            Console.Write(temp.Data + " ");
            // Move to the next node
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Example Linked Lists
        Node list1 = new Node(1);
        list1.Next = new Node(3);
        list1.Next.Next = new Node(5);

        Node list2 = new Node(2);
        list2.Next = new Node(4);
        list2.Next.Next = new Node(6);

        Console.WriteLine("First sorted linked list: ");
        PrintLinkedList(list1);

        Console.WriteLine("Second sorted linked list: ");
        PrintLinkedList(list2);

        Node mergedList = SortTwoLinkedLists(list1, list2);

        Console.WriteLine("Merged sorted linked list: ");
        PrintLinkedList(mergedList);
    }
}



Optimal:


using System;

class Node
{
    public int Data;  // Data stored in the node
    public Node Next; // Pointer to the next node in the list

    // Constructor with both data and next node as parameters
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Program
{
    // Function to merge two sorted linked lists
    public static Node SortTwoLinkedLists(Node list1, Node list2)
    {
        // Create a dummy node to serve as the head of the merged list
        Node dummyNode = new Node(-1);
        Node temp = dummyNode;

        // Traverse both lists simultaneously
        while (list1 != null && list2 != null)
        {
            // Compare elements of both lists and
            // link the smaller node to the merged list
            if (list1.Data <= list2.Data)
            {
                temp.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                temp.Next = list2;
                list2 = list2.Next;
            }
            // Move the temporary pointer to the next node
            temp = temp.Next;
        }

        // If any list still has remaining elements, append them to the merged list
        if (list1 != null)
        {
            temp.Next = list1;
        }
        else
        {
            temp.Next = list2;
        }

        // Return the merged list starting from the next of the dummy node
        return dummyNode.Next;
    }

    // Function to print the linked list
    public static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            // Print the data of the current node
            Console.Write(temp.Data + " ");
            // Move to the next node
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Example Linked Lists
        Node list1 = new Node(1);
        list1.Next = new Node(3);
        list1.Next.Next = new Node(5);

        Node list2 = new Node(2);
        list2.Next = new Node(4);
        list2.Next.Next = new Node(6);

        Console.WriteLine("First sorted linked list: ");
        PrintLinkedList(list1);

        Console.WriteLine("Second sorted linked list: ");
        PrintLinkedList(list2);

        Node mergedList = SortTwoLinkedLists(list1, list2);

        Console.WriteLine("Merged sorted linked list: ");
        PrintLinkedList(mergedList);
    }
}
