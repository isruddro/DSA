using System;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int x)
    {
        this.Val = x;
        this.Left = null;
        this.Right = null;
    }
}

public class Solution
{
    // Function to modify the tree based on the sum of the children's values
    public void ChangeTree(TreeNode root)
    {
        // Base case: If the current node is NULL, return and do nothing.
        if (root == null)
        {
            return;
        }

        // Calculate the sum of the left and right children's values
        int childSum = 0;
        if (root.Left != null)
        {
            childSum += root.Left.Val;
        }
        if (root.Right != null)
        {
            childSum += root.Right.Val;
        }

        // Compare the sum of children with the current node's value and update
        if (childSum >= root.Val)
        {
            root.Val = childSum;
        }
        else
        {
            // If the sum is smaller, update the child with the current node's value.
            if (root.Left != null)
            {
                root.Left.Val = root.Val;
            }
            else if (root.Right != null)
            {
                root.Right.Val = root.Val;
            }
        }

        // Recursively call the function on the left and right children.
        ChangeTree(root.Left);
        ChangeTree(root.Right);

        // Calculate the total sum of the left and right children
        int totalSum = 0;
        if (root.Left != null)
        {
            totalSum += root.Left.Val;
        }
        if (root.Right != null)
        {
            totalSum += root.Right.Val;
        }

        // If either left or right child exists, update the current node's value with the total sum.
        if (root.Left != null || root.Right != null)
        {
            root.Val = totalSum;
        }
    }
}

public class Program
{
    // Function to print the inorder traversal of the tree
    public static void InorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        InorderTraversal(root.Left);
        Console.Write(root.Val + " ");
        InorderTraversal(root.Right);
    }

    public static void Main(string[] args)
    {
        // Create the binary tree
        TreeNode root = new TreeNode(3);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(1);
        root.Left.Left = new TreeNode(6);
        root.Left.Right = new TreeNode(2);
        root.Right.Left = new TreeNode(0);
        root.Right.Right = new TreeNode(8);
        root.Left.Right.Left = new TreeNode(7);
        root.Left.Right.Right = new TreeNode(4);

        Solution sol = new Solution();

        // Print the inorder traversal before modification
        Console.Write("Binary Tree before modification: ");
        InorderTraversal(root);
        Console.WriteLine();

        // Call the changeTree function to modify the binary tree
        sol.ChangeTree(root);

        // Print the inorder traversal after modification
        Console.Write("Binary Tree after Children Sum Property: ");
        InorderTraversal(root);
        Console.WriteLine();
    }
}
