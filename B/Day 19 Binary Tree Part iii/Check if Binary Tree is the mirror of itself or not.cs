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
    // Function to convert the binary tree to its mirror
    public void Mirror(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        // Swap the left and right children
        TreeNode temp = root.Left;
        root.Left = root.Right;
        root.Right = temp;

        // Recur for the left and right subtrees
        Mirror(root.Left);
        Mirror(root.Right);
    }
}

public class Program
{
    // Print the inorder traversal of the tree
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

    public static void Main(string[] args)
    {
        // Creating the binary tree
        TreeNode root = new TreeNode(10);
        root.Left = new TreeNode(20);
        root.Right = new TreeNode(30);
        root.Left.Left = new TreeNode(40);
        root.Left.Right = new TreeNode(60);

        Solution sol = new Solution();

        Console.Write("Original Tree Inorder: ");
        PrintInorder(root);
        Console.WriteLine();

        // Convert the tree to its mirror
        sol.Mirror(root);

        Console.Write("Mirror Tree Inorder: ");
        PrintInorder(root);
        Console.WriteLine();
    }
}
