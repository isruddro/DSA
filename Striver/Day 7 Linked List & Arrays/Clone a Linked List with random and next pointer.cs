BF:


using System;
using System.Collections.Generic;

class Node
{
    public int data;
    public Node next;
    public Node random;

    // Constructors for Node class
    public Node() 
    {
        data = 0;
        next = null;
        random = null;
    }

    public Node(int x) 
    {
        data = x;
        next = null;
        random = null;
    }

    public Node(int x, Node nextNode, Node randomNode) 
    {
        data = x;
        next = nextNode;
        random = randomNode;
    }
}

class LinkedList
{
    // Function to clone the linked list
    public static Node CloneLL(Node head)
    {
        Node temp = head;
        // Create a dictionary to map original nodes to their corresponding copied nodes
        Dictionary<Node, Node> mpp = new Dictionary<Node, Node>();

        // Step 1: Create copies of each node and store them in the dictionary
        while (temp != null)
        {
            Node newNode = new Node(temp.data);
            mpp[temp] = newNode;
            temp = temp.next;
        }

        temp = head;
        // Step 2: Connect the next and random pointers of the copied nodes using the dictionary
        while (temp != null)
        {
            Node copyNode = mpp[temp];
            copyNode.next = mpp.ContainsKey(temp.next) ? mpp[temp.next] : null;
            copyNode.random = mpp.ContainsKey(temp.random) ? mpp[temp.random] : null;
            temp = temp.next;
        }

        // Return the head of the deep copied list from the dictionary
        return mpp.ContainsKey(head) ? mpp[head] : null;
    }

    // Function to print the cloned linked list
    public static void PrintClonedLinkedList(Node head)
    {
        while (head != null)
        {
            Console.Write("Data: " + head.data);
            if (head.random != null)
            {
                Console.Write(", Random: " + head.random.data);
            }
            else
            {
                Console.Write(", Random: nullptr");
            }
            Console.WriteLine();
            head = head.next;
        }
    }
}

class Program
{
    static void Main()
    {
        // Example linked list: 7 -> 14 -> 21 -> 28
        Node head = new Node(7);
        head.next = new Node(14);
        head.next.next = new Node(21);
        head.next.next.next = new Node(28);

        // Assigning random pointers
        head.random = head.next.next;
        head.next.random = head;
        head.next.next.random = head.next.next.next;
        head.next.next.next.random = head.next;

        Console.WriteLine("Original Linked List with Random Pointers:");
        LinkedList.PrintClonedLinkedList(head);

        // Clone the linked list
        Node clonedList = LinkedList.CloneLL(head);

        Console.WriteLine("\nCloned Linked List with Random Pointers:");
        LinkedList.PrintClonedLinkedList(clonedList);
    }
}



Optimal:


using System;

class Node
{
    public int data;
    public Node next;
    public Node random;

    // Constructors for Node class
    public Node()
    {
        data = 0;
        next = null;
        random = null;
    }

    public Node(int x)
    {
        data = x;
        next = null;
        random = null;
    }

    public Node(int x, Node nextNode, Node randomNode)
    {
        data = x;
        next = nextNode;
        random = randomNode;
    }
}

class LinkedList
{
    // Function to insert a copy of each node in between the original nodes
    public static void InsertCopyInBetween(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            Node nextElement = temp.next;
            // Create a new node with the same data
            Node copy = new Node(temp.data);

            // Point the copy's next to the original node's next
            copy.next = nextElement;

            // Point the original node's next to the copy
            temp.next = copy;

            // Move to the next original node
            temp = nextElement;
        }
    }

    // Function to connect random pointers of the copied nodes
    public static void ConnectRandomPointers(Node head)
    {
        Node temp = head;
        while (temp != null)
        {
            // Access the copied node
            Node copyNode = temp.next;

            // If the original node has a random pointer
            if (temp.random != null)
            {
                // Point the copied node's random to the corresponding copied random node
                copyNode.random = temp.random.next;
            }
            else
            {
                // Set the copied node's random to null if the original random is null
                copyNode.random = null;
            }

            // Move to the next original node
            temp = temp.next.next;
        }
    }

    // Function to retrieve the deep copy of the linked list
    public static Node GetDeepCopyList(Node head)
    {
        Node temp = head;
        // Create a dummy node
        Node dummyNode = new Node(-1);
        // Initialize a result pointer
        Node res = dummyNode;

        while (temp != null)
        {
            // Creating a new List by pointing to copied nodes
            res.next = temp.next;
            res = res.next;

            // Disconnect and revert back to the initial state of the original linked list
            temp.next = temp.next.next;
            temp = temp.next;
        }

        // Return the deep copy of the list starting from the dummy node
        return dummyNode.next;
    }

    // Function to clone the linked list
    public static Node CloneLL(Node head)
    {
        // If the original list is empty, return null
        if (head == null)
            return null;

        // Step 1: Insert copy of nodes in between
        InsertCopyInBetween(head);

        // Step 2: Connect random pointers of copied nodes
        ConnectRandomPointers(head);

        // Step 3: Retrieve the deep copy of the linked list
        return GetDeepCopyList(head);
    }

    // Function to print the cloned linked list
    public static void PrintClonedLinkedList(Node head)
    {
        while (head != null)
        {
            Console.Write("Data: " + head.data);
            if (head.random != null)
            {
                Console.Write(", Random: " + head.random.data);
            }
            else
            {
                Console.Write(", Random: nullptr");
            }
            Console.WriteLine();
            head = head.next;
        }
    }
}

class Program
{
    static void Main()
    {
        // Example linked list: 7 -> 14 -> 21 -> 28
        Node head = new Node(7);
        head.next = new Node(14);
        head.next.next = new Node(21);
        head.next.next.next = new Node(28);

        // Assigning random pointers
        head.random = head.next.next;
        head.next.random = head;
        head.next.next.random = head.next.next.next;
        head.next.next.next.random = head.next;

        Console.WriteLine("Original Linked List with Random Pointers:");
        LinkedList.PrintClonedLinkedList(head);

        // Clone the linked list
        Node clonedList = LinkedList.CloneLL(head);

        Console.WriteLine("\nCloned Linked List with Random Pointers:");
        LinkedList.PrintClonedLinkedList(clonedList);
    }
}
