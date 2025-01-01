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
    // Function to reverse a linked list using the 3-pointer approach
    public static Node ReverseLinkedList(Node head)
    {
        Node temp = head;
        Node prev = null;

        while (temp != null)
        {
            // Store the next node
            Node front = temp.Next;
            // Reverse the current node's next pointer
            temp.Next = prev;
            // Move the prev and temp pointers one step forward
            prev = temp;
            temp = front;
        }

        return prev;
    }

    // Function to get the Kth node from a given position in the linked list
    public static Node GetKthNode(Node temp, int k)
    {
        k -= 1; // Decrement k as we start from the 1st node

        // Move to the Kth node
        while (temp != null && k > 0)
        {
            k--;
            temp = temp.Next;
        }

        return temp;
    }

    // Function to reverse nodes in groups of K
    public static Node KReverse(Node head, int k)
    {
        Node temp = head;
        Node prevLast = null;

        while (temp != null)
        {
            // Get the Kth node of the current group
            Node kThNode = GetKthNode(temp, k);

            if (kThNode == null)
            {
                // If it's not a complete group, link the last node of the previous group
                if (prevLast != null)
                {
                    prevLast.Next = temp;
                }
                break;
            }

            // Store the next node after the Kth node
            Node nextNode = kThNode.Next;
            // Disconnect the Kth node from the next node to prepare for reversal
            kThNode.Next = null;

            // Reverse the nodes from temp to kThNode
            ReverseLinkedList(temp);

            // Adjust the head if this is the first reversal
            if (temp == head)
            {
                head = kThNode;
            }
            else
            {
                prevLast.Next = kThNode;
            }

            // Update prevLast to the last node of the current reversed group
            prevLast = temp;

            // Move to the next group
            temp = nextNode;
        }

        return head;
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
        // Create a linked list with values 5, 4, 3, 7, 9, and 2
        Node head = new Node(5);
        head.Next = new Node(4);
        head.Next.Next = new Node(3);
        head.Next.Next.Next = new Node(7);
        head.Next.Next.Next.Next = new Node(9);
        head.Next.Next.Next.Next.Next = new Node(2);

        // Print the original linked list
        Console.WriteLine("Original Linked List:");
        PrintLinkedList(head);

        // Reverse the linked list in groups of 4
        head = KReverse(head, 4);

        // Print the reversed linked list
        Console.WriteLine("Reversed Linked List:");
        PrintLinkedList(head);
    }
}
