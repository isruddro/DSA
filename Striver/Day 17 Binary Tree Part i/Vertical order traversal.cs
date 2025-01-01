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
    // Function to perform vertical order traversal
    // and return a list of node values
    public List<List<int>> FindVertical(Node root)
    {
        // Dictionary to store nodes based on vertical and level information
        var nodes = new SortedDictionary<int, SortedDictionary<int, SortedSet<int>>>();

        // Queue for BFS traversal
        var todo = new Queue<Tuple<Node, Tuple<int, int>>>();

        // Push the root node with initial vertical and level values (0, 0)
        todo.Enqueue(Tuple.Create(root, Tuple.Create(0, 0)));

        // BFS traversal
        while (todo.Count > 0)
        {
            var p = todo.Dequeue();
            var temp = p.Item1;
            var x = p.Item2.Item1; // vertical
            var y = p.Item2.Item2; // level

            // Insert the node value into the corresponding vertical and level in the map
            if (!nodes.ContainsKey(x))
                nodes[x] = new SortedDictionary<int, SortedSet<int>>();

            if (!nodes[x].ContainsKey(y))
                nodes[x][y] = new SortedSet<int>();

            nodes[x][y].Add(temp.Data);

            // Process left child
            if (temp.Left != null)
            {
                todo.Enqueue(Tuple.Create(temp.Left, Tuple.Create(x - 1, y + 1)));
            }

            // Process right child
            if (temp.Right != null)
            {
                todo.Enqueue(Tuple.Create(temp.Right, Tuple.Create(x + 1, y + 1)));
            }
        }

        // Prepare the final result list
        var ans = new List<List<int>>();
        foreach (var p in nodes)
        {
            var col = new List<int>();
            foreach (var q in p.Value)
            {
                // Insert node values into the column list
                col.AddRange(q.Value);
            }
            ans.Add(col);
        }

        return ans;
    }
}

// Helper function to print the result
public static void PrintResult(List<List<int>> result)
{
    foreach (var level in result)
    {
        foreach (var node in level)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

class Program
{
    static void Main()
    {
        // Creating a sample binary tree
        var root = new Node(1);
        root.Left = new Node(2);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(10);
        root.Left.Left.Right = new Node(5);
        root.Left.Left.Right.Right = new Node(6);
        root.Right = new Node(3);
        root.Right.Right = new Node(10);
        root.Right.Left = new Node(9);

        var solution = new Solution();

        // Get the Vertical traversal
        var verticalTraversal = solution.FindVertical(root);

        // Print the result
        Console.WriteLine("Vertical Traversal:");
        PrintResult(verticalTraversal);
    }
}
