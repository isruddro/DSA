BF:


using System;
using System.Collections.Generic;

// Definition of TreeNode structure for a binary tree node
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    // Constructor to initialize the node with a value and set left and right pointers to null
    public TreeNode(int x) {
        val = x;
        left = null;
        right = null;
    }
}

public class Solution {
    // Inorder traversal to populate the list with BST elements
    private void Inorder(TreeNode node, List<int> arr) {
        if (node == null) {
            return;
        }
        // Recursive call to the left subtree
        Inorder(node.left, arr);

        // Add the value of the current node into the list
        arr.Add(node.val);

        // Recursive call to the right subtree
        Inorder(node.right, arr);
    }

    // Function to find the Kth smallest and largest elements in BST
    public Tuple<int, int> FindKth(TreeNode node, int k) {
        // List to store the elements of the BST
        List<int> arr = new List<int>();

        // Perform inorder traversal to populate the list
        Inorder(node, arr);

        // Calculate Kth largest and smallest elements
        int kLargest = arr[arr.Count - k];
        int kSmallest = arr[k - 1];

        // Returning a tuple containing Kth smallest and largest elements
        return Tuple.Create(kSmallest, kLargest);
    }
}

// Function to perform an in-order traversal of a binary tree and print its nodes
public class Program {
    public static void PrintInOrder(TreeNode root) {
        // Check if the current node is null (base case for recursion)
        if (root == null) {
            return;
        }

        // Recursively call PrintInOrder for the left subtree
        PrintInOrder(root.left);

        // Print the value of the current node
        Console.Write(root.val + " ");

        // Recursively call PrintInOrder for the right subtree
        PrintInOrder(root.right);
    }

    public static void Main() {
        // Creating a BST
        TreeNode root = new TreeNode(10);
        root.left = new TreeNode(5);
        root.right = new TreeNode(13);
        root.left.left = new TreeNode(3);
        root.left.left.left = new TreeNode(2);
        root.left.left.right = new TreeNode(4);
        root.left.right = new TreeNode(6);
        root.left.right.right = new TreeNode(9);
        root.right.left = new TreeNode(11);
        root.right.right = new TreeNode(14);

        Console.WriteLine("Binary Search Tree:");
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
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    // Constructor to initialize the node with a value and set left and right pointers to null
    public TreeNode(int x) {
        val = x;
        left = null;
        right = null;
    }
}

public class Solution {
    // Helper function to perform reverse inorder traversal to find Kth largest element
    private void ReverseInorder(TreeNode node, ref int counter, int k, ref int kLargest) {
        if (node == null || counter >= k) return;

        // Traverse right subtree
        ReverseInorder(node.right, ref counter, k, ref kLargest);

        // Increment counter after visiting right subtree
        counter++;

        // Check if current node is the Kth largest
        if (counter == k) {
            kLargest = node.val;
            return;
        }

        // Traverse left subtree if Kth largest is not found yet
        ReverseInorder(node.left, ref counter, k, ref kLargest);
    }

    // Helper function to perform inorder traversal to find Kth smallest element
    private void Inorder(TreeNode node, ref int counter, int k, ref int kSmallest) {
        if (node == null || counter >= k) return;

        // Traverse left subtree
        Inorder(node.left, ref counter, k, ref kSmallest);

        // Increment counter after visiting left subtree
        counter++;

        // Check if current node is the Kth smallest
        if (counter == k) {
            kSmallest = node.val;
            return;
        }

        // Traverse right subtree if Kth smallest is not found yet
        Inorder(node.right, ref counter, k, ref kSmallest);
    }

    // Function to find the Kth smallest and largest elements in BST
    public Tuple<int, int> FindKth(TreeNode root, int k) {
        int kSmallest = int.MinValue, kLargest = int.MinValue;
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

// Function to perform an in-order traversal of a binary tree and print its nodes
public class Program {
    public static void PrintInOrder(TreeNode root) {
        // Check if the current node is null (base case for recursion)
        if (root == null) {
            return;
        }

        // Recursively call PrintInOrder for the left subtree
        PrintInOrder(root.left);

        // Print the value of the current node
        Console.Write(root.val + " ");

        // Recursively call PrintInOrder for the right subtree
        PrintInOrder(root.right);
    }

    public static void Main() {
        // Creating a BST
        TreeNode root = new TreeNode(10);
        root.left = new TreeNode(5);
        root.right = new TreeNode(13);
        root.left.left = new TreeNode(3);
        root.left.left.left = new TreeNode(2);
        root.left.left.right = new TreeNode(4);
        root.left.right = new TreeNode(6);
        root.left.right.right = new TreeNode(9);
        root.right.left = new TreeNode(11);
        root.right.right = new TreeNode(14);

        Console.WriteLine("Binary Search Tree:");
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
