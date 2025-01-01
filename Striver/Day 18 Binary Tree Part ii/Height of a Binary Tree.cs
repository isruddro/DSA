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
    // Function to find the maximum depth of a binary tree
    public int MaxDepth(Node root)
    {
        // If the root is null (empty tree), depth is 0
        if (root == null)
        {
            return 0;
        }

        // Recursive call to find the maximum depth of the left subtree
        int lh = MaxDepth(root.Left);

        // Recursive call to find the maximum depth of the right subtree
        int rh = MaxDepth(root.Right);

        // Return the maximum depth of the tree, adding 1 for the current node
        return 1 + Math.Max(lh, rh);
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

        // Create an instance of the Solution class
        Solution solution = new Solution();
        // Find the maximum depth of the tree
        int depth = solution.MaxDepth(root);

        Console.WriteLine("Maximum depth of the binary tree: " + depth);
    }
}
