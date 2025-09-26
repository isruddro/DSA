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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        // Base case: if root is null or root is one of p or q
        if (root == null || root == p || root == q)
        {
            return root;
        }

        // Recursively search in the left and right subtrees
        TreeNode left = LowestCommonAncestor(root.Left, p, q);
        TreeNode right = LowestCommonAncestor(root.Right, p, q);

        // If both left and right are not null, then root is the LCA
        if (left != null && right != null)
        {
            return root;
        }

        // If one side is null, return the non-null side (either left or right)
        return left ?? right;
    }
}

public class Program
{
    public static void Main()
    {
        // Example usage: creating a binary tree
        TreeNode root = new TreeNode(3);
        TreeNode node5 = new TreeNode(5);
        TreeNode node1 = new TreeNode(1);
        root.Left = node5;
        root.Right = node1;
        TreeNode node6 = new TreeNode(6);
        TreeNode node2 = new TreeNode(2);
        node5.Left = node6;
        node5.Right = node2;
        TreeNode node0 = new TreeNode(0);
        TreeNode node8 = new TreeNode(8);
        node1.Left = node0;
        node1.Right = node8;
        TreeNode node7 = new TreeNode(7);
        TreeNode node4 = new TreeNode(4);
        node2.Left = node7;
        node2.Right = node4;

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Example: Finding LCA of nodes 5 and 1
        TreeNode lca = solution.LowestCommonAncestor(root, node5, node1);
        Console.WriteLine("Lowest Common Ancestor: " + lca.Val); // Output: 3
    }
}
