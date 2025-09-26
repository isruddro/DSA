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

public class BinaryTree
{
    // Function to perform inorder traversal of the tree and store values in 'arr'
    public void Inorder(Node root, List<int> arr)
    {
        // If the current node is NULL (base case for recursion), return
        if (root == null)
        {
            return;
        }

        // Recursively traverse the left subtree
        Inorder(root.Left, arr);

        // Push the current node's value into the list
        arr.Add(root.Data);

        // Recursively traverse the right subtree
        Inorder(root.Right, arr);
    }

    // Function to initiate inorder traversal and return the resulting list
    public List<int> InOrder(Node root)
    {
        // Create an empty list to store inorder traversal values
        List<int> arr = new List<int>();

        // Call the inorder traversal function
        Inorder(root, arr);

        // Return the resulting list containing inorder traversal values
        return arr;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);

        // Creating an instance of BinaryTree
        BinaryTree tree = new BinaryTree();

        // Getting inorder traversal
        List<int> result = tree.InOrder(root);

        // Displaying the inorder traversal result
        Console.Write("Inorder Traversal: ");
        
        // Output each value in the inorder traversal result
        foreach (int val in result)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }
}
