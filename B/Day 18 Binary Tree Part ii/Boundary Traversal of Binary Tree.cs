using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public class Solution
{
    // Function to check if a node is a leaf
    public bool IsLeaf(TreeNode root)
    {
        return root.Left == null && root.Right == null;
    }

    // Function to add the left boundary of the tree
    public void AddLeftBoundary(TreeNode root, List<int> res)
    {
        TreeNode curr = root.Left;
        while (curr != null)
        {
            // If the current node is not a leaf, add its value to the result
            if (!IsLeaf(curr))
            {
                res.Add(curr.Val);
            }
            // Move to the left child if it exists, otherwise move to the right child
            curr = curr.Left ?? curr.Right;
        }
    }

    // Function to add the right boundary of the tree
    public void AddRightBoundary(TreeNode root, List<int> res)
    {
        TreeNode curr = root.Right;
        List<int> temp = new List<int>();
        while (curr != null)
        {
            // If the current node is not a leaf, add its value to a temporary list
            if (!IsLeaf(curr))
            {
                temp.Add(curr.Val);
            }
            // Move to the right child if it exists, otherwise move to the left child
            curr = curr.Right ?? curr.Left;
        }
        // Reverse and add the values from the temporary list to the result
        temp.Reverse();
        res.AddRange(temp);
    }

    // Function to add the leaves of the tree
    public void AddLeaves(TreeNode root, List<int> res)
    {
        // If the current node is a leaf, add its value to the result
        if (IsLeaf(root))
        {
            res.Add(root.Val);
            return;
        }
        // Recursively add leaves of the left and right subtrees
        if (root.Left != null)
        {
            AddLeaves(root.Left, res);
        }
        if (root.Right != null)
        {
            AddLeaves(root.Right, res);
        }
    }

    // Main function to perform the boundary traversal of the binary tree
    public List<int> PrintBoundary(TreeNode root)
    {
        List<int> res = new List<int>();
        if (root == null)
        {
            return res;
        }
        // If the root is not a leaf, add its value to the result
        if (!IsLeaf(root))
        {
            res.Add(root.Val);
        }

        // Add the left boundary, leaves, and right boundary in order
        AddLeftBoundary(root, res);
        AddLeaves(root, res);
        AddRightBoundary(root, res);

        return res;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Right.Left = new TreeNode(6);
        root.Right.Right = new TreeNode(7);

        Solution solution = new Solution();

        // Get the boundary traversal
        List<int> result = solution.PrintBoundary(root);

        // Print the result
        Console.WriteLine("Boundary Traversal: " + string.Join(" ", result));
    }
}
