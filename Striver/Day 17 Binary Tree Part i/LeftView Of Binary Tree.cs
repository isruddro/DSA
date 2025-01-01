using System;
using System.Collections.Generic;

// Node structure for the binary tree
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
    // Function to return the Right view of the binary tree
    public List<int> RightSideView(Node root)
    {
        // List to store the result
        List<int> res = new List<int>();

        // Get the level order traversal of the tree
        var levelTraversal = LevelOrder(root);

        // Iterate through each level and add the last element to the result
        foreach (var level in levelTraversal)
        {
            res.Add(level[level.Count - 1]);
        }

        return res;
    }

    // Function to return the Left view of the binary tree
    public List<int> LeftSideView(Node root)
    {
        // List to store the result
        List<int> res = new List<int>();

        // Get the level order traversal of the tree
        var levelTraversal = LevelOrder(root);

        // Iterate through each level and add the first element to the result
        foreach (var level in levelTraversal)
        {
            res.Add(level[0]);
        }

        return res;
    }

    // Function that returns the level order traversal of a binary tree
    private List<List<int>> LevelOrder(Node root)
    {
        var ans = new List<List<int>>();

        // Return an empty list if the tree is empty
        if (root == null)
        {
            return ans;
        }

        // Use a queue to perform level order traversal
        var q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int size = q.Count;
            var level = new List<int>();

            // Process each node in the current level
            for (int i = 0; i < size; i++)
            {
                Node top = q.Dequeue();
                level.Add(top.Data);

                // Enqueue the left child if it exists
                if (top.Left != null)
                {
                    q.Enqueue(top.Left);
                }

                // Enqueue the right child if it exists
                if (top.Right != null)
                {
                    q.Enqueue(top.Right);
                }
            }

            // Add the current level to the result
            ans.Add(level);
        }

        return ans;
    }
}

class Program
{
    static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(10);
        root.Left.Left.Right = new Node(5);
        root.Left.Left.Right.Right = new Node(6);
        root.Right = new Node(3);
        root.Right.Right = new Node(10);
        root.Right.Left = new Node(9);

        Solution solution = new Solution();

        // Get the Right View traversal
        List<int> rightView = solution.RightSideView(root);

        // Print the result for Right View
        Console.Write("Right View Traversal: ");
        foreach (var node in rightView)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();

        // Get the Left View traversal
        List<int> leftView = solution.LeftSideView(root);

        // Print the result for Left View
        Console.Write("Left View Traversal: ");
        foreach (var node in leftView)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();
    }
}
