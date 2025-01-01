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
    // Function to perform preorder traversal of the tree and store values in 'arr'
    public void Preorder(Node root, List<int> arr)
    {
        // If the current node is NULL (base case for recursion), return
        if (root == null)
        {
            return;
        }

        // Push the current node's value into the list
        arr.Add(root.Data);

        // Recursively traverse the left subtree
        Preorder(root.Left, arr);

        // Recursively traverse the right subtree
        Preorder(root.Right, arr);
    }

    // Function to initiate preorder traversal and return the resulting list
    public List<int> PreOrder(Node root)
    {
        // Create an empty list to store preorder traversal values
        List<int> arr = new List<int>();

        // Call the preorder traversal function
        Preorder(root, arr);

        // Return the resulting list containing preorder traversal values
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

        // Getting preorder traversal
        List<int> result = tree.PreOrder(root);

        // Displaying the preorder traversal result
        Console.Write("Preorder Traversal: ");
        
        // Output each value in the preorder traversal result
        foreach (int val in result)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }
}
