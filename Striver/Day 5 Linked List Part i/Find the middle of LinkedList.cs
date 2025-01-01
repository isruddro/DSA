BF:


using System;

public class Node {
    public int Data;
    public Node Next;

    // Constructor with both data and next node as parameters
    public Node(int data1, Node next1) {
        Data = data1;
        Next = next1;
    }

    // Constructor with only data as a parameter, sets next to null
    public Node(int data1) {
        Data = data1;
        Next = null;
    }
}

public class Solution {
    // Function to find the middle node of a linked list
    public static Node FindMiddle(Node head) {
        // If the list is empty or has only one element, return the head as it's the middle.
        if (head == null || head.Next == null) {
            return head;
        }

        Node temp = head;
        int count = 0;

        // Count the number of nodes in the linked list.
        while (temp != null) {
            count++;
            temp = temp.Next;
        }

        // Calculate the position of the middle node.
        int mid = count / 2 + 1;
        temp = head;

        // Traverse to the middle node by moving temp to the middle position.
        while (temp != null) {
            mid = mid - 1;

            // Check if the middle position is reached.
            if (mid == 0) {
                // break out of the loop to return temp
                break;
            }

            // Move temp ahead
            temp = temp.Next;
        }

        // Return the middle node.
        return temp;
    }

    // Function to print the linked list
    public static void PrintLinkedList(Node head) {
        Node temp = head;
        while (temp != null) {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    public static void Main() {
        // Creating a sample linked list: 1 -> 2 -> 3 -> 4 -> 5
        Node head = new Node(1);
        head.Next = new Node(2);
        head.Next.Next = new Node(3);
        head.Next.Next.Next = new Node(4);
        head.Next.Next.Next.Next = new Node(5);

        // Find the middle node
        Node middleNode = FindMiddle(head);

        // Display the value of the middle node
        Console.WriteLine("The middle node value is: " + middleNode.Data);
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
    // Function to find the middle node of a linked list
    public static Node FindMiddle(Node head)
    {
        // Initialize the slow pointer to the head
        Node slow = head;

        // Initialize the fast pointer to the head
        Node fast = head;

        // Traverse the linked list using the Tortoise and Hare algorithm
        while (fast != null && fast.Next != null)
        {
            // Move slow one step
            slow = slow.Next;

            // Move fast two steps
            fast = fast.Next.Next;
        }

        // Return the slow pointer, which is now at the middle node
        return slow;
    }

    static void Main(string[] args)
    {
        // Creating a sample linked list: 1 -> 2 -> 3 -> 4 -> 5
        Node head = new Node(1);
        head.Next = new Node(2);
        head.Next.Next = new Node(3);
        head.Next.Next.Next = new Node(4);
        head.Next.Next.Next.Next = new Node(5);

        // Find the middle node
        Node middleNode = FindMiddle(head);

        // Display the value of the middle node
        Console.WriteLine("The middle node value is: " + middleNode.Data);
    }
}
