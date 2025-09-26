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
    // Function to perform postorder traversal recursively
    public void Postorder(Node root, List<int> arr)
    {
        // Base case: if root is null, return
        if (root == null)
        {
            return;
        }

        // Traverse the left subtree
        Postorder(root.Left, arr);

        // Traverse the right subtree
        Postorder(root.Right, arr);

        // Visit the node (append node's data to the list)
        arr.Add(root.Data);
    }

    // Function to get the postorder traversal of a binary tree
    public List<int> PostOrder(Node root)
    {
        // Create a list to store the traversal result
        List<int> arr = new List<int>();

        // Perform postorder traversal starting from the root
        Postorder(root, arr);

        // Return the postorder traversal result
        return arr;
    }

    // Function to print the elements of a list
    public void PrintList(List<int> list)
    {
        // Iterate through the list and print each element
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
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

        // Getting postorder traversal
        List<int> result = tree.PostOrder(root);

        // Printing the postorder traversal result
        Console.Write("Postorder traversal: ");
        tree.PrintList(result);
    }
}
