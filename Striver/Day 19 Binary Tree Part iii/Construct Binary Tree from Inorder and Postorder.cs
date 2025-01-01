using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode() { }

    public TreeNode(int val) { this.Val = val; }

    public TreeNode(int val, TreeNode left, TreeNode right)
    {
        this.Val = val;
        this.Left = left;
        this.Right = right;
    }
}

public class Solution
{
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        // Create a dictionary to map values to their indices in inorder array
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            map[inorder[i]] = i;
        }

        // Call the helper function to recursively build the tree
        return Helper(map, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
    }

    private TreeNode Helper(Dictionary<int, int> map, int[] postorder, int inLeft, int inRight, int poLeft, int poRight)
    {
        if (inLeft > inRight)
        {
            return null;
        }

        // The root of the current subtree is the last element in the postorder range
        TreeNode root = new TreeNode(postorder[poRight]);
        
        // Find the root's index in the inorder array
        int inMid = map[root.Val];

        // Recursively build the left subtree
        root.Left = Helper(map, postorder, inLeft, inMid - 1, poLeft, poLeft + inMid - inLeft - 1);

        // Recursively build the right subtree
        root.Right = Helper(map, postorder, inMid + 1, inRight, poRight - inRight + inMid, poRight - 1);

        return root;
    }
}

public class Program
{
    // Function to print the inorder traversal of a tree
    public static void PrintInorder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        PrintInorder(root.Left);
        Console.Write(root.Val + " ");
        PrintInorder(root.Right);
    }

    public static void Main()
    {
        int[] inorder = { 9, 3, 15, 20, 7 };
        int[] postorder = { 9, 15, 7, 20, 3 };

        Solution sol = new Solution();

        TreeNode root = sol.BuildTree(inorder, postorder);

        Console.WriteLine("Inorder of the Binary Tree Created:");
        PrintInorder(root);
        Console.WriteLine();
    }
}
