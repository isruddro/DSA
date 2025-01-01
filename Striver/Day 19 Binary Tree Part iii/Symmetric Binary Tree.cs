using System;

public class TreeNode
{
    public int Data;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int val)
    {
        this.Data = val;
        this.Left = null;
        this.Right = null;
    }
}

public class Solution
{
    // Function to check if two subtrees are symmetric
    private bool IsSymmetricUtil(TreeNode root1, TreeNode root2)
    {
        // If either subtree is NULL, return true if both are NULL
        if (root1 == null || root2 == null)
        {
            return root1 == root2;
        }

        // Check if the data in the current nodes is equal
        // and recursively check for symmetry in subtrees
        return (root1.Data == root2.Data)
            && IsSymmetricUtil(root1.Left, root2.Right)
            && IsSymmetricUtil(root1.Right, root2.Left);
    }

    // Public function to check if the entire binary tree is symmetric
    public bool IsSymmetric(TreeNode root)
    {
        // An empty tree is considered symmetric
        if (root == null)
        {
            return true;
        }

        // Call the utility function to check symmetry of subtrees
        return IsSymmetricUtil(root.Left, root.Right);
    }
}

public class Program
{
    // Function to print the Inorder Traversal of the Binary Tree
    public static void PrintInorder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        PrintInorder(root.Left);
        Console.Write(root.Data + " ");
        PrintInorder(root.Right);
    }

    public static void Main(string[] args)
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(2);
        root.Left.Left = new TreeNode(3);
        root.Right.Right = new TreeNode(3);
        root.Left.Right = new TreeNode(4);
        root.Right.Left = new TreeNode(4);

        Solution solution = new Solution();
        
        Console.Write("Binary Tree (Inorder): ");
        PrintInorder(root);
        Console.WriteLine();

        bool res = solution.IsSymmetric(root);
        
        if (res)
        {
            Console.WriteLine("This Tree is Symmetrical");
        }
        else
        {
            Console.WriteLine("This Tree is NOT Symmetrical");
        }
    }
}
