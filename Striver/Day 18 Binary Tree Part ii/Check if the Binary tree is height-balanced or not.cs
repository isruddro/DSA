BF:


using System;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    // Constructor to initialize the node with a value
    public Node(int val)
    {
        Data = val;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    // Function to check if a binary tree is balanced
    public bool IsBalanced(Node root)
    {
        // If the tree is empty, it's balanced
        if (root == null)
        {
            return true;
        }

        // Calculate the height of left and right subtrees
        int leftHeight = GetHeight(root.Left);
        int rightHeight = GetHeight(root.Right);

        // Check if the absolute difference in heights
        // of left and right subtrees is <= 1
        if (Math.Abs(leftHeight - rightHeight) <= 1 &&
            IsBalanced(root.Left) &&
            IsBalanced(root.Right))
        {
            return true;
        }

        // If any condition fails, the tree is unbalanced
        return false;
    }

    // Function to calculate the height of a subtree
    private int GetHeight(Node root)
    {
        // Base case: if the current node is NULL,
        // return 0 (height of an empty tree)
        if (root == null)
        {
            return 0;
        }

        // Recursively calculate the height of left and right subtrees
        int leftHeight = GetHeight(root.Left);
        int rightHeight = GetHeight(root.Right);

        // Return the maximum height of left and right subtrees
        // plus 1 (to account for the current node)
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);
        root.Left.Right.Right = new Node(6);
        root.Left.Right.Right.Right = new Node(7);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Checking if the tree is balanced
        if (solution.IsBalanced(root))
        {
            Console.WriteLine("The tree is balanced.");
        }
        else
        {
            Console.WriteLine("The tree is not balanced.");
        }
    }
}



Optimal:


using System;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    // Constructor to initialize the node with a value
    public Node(int val)
    {
        Data = val;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    // Function to check if a binary tree is balanced
    public bool IsBalanced(Node root)
    {
        // Check if the tree's height difference
        // between subtrees is less than or equal to 1
        // If not, return false; otherwise, return true
        return DfsHeight(root) != -1;
    }

    // Recursive function to calculate the height of the tree
    private int DfsHeight(Node root)
    {
        // Base case: if the current node is NULL,
        // return 0 (height of an empty tree)
        if (root == null)
        {
            return 0;
        }

        // Recursively calculate the height of the left subtree
        int leftHeight = DfsHeight(root.Left);

        // If the left subtree is unbalanced, propagate the unbalance status
        if (leftHeight == -1)
        {
            return -1;
        }

        // Recursively calculate the height of the right subtree
        int rightHeight = DfsHeight(root.Right);

        // If the right subtree is unbalanced, propagate the unbalance status
        if (rightHeight == -1)
        {
            return -1;
        }

        // Check if the difference in height between left and right subtrees is greater than 1
        // If it's greater, the tree is unbalanced, return -1 to propagate the unbalance status
        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }

        // Return the maximum height of left and right subtrees, adding 1 for the current node
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);
        root.Left.Right.Right = new Node(6);
        root.Left.Right.Right.Right = new Node(7);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Checking if the tree is balanced
        if (solution.IsBalanced(root))
        {
            Console.WriteLine("The tree is balanced.");
        }
        else
        {
            Console.WriteLine("The tree is not balanced.");
        }
    }
}
