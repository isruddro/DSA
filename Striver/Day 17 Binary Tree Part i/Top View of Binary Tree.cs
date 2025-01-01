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
    // Function to return the top view of the binary tree
    public List<int> TopView(Node root)
    {
        // List to store the result
        List<int> ans = new List<int>();

        // Check if the tree is empty
        if (root == null)
        {
            return ans;
        }

        // Map to store the top view nodes based on their vertical positions
        var mpp = new SortedDictionary<int, int>();

        // Queue for BFS traversal, each element is a pair containing node and its vertical position
        var q = new Queue<KeyValuePair<Node, int>>();

        // Push the root node with its vertical position (0) into the queue
        q.Enqueue(new KeyValuePair<Node, int>(root, 0));

        // BFS traversal
        while (q.Count > 0)
        {
            var it = q.Dequeue();
            Node node = it.Key;
            int line = it.Value;

            // If the vertical position is not already in the map, add the node's data to the map
            if (!mpp.ContainsKey(line))
            {
                mpp[line] = node.Data;
            }

            // Process left child
            if (node.Left != null)
            {
                // Push the left child with a decreased vertical position into the queue
                q.Enqueue(new KeyValuePair<Node, int>(node.Left, line - 1));
            }

            // Process right child
            if (node.Right != null)
            {
                // Push the right child with an increased vertical position into the queue
                q.Enqueue(new KeyValuePair<Node, int>(node.Right, line + 1));
            }
        }

        // Transfer values from the map to the result list
        foreach (var it in mpp)
        {
            ans.Add(it.Value);
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

        // Get the Top View traversal
        List<int> topView = solution.TopView(root);

        // Print the result
        Console.WriteLine("Top View Traversal:");
        foreach (var node in topView)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();
    }
}
