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
    // Function to build a binary tree
    // from preorder and inorder traversals
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        // Create a map to store indices of elements in the inorder traversal
        Dictionary<int, int> inMap = new Dictionary<int, int>();

        // Populate the map with indices of elements in the inorder traversal
        for (int i = 0; i < inorder.Length; i++)
        {
            inMap[inorder[i]] = i;
        }

        // Call the private helper function to recursively build the tree
        return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inMap);
    }

    // Recursive helper function to build the tree
    private TreeNode BuildTree(int[] preorder, int preStart, int preEnd,
            int[] inorder, int inStart, int inEnd, Dictionary<int, int> inMap)
    {
        // Base case: If the start indices exceed the end indices, return null
        if (preStart > preEnd || inStart > inEnd)
        {
            return null;
        }

        // Create a new TreeNode with value at the current preorder index
        TreeNode root = new TreeNode(preorder[preStart]);

        // Find the index of the current root value in the inorder traversal
        int inRoot = inMap[root.Val];

        // Calculate the number of elements in the left subtree
        int numsLeft = inRoot - inStart;

        // Recursively build the left subtree
        root.Left = BuildTree(preorder, preStart + 1, preStart + numsLeft,
                inorder, inStart, inRoot - 1, inMap);

        // Recursively build the right subtree
        root.Right = BuildTree(preorder, preStart + numsLeft + 1, preEnd,
                inorder, inRoot + 1, inEnd, inMap);

        // Return the current root node
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

    // Function to print the given array
    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] inorder = { 9, 3, 15, 20, 7 };
        int[] preorder = { 3, 9, 20, 15, 7 };

        Console.Write("Inorder Array: ");
        PrintArray(inorder);

        Console.Write("Preorder Array: ");
        PrintArray(preorder);

        Solution sol = new Solution();

        TreeNode root = sol.BuildTree(preorder, inorder);

        Console.WriteLine("Inorder of the Unique Binary Tree Created:");
        PrintInorder(root);
        Console.WriteLine();
    }
}
