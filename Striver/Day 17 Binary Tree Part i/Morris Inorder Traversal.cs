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
    // Function to perform iterative Morris inorder traversal of a binary tree
    public List<int> GetInorder(TreeNode root)
    {
        // List to store the inorder traversal result
        List<int> inorder = new List<int>();
        
        // Pointer to the current node, starting from the root
        TreeNode cur = root;
        
        // Loop until the current node is not NULL
        while (cur != null)
        {
            // If the current node's left child is NULL
            if (cur.Left == null)
            {
                // Add the value of the current node to the inorder list
                inorder.Add(cur.Val);
                // Move to the right child
                cur = cur.Right;
            }
            else
            {
                // If the left child is not NULL, find the predecessor (rightmost node in the left subtree)
                TreeNode prev = cur.Left;
                while (prev.Right != null && prev.Right != cur)
                {
                    prev = prev.Right;
                }
                
                // If the predecessor's right child is NULL, establish a temporary link and move to the left child
                if (prev.Right == null)
                {
                    prev.Right = cur;
                    cur = cur.Left;
                }
                else
                {
                    // If the predecessor's right child is already linked, remove the link,
                    // add the current node to the inorder list, and move to the right child
                    prev.Right = null;
                    inorder.Add(cur.Val);
                    cur = cur.Right;
                }
            }
        }
        
        // Return the inorder traversal result
        return inorder;
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
        
        // Getting inorder traversal
        List<int> inorder = sol.GetInorder(root);

        // Printing the inorder traversal result
        Console.Write("Binary Tree Morris Inorder Traversal: ");
        foreach (int val in inorder)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }
}
