BF:


using System;

class Node
{
    public int num;
    public Node next;

    public Node(int a)
    {
        num = a;
        next = null;
    }
}

class LinkedList
{
    // Utility function to insert a node at the end of the list
    public static void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);
        if (head == null)
        {
            head = newNode;
            return;
        }
        
        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        
        temp.next = newNode;
    }

    // Utility function to rotate the list by k times
    public static Node RotateRight(Node head, int k)
    {
        if (head == null || head.next == null) return head;

        // Get the length of the list
        int length = 1;
        Node temp = head;
        while (temp.next != null)
        {
            length++;
            temp = temp.next;
        }

        // If k is larger than the length, rotate the list by k % length times
        k = k % length;
        if (k == 0) return head;

        // Move temp to the (length - k)th node
        temp.next = head; // Create a cycle for rotation
        for (int i = 0; i < length - k; i++)
        {
            temp = temp.next;
        }

        // Set new head and break the cycle
        Node newHead = temp.next;
        temp.next = null;

        return newHead;
    }

    // Utility function to print the list
    public static void PrintList(Node head)
    {
        while (head != null)
        {
            Console.Write(head.num);
            if (head.next != null)
                Console.Write(" -> ");
            head = head.next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Node head = null;
        
        // Inserting nodes
        LinkedList.InsertNode(ref head, 1);
        LinkedList.InsertNode(ref head, 2);
        LinkedList.InsertNode(ref head, 3);
        LinkedList.InsertNode(ref head, 4);
        LinkedList.InsertNode(ref head, 5);

        Console.WriteLine("Original list: ");
        LinkedList.PrintList(head);

        int k = 2;
        Node newHead = LinkedList.RotateRight(head, k); // Calling function for rotating right by k times

        Console.WriteLine($"After {k} iterations: ");
        LinkedList.PrintList(newHead); // List after rotating nodes
    }
}




Solution: Optimal Solution


using System;

class Node
{
    public int num;
    public Node next;

    public Node(int a)
    {
        num = a;
        next = null;
    }
}

class LinkedList
{
    // Utility function to insert a node at the end of the list
    public static void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    // Utility function to rotate the list by k times
    public static Node RotateRight(Node head, int k)
    {
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }

        // Calculate the length of the list
        Node temp = head;
        int length = 1;
        while (temp.next != null)
        {
            length++;
            temp = temp.next;
        }

        // Link the last node to the first node (create a cycle)
        temp.next = head;

        k = k % length; // Adjust k if it's larger than the list length
        int end = length - k; // Find the node just before the new head

        // Traverse to the end node
        while (end-- > 0)
        {
            temp = temp.next;
        }

        // Break the cycle and set the new head
        Node newHead = temp.next;
        temp.next = null;

        return newHead;
    }

    // Utility function to print the list
    public static void PrintList(Node head)
    {
        while (head != null)
        {
            Console.Write(head.num);
            if (head.next != null)
            {
                Console.Write(" -> ");
            }
            head = head.next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Node head = null;

        // Inserting nodes
        LinkedList.InsertNode(ref head, 1);
        LinkedList.InsertNode(ref head, 2);
        LinkedList.InsertNode(ref head, 3);
        LinkedList.InsertNode(ref head, 4);
        LinkedList.InsertNode(ref head, 5);

        Console.WriteLine("Original list: ");
        LinkedList.PrintList(head);

        int k = 2;
        Node newHead = LinkedList.RotateRight(head, k); // Calling function to rotate right by k times

        Console.WriteLine($"After {k} iterations: ");
        LinkedList.PrintList(newHead); // List after rotating nodes
    }
}
