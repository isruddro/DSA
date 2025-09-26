using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int x)
    {
        Val = x;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    // Function to find the path from the root to a given node with value 'x'
    public bool GetPath(TreeNode root, List<int> path, int x)
    {
        // Base case: If the current node is null, return false
        if (root == null)
        {
            return false;
        }

        // Add the current node's value to the path list
        path.Add(root.Val);

        // If the current node's value is equal to the target value 'x', return true
        if (root.Val == x)
        {
            return true;
        }

        // Recursively search for the target value 'x' in the left and right subtrees
        if (GetPath(root.Left, path, x) || GetPath(root.Right, path, x))
        {
            return true;
        }

        // If the target value 'x' is not found in the current path, backtrack
        path.RemoveAt(path.Count - 1);
        return false;
    }

    // Function to find and return the path from the root to a given node with value 'B'
    public List<int> Solve(TreeNode root, int B)
    {
        // Initialize an empty list to store the path
        List<int> path = new List<int>();

        // If the root node is null, return the empty path list
        if (root == null)
        {
            return path;
        }

        // Call the GetPath function to find the path to the node with value 'B'
        GetPath(root, path, B);

        // Return the path list
        return path;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(3);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(1);
        root.Left.Left = new TreeNode(6);
        root.Left.Right = new TreeNode(2);
        root.Right.Left = new TreeNode(0);
        root.Right.Right = new TreeNode(8);
        root.Left.Right.Left = new TreeNode(7);
        root.Left.Right.Right = new TreeNode(4);

        Solution solution = new Solution();

        int targetLeafValue = 7;

        // Get the path from root to leaf with the given value
        List<int> path = solution.Solve(root, targetLeafValue);

        // Print the path
        Console.WriteLine("Path from root to leaf with value " + targetLeafValue + ":");
        for (int i = 0; i < path.Count; i++)
        {
            Console.Write(path[i]);
            if (i < path.Count - 1)
            {
                Console.Write(" -> ");
            }
        }
        Console.WriteLine();
    }
}
