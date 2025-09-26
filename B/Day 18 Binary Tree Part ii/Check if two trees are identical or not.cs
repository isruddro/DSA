using System;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public class Solution
{
    // Function to check if two binary trees are identical
    public bool IsIdentical(TreeNode node1, TreeNode node2)
    {
        // If both nodes are null, they are identical
        if (node1 == null && node2 == null)
        {
            return true;
        }

        // If one of the nodes is null, they are not identical
        if (node1 == null || node2 == null)
        {
            return false;
        }

        // Check if the current nodes have the same value
        // and recursively check their left and right subtrees
        return (node1.Val == node2.Val) &&
               IsIdentical(node1.Left, node2.Left) &&
               IsIdentical(node1.Right, node2.Right);
    }
}

public class Program
{
    public static void Main()
    {
        // Node1
        TreeNode root1 = new TreeNode(1);
        root1.Left = new TreeNode(2);
        root1.Right = new TreeNode(3);
        root1.Left.Left = new TreeNode(4);

        // Node2
        TreeNode root2 = new TreeNode(1);
        root2.Left = new TreeNode(2);
        root2.Right = new TreeNode(3);
        root2.Left.Left = new TreeNode(4);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Checking if the binary trees are identical
        if (solution.IsIdentical(root1, root2))
        {
            Console.WriteLine("The binary trees are identical.");
        }
        else
        {
            Console.WriteLine("The binary trees are not identical.");
        }
    }
}
