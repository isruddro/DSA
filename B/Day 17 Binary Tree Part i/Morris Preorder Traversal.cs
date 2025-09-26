using System;
using System.Collections.Generic;

// TreeNode structure
public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    // Constructor to initialize the node with a value
    public TreeNode(int x)
    {
        Val = x;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    // Function to perform iterative Morris preorder traversal of a binary tree
    public List<int> GetPreorder(TreeNode root)
    {
        // List to store the preorder traversal result
        List<int> preorder = new List<int>();
        
        // Pointer to the current node, starting with the root
        TreeNode cur = root;

        // Iterate until the current node becomes NULL
        while (cur != null)
        {
            // If the current node has no left child
            if (cur.Left == null)
            {
                // Add the value of the current node to the preorder list
                preorder.Add(cur.Val);
                
                // Move to the right child
                cur = cur.Right;
            }
            else
            {
                // If the current node has a left child, find the rightmost node
                TreeNode prev = cur.Left;
                
                // Traverse to the rightmost node in the left subtree
                while (prev.Right != null && prev.Right != cur)
                {
                    prev = prev.Right;
                }
                
                // If the right child of the rightmost node is NULL
                if (prev.Right == null)
                {
                    // Set the right child of the rightmost node to the current node
                    prev.Right = cur;
                    
                    // Add the current node's value to the preorder list
                    preorder.Add(cur.Val);
                    
                    // Move to the left child
                    cur = cur.Left;
                }
                else
                {
                    // If the right child of the rightmost node is not NULL, remove the link
                    prev.Right = null;
                    
                    // Move to the right child
                    cur = cur.Right;
                }
            }
        }
        
        // Return the resulting preorder traversal list
        return preorder;
    }
}

class Program
{
    static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Left.Right.Right = new TreeNode(6);

        // Creating an instance of Solution
        Solution sol = new Solution();
        
        // Getting preorder traversal
        List<int> preorder = sol.GetPreorder(root);

        // Printing the preorder traversal result
        Console.Write("Binary Tree Morris Preorder Traversal: ");
        foreach (int val in preorder)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }
}
