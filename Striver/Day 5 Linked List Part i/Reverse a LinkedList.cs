Approach 1 : Brute Force 


using System;
using System.Collections.Generic;

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
    // Function to reverse the linked list using a stack
    public static Node ReverseLinkedList(Node head) {
        // Create a temporary pointer to traverse the linked list
        Node temp = head;

        // Create a stack to temporarily store the data values
        Stack<int> st = new Stack<int>();

        // Step 1: Push the values of the linked list onto the stack
        while (temp != null) {
            st.Push(temp.Data);
            temp = temp.Next;
        }

        // Reset the temporary pointer to the head of the linked list
        temp = head;

        // Step 2: Pop values from the stack and update the linked list
        while (temp != null) {
            temp.Data = st.Pop();
            temp = temp.Next;
        }

        // Return the new head of the reversed linked list
        return head;
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
        // Create a linked list with values 1, 3, 2, and 4
        Node head = new Node(1);
        head.Next = new Node(3);
        head.Next.Next = new Node(2);
        head.Next.Next.Next = new Node(4);

        // Print the original linked list
        Console.Write("Original Linked List: ");
        PrintLinkedList(head);

        // Reverse the linked list
        head = ReverseLinkedList(head);

        // Print the reversed linked list
        Console.Write("Reversed Linked List: ");
        PrintLinkedList(head);
    }
}



Approach 2: Reverse Links in place (Iterative)


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
    // Function to reverse a linked list using the 3-pointer approach
    public static Node ReverseLinkedList(Node head) {
        // Initialize 'temp' at head of linked list
        Node temp = head;
        
        // Initialize pointer 'prev' to null, representing the previous node
        Node prev = null;

        // Traverse the list, continue till 'temp' reaches the end (null)
        while (temp != null) {
            // Store the next node in 'front' to preserve the reference
            Node front = temp.Next;

            // Reverse the direction of the current node's 'next' pointer
            // to point to 'prev'
            temp.Next = prev;

            // Move 'prev' to the current node for the next iteration
            prev = temp;

            // Move 'temp' to the 'front' node, advancing the traversal
            temp = front;
        }

        // Return the new head of the reversed linked list
        return prev;
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
        // Create a linked list with values 1, 3, 2, and 4
        Node head = new Node(1);
        head.Next = new Node(3);
        head.Next.Next = new Node(2);
        head.Next.Next.Next = new Node(4);

        // Print the original linked list
        Console.Write("Original Linked List: ");
        PrintLinkedList(head);

        // Reverse the linked list
        head = ReverseLinkedList(head);

        // Print the reversed linked list
        Console.Write("Reversed Linked List: ");
        PrintLinkedList(head);
    }
}



Approach 3: Recursive 


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
    // Function to reverse a singly linked list using recursion
    public static Node ReverseLinkedList(Node head) {
        // Base case: If the linked list is empty or has only one node,
        // return the head as it is already reversed.
        if (head == null || head.Next == null) {
            return head;
        }

        // Recursive step: Reverse the linked list starting 
        // from the second node (head.Next).
        Node newHead = ReverseLinkedList(head.Next);

        // Save a reference to the node following the current 'head' node.
        Node front = head.Next;

        // Make the 'front' node point to the current 'head' node in the reversed order.
        front.Next = head;

        // Break the link from the current 'head' node to the 'front' node to avoid cycles.
        head.Next = null;

        // Return the 'newHead,' which is the new head of the reversed linked list.
        return newHead;
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
        // Create a linked list with values 1, 3, 2, and 4
        Node head = new Node(1);
        head.Next = new Node(3);
        head.Next.Next = new Node(2);
        head.Next.Next.Next = new Node(4);

        // Print the original linked list
        Console.Write("Original Linked List: ");
        PrintLinkedList(head);

        // Reverse the linked list
        head = ReverseLinkedList(head);

        // Print the reversed linked list
        Console.Write("Reversed Linked List: ");
        PrintLinkedList(head);
    }
}
