BF:


using System;
using System.Collections.Generic;

class Node
{
    public int Data;
    public Node Next;

    // Constructor for Node with data and next node
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Program
{
    // Function to print the linked list
    public static void PrintLL(Node head)
    {
        while (head != null)
        {
            Console.Write(head.Data + " ");
            head = head.Next;
        }
        Console.WriteLine();
    }

    // Function to delete the Nth node from the end of the linked list
    public static Node DeleteNthNodefromEnd(Node head, int N)
    {
        if (head == null)
        {
            return null;
        }

        int cnt = 0;
        Node temp = head;

        // Count the number of nodes in the linked list
        while (temp != null)
        {
            cnt++;
            temp = temp.Next;
        }

        // If N equals the total number of nodes, delete the head
        if (cnt == N)
        {
            Node newHead = head.Next;
            head = null; // Delete the head
            return newHead;
        }

        // Calculate the position of the node to delete (res)
        int res = cnt - N;
        temp = head;

        // Traverse to the node just before the one to delete
        while (temp != null)
        {
            res--;
            if (res == 0)
            {
                break;
            }
            temp = temp.Next;
        }

        // Delete the Nth node from the end
        if (temp != null && temp.Next != null)
        {
            Node delNode = temp.Next;
            temp.Next = temp.Next.Next;
            delNode = null; // Delete the node
        }

        return head;
    }

    static void Main()
    {
        List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
        int N = 3;
        Node head = new Node(arr[0]);
        head.Next = new Node(arr[1]);
        head.Next.Next = new Node(arr[2]);
        head.Next.Next.Next = new Node(arr[3]);
        head.Next.Next.Next.Next = new Node(arr[4]);

        // Delete the Nth node from the end
        // and print the modified linked list
        head = DeleteNthNodefromEnd(head, N);
        PrintLL(head);
    }
}



Optimal:


using System;
using System.Collections.Generic;

class Node
{
    public int Data;
    public Node Next;

    // Constructor with data and next node
    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
}

class Program
{
    // Function to print the linked list
    public static void PrintLL(Node head)
    {
        while (head != null)
        {
            Console.Write(head.Data + " ");
            head = head.Next;
        }
        Console.WriteLine();
    }

    // Function to delete the Nth node from the end of the linked list
    public static Node DeleteNthNodefromEnd(Node head, int N)
    {
        // Create two pointers, fastp and slowp
        Node fastp = head;
        Node slowp = head;

        // Move the fastp pointer N nodes ahead
        for (int i = 0; i < N; i++)
        {
            if (fastp != null)
            {
                fastp = fastp.Next;
            }
            else
            {
                return head; // If N is greater than the length of the list, return the original list
            }
        }

        // If fastp is null, the Nth node from the end is the head
        if (fastp == null)
        {
            return head.Next;
        }

        // Move both pointers until fastp reaches the end
        while (fastp.Next != null)
        {
            fastp = fastp.Next;
            slowp = slowp.Next;
        }

        // Delete the Nth node from the end
        Node delNode = slowp.Next;
        slowp.Next = slowp.Next.Next;
        delNode = null; // Delete the node by clearing the reference

        return head;
    }

    static void Main()
    {
        List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
        int N = 3;
        Node head = new Node(arr[0]);
        head.Next = new Node(arr[1]);
        head.Next.Next = new Node(arr[2]);
        head.Next.Next.Next = new Node(arr[3]);
        head.Next.Next.Next.Next = new Node(arr[4]);

        // Delete the Nth node from the end
        // and print the modified linked list
        head = DeleteNthNodefromEnd(head, N);
        PrintLL(head);
    }
}
