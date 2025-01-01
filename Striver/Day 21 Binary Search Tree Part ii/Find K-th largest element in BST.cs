BF:


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
    // Inorder traversal to populate the list with BST elements
    private void Inorder(TreeNode node, List<int> arr)
    {
        if (node == null)
            return;

        // Recursive call to the left subtree
        Inorder(node.Left, arr);

        // Add the value of the current node to the list
        arr.Add(node.Val);

        // Recursive call to the right subtree
        Inorder(node.Right, arr);
    }

    // Function to find the Kth smallest and largest elements in BST
    public Tuple<int, int> FindKth(TreeNode node, int k)
    {
        // List to store the elements of the BST
        List<int> arr = new List<int>();

        // Perform inorder traversal to populate the list
        Inorder(node, arr);

        // Calculate Kth largest and smallest elements
        int kLargest = arr[arr.Count - k];
        int kSmallest = arr[k - 1];

        // Returning a tuple containing the Kth smallest and largest elements
        return Tuple.Create(kSmallest, kLargest);
    }
}

class Program
{
    // Function to perform an in-order traversal and print the nodes of the BST
    static void PrintInOrder(TreeNode root)
    {
        if (root == null)
            return;

        // Recursively call PrintInOrder for the left subtree
        PrintInOrder(root.Left);

        // Print the value of the current node
        Console.Write(root.Val + " ");

        // Recursively call PrintInOrder for the right subtree
        PrintInOrder(root.Right);
    }

    static void Main()
    {
        // Creating a BST
        TreeNode root = new TreeNode(10);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(13);
        root.Left.Left = new TreeNode(3);
        root.Left.Left.Left = new TreeNode(2);
        root.Left.Left.Right = new TreeNode(4);
        root.Left.Right = new TreeNode(6);
        root.Left.Right.Right = new TreeNode(9);
        root.Right.Left = new TreeNode(11);
        root.Right.Right = new TreeNode(14);

        Console.WriteLine("Binary Search Tree: ");
        PrintInOrder(root);
        Console.WriteLine();

        Solution solution = new Solution();

        // Find the Kth smallest and largest elements
        int k = 3;
        Console.WriteLine("k: " + k);
        var kthElements = solution.FindKth(root, k);

        Console.WriteLine("Kth smallest element: " + kthElements.Item1);
        Console.WriteLine("Kth largest element: " + kthElements.Item2);
    }
}




Optimal:


using System;

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
    // Helper function to perform reverse inorder traversal to find Kth largest element
    private void ReverseInorder(TreeNode node, ref int counter, int k, ref int kLargest)
    {
        if (node == null || counter >= k)
            return;

        // Traverse right subtree
        ReverseInorder(node.Right, ref counter, k, ref kLargest);

        // Increment counter after visiting right subtree
        counter++;

        // Check if current node is the Kth largest
        if (counter == k)
        {
            kLargest = node.Val;
            return;
        }

        // Traverse left subtree if Kth largest is not found yet
        ReverseInorder(node.Left, ref counter, k, ref kLargest);
    }

    // Helper function to perform inorder traversal to find Kth smallest element
    private void Inorder(TreeNode node, ref int counter, int k, ref int kSmallest)
    {
        if (node == null || counter >= k)
            return;

        // Traverse left subtree
        Inorder(node.Left, ref counter, k, ref kSmallest);

        // Increment counter after visiting left subtree
        counter++;

        // Check if current node is the Kth smallest
        if (counter == k)
        {
            kSmallest = node.Val;
            return;
        }

        // Traverse right subtree if Kth smallest is not found yet
        Inorder(node.Right, ref counter, k, ref kSmallest);
    }

    public Tuple<int, int> FindKth(TreeNode root, int k)
    {
        int kSmallest = int.MinValue, kLargest = int.MinValue;
        // Counter to track visited nodes
        int counter = 0;

        // Find Kth smallest element (perform inorder traversal)
        Inorder(root, ref counter, k, ref kSmallest);

        // Reset counter for Kth largest element
        counter = 0;
        // Find Kth largest element (perform reverse inorder traversal)
        ReverseInorder(root, ref counter, k, ref kLargest);

        return Tuple.Create(kSmallest, kLargest);
    }
}

class Program
{
    // Function to perform an in-order traversal and print the nodes of the BST
    static void PrintInOrder(TreeNode root)
    {
        if (root == null)
            return;

        // Recursively call PrintInOrder for the left subtree
        PrintInOrder(root.Left);

        // Print the value of the current node
        Console.Write(root.Val + " ");

        // Recursively call PrintInOrder for the right subtree
        PrintInOrder(root.Right);
    }

    static void Main()
    {
        // Creating a BST
        TreeNode root = new TreeNode(10);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(13);
        root.Left.Left = new TreeNode(3);
        root.Left.Left.Left = new TreeNode(2);
        root.Left.Left.Right = new TreeNode(4);
        root.Left.Right = new TreeNode(6);
        root.Left.Right.Right = new TreeNode(9);
        root.Right.Left = new TreeNode(11);
        root.Right.Right = new TreeNode(14);

        Console.WriteLine("Binary Search Tree: ");
        PrintInOrder(root);
        Console.WriteLine();

        Solution solution = new Solution();

        // Find the Kth smallest and largest elements
        int k = 3;
        Console.WriteLine("k: " + k);
        var kthElements = solution.FindKth(root, k);

        Console.WriteLine("Kth smallest element: " + kthElements.Item1);
        Console.WriteLine("Kth largest element: " + kthElements.Item2);
    }
}
