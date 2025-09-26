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
    // Function to detect a loop in the linked list and return the starting node of the loop
    public static Node DetectLoop(Node head)
    {
        // Use a dictionary to store all visited nodes
        Dictionary<Node, int> visitedNodes = new Dictionary<Node, int>();

        // Traverse the linked list using a temporary pointer
        Node temp = head;
        
        while (temp != null)
        {
            // Check if the current node has been encountered before
            if (visitedNodes.ContainsKey(temp))
            {
                // A loop is detected, return the starting node of the loop
                return temp;
            }

            // Mark the current node as visited
            visitedNodes[temp] = 1;
            // Move to the next node in the list
            temp = temp.Next;
        }

        // If no loop is detected, return null
        return null;
    }

    static void Main()
    {
        // Create a sample linked list with a loop
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        node1.Next = node2;
        Node node3 = new Node(3);
        node2.Next = node3;
        Node node4 = new Node(4);
        node3.Next = node4;
        Node node5 = new Node(5);
        node4.Next = node5;

        // Make a loop from node5 to node2
        node5.Next = node2;

        // Set the head of the linked list
        Node head = node1;

        // Detect the loop in the linked list
        Node loopStartNode = DetectLoop(head);

        if (loopStartNode != null)
        {
            Console.WriteLine("Loop detected. Starting node of the loop is: " + loopStartNode.Data);
        }
        else
        {
            Console.WriteLine("No loop detected in the linked list.");
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
    // Function to find the first node of the loop in the linked list
    public static Node FirstNode(Node head)
    {
        // Initialize slow and fast pointers to the head of the list
        Node slow = head;
        Node fast = head;

        // Phase 1: Detect the loop
        while (fast != null && fast.Next != null)
        {
            // Move slow pointer one step
            slow = slow.Next;

            // Move fast pointer two steps
            fast = fast.Next.Next;

            // If slow and fast meet, a loop is detected
            if (slow == fast)
            {
                // Reset slow pointer to the head of the list
                slow = head;

                // Phase 2: Find the first node of the loop
                while (slow != fast)
                {
                    // Move slow and fast one step at a time
                    slow = slow.Next;
                    fast = fast.Next;
                }

                // Return the first node of the loop
                return slow;
            }
        }

        // If no loop is found, return null
        return null;
    }

    static void Main()
    {
        // Create a sample linked list with a loop
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        node1.Next = node2;
        Node node3 = new Node(3);
        node2.Next = node3;
        Node node4 = new Node(4);
        node3.Next = node4;
        Node node5 = new Node(5);
        node4.Next = node5;

        // Make a loop from node5 to node2
        node5.Next = node2;

        // Set the head of the linked list
        Node head = node1;

        // Detect the loop in the linked list
        Node loopStartNode = FirstNode(head);

        if (loopStartNode != null)
        {
            Console.WriteLine("Loop detected. Starting node of the loop is: " + loopStartNode.Data);
        }
        else
        {
            Console.WriteLine("No loop detected in the linked list.");
        }
    }
}
