Solution 1: Brute-Force


using System;

public class Node
{
    public int Num;
    public Node Next;

    public Node(int val)
    {
        Num = val;
        Next = null;
    }
}

class Solution
{
    // Utility function to insert node at the end of the linked list
    public void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Utility function to check the presence of intersection
    public Node IntersectionPresent(Node head1, Node head2)
    {
        while (head2 != null)
        {
            Node temp = head1;
            while (temp != null)
            {
                // If both nodes are the same
                if (temp == head2) return head2;
                temp = temp.Next;
            }
            head2 = head2.Next;
        }

        // No intersection is present between the lists, return null
        return null;
    }

    // Utility function to print linked list
    public void PrintList(Node head)
    {
        while (head.Next != null)
        {
            Console.Write(head.Num + "->");
            head = head.Next;
        }
        Console.WriteLine(head.Num);
    }

    static void Main()
    {
        Node head = null;
        Solution solution = new Solution();

        // Creation of both lists
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 3);
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 2);
        solution.InsertNode(ref head, 4);
        Node head1 = head;
        head = head.Next.Next.Next;
        Node headSec = null;
        solution.InsertNode(ref headSec, 3);
        Node head2 = headSec;
        headSec.Next = head;

        // Printing the lists
        Console.WriteLine("List1: ");
        solution.PrintList(head1);
        Console.WriteLine("List2: ");
        solution.PrintList(head2);

        // Checking if intersection is present
        Node answerNode = solution.IntersectionPresent(head1, head2);
        if (answerNode == null)
            Console.WriteLine("No intersection");
        else
            Console.WriteLine("The intersection point is " + answerNode.Num);
    }
}



Solution 2: Hashing


using System;
using System.Collections.Generic;

public class Node
{
    public int Num;
    public Node Next;

    public Node(int val)
    {
        Num = val;
        Next = null;
    }
}

class Solution
{
    // Utility function to insert node at the end of the linked list
    public void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Utility function to check the presence of intersection
    public Node IntersectionPresent(Node head1, Node head2)
    {
        HashSet<Node> st = new HashSet<Node>();

        while (head1 != null)
        {
            st.Add(head1);
            head1 = head1.Next;
        }

        while (head2 != null)
        {
            if (st.Contains(head2)) return head2;
            head2 = head2.Next;
        }

        return null;
    }

    // Utility function to print linked list
    public void PrintList(Node head)
    {
        while (head.Next != null)
        {
            Console.Write(head.Num + "->");
            head = head.Next;
        }
        Console.WriteLine(head.Num);
    }

    static void Main()
    {
        Node head = null;
        Solution solution = new Solution();

        // Creation of both lists
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 3);
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 2);
        solution.InsertNode(ref head, 4);
        Node head1 = head;
        head = head.Next.Next.Next;
        Node headSec = null;
        solution.InsertNode(ref headSec, 3);
        Node head2 = headSec;
        headSec.Next = head;

        // Printing the lists
        Console.WriteLine("List1: ");
        solution.PrintList(head1);
        Console.WriteLine("List2: ");
        solution.PrintList(head2);

        // Checking if intersection is present
        Node answerNode = solution.IntersectionPresent(head1, head2);
        if (answerNode == null)
            Console.WriteLine("No intersection");
        else
            Console.WriteLine("The intersection point is " + answerNode.Num);
    }
}



Solution 3: Difference in length


using System;
using System.Collections.Generic;

public class Node
{
    public int Num;
    public Node Next;

    public Node(int val)
    {
        Num = val;
        Next = null;
    }
}

class Solution
{
    // Utility function to insert node at the end of the linked list
    public void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Function to calculate the difference in lengths between two linked lists
    public int GetDifference(Node head1, Node head2)
    {
        int len1 = 0, len2 = 0;

        while (head1 != null || head2 != null)
        {
            if (head1 != null)
            {
                ++len1;
                head1 = head1.Next;
            }

            if (head2 != null)
            {
                ++len2;
                head2 = head2.Next;
            }
        }

        return len1 - len2; // if difference is negative, length of list2 > length of list1, else vice-versa
    }

    // Utility function to check the presence of intersection
    public Node IntersectionPresent(Node head1, Node head2)
    {
        int diff = GetDifference(head1, head2);

        // Adjust the starting point of the longer list
        if (diff < 0)
        {
            while (diff++ != 0)
                head2 = head2.Next;
        }
        else
        {
            while (diff-- != 0)
                head1 = head1.Next;
        }

        // Traverse both lists and check for intersection
        while (head1 != null)
        {
            if (head1 == head2)
                return head1;
            head2 = head2.Next;
            head1 = head1.Next;
        }

        return null; // No intersection
    }

    // Utility function to print the linked list
    public void PrintList(Node head)
    {
        while (head.Next != null)
        {
            Console.Write(head.Num + "->");
            head = head.Next;
        }
        Console.WriteLine(head.Num);
    }

    static void Main()
    {
        Node head = null;
        Solution solution = new Solution();

        // Creation of both lists
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 3);
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 2);
        solution.InsertNode(ref head, 4);
        Node head1 = head;
        head = head.Next.Next.Next;
        Node headSec = null;
        solution.InsertNode(ref headSec, 3);
        Node head2 = headSec;
        headSec.Next = head;

        // Printing the lists
        Console.WriteLine("List1: ");
        solution.PrintList(head1);
        Console.WriteLine("List2: ");
        solution.PrintList(head2);

        // Checking if intersection is present
        Node answerNode = solution.IntersectionPresent(head1, head2);
        if (answerNode == null)
            Console.WriteLine("No intersection");
        else
            Console.WriteLine("The intersection point is " + answerNode.Num);
    }
}



Solution 4: Optimised 


using System;

public class Node
{
    public int Num;
    public Node Next;

    public Node(int val)
    {
        Num = val;
        Next = null;
    }
}

class Solution
{
    // Utility function to insert node at the end of the linked list
    public void InsertNode(ref Node head, int val)
    {
        Node newNode = new Node(val);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Utility function to check presence of intersection
    public Node IntersectionPresent(Node head1, Node head2)
    {
        Node d1 = head1;
        Node d2 = head2;

        while (d1 != d2)
        {
            d1 = d1 == null ? head2 : d1.Next;
            d2 = d2 == null ? head1 : d2.Next;
        }

        return d1;
    }

    // Utility function to print linked list
    public void PrintList(Node head)
    {
        while (head.Next != null)
        {
            Console.Write(head.Num + "->");
            head = head.Next;
        }
        Console.WriteLine(head.Num);
    }

    static void Main()
    {
        Node head = null;
        Solution solution = new Solution();

        // Creation of both lists
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 3);
        solution.InsertNode(ref head, 1);
        solution.InsertNode(ref head, 2);
        solution.InsertNode(ref head, 4);
        Node head1 = head;
        head = head.Next.Next.Next;
        Node headSec = null;
        solution.InsertNode(ref headSec, 3);
        Node head2 = headSec;
        headSec.Next = head;

        // Printing the lists
        Console.WriteLine("List1: ");
        solution.PrintList(head1);
        Console.WriteLine("List2: ");
        solution.PrintList(head2);

        // Checking if intersection is present
        Node answerNode = solution.IntersectionPresent(head1, head2);
        if (answerNode == null)
            Console.WriteLine("No intersection");
        else
            Console.WriteLine("The intersection point is " + answerNode.Num);
    }
}
