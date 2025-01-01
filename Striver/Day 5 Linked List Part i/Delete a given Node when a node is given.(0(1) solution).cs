using System;

public class Node {
    public int Num;
    public Node Next;

    public Node(int a) {
        Num = a;
        Next = null;
    }
}

class Solution {
    // Function to insert node at the end of the list
    public void InsertNode(ref Node head, int val) {
        Node newNode = new Node(val);
        if (head == null) {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null) temp = temp.Next;
        temp.Next = newNode;
    }

    // Function to get reference of the node to delete
    public Node GetNode(Node head, int val) {
        while (head.Num != val) head = head.Next;
        return head;
    }

    // Delete function as per the question
    public void DeleteNode(Node t) {
        t.Num = t.Next.Num;
        t.Next = t.Next.Next;
    }

    // Printing the list function
    public void PrintList(Node head) {
        while (head.Next != null) {
            Console.Write(head.Num + "->");
            head = head.Next;
        }
        Console.WriteLine(head.Num);
    }

    static void Main() {
        Node head = null;
        Solution solution = new Solution();
        
        // Inserting nodes
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 4);
        solution.InsertNode(ref head, 2);
        solution.InsertNode(ref head, 3);

        // Printing the given list
        Console.WriteLine("Given Linked List:");
        solution.PrintList(head);

        // Get the node to delete (node with value 2)
        Node t = solution.GetNode(head, 2);

        // Delete the node
        solution.DeleteNode(t);

        // List after deletion operation
        Console.WriteLine("Linked List after deletion:");
        solution.PrintList(head);
    }
}
