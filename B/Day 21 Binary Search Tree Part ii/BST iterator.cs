using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int x)
    {
        Val = x;
        Left = null;
        Right = null;
    }
}

public class BSTIterator
{
    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root)
    {
        stack = new Stack<TreeNode>();
        TreeNode cur = root;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.Left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext()
    {
        return stack.Count > 0;
    }

    /** @return the next smallest number */
    public int Next()
    {
        TreeNode node = stack.Pop();

        // Traversal of the current node's right branch
        TreeNode cur = node.Right;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.Left;
        }

        return node.Val;
    }
}

class Program
{
    static void Main()
    {
        // Create a sample BST for testing
        TreeNode root = new TreeNode(7);
        root.Left = new TreeNode(3);
        root.Right = new TreeNode(15);
        root.Right.Left = new TreeNode(9);
        root.Right.Right = new TreeNode(20);

        // Create the BSTIterator object
        BSTIterator iterator = new BSTIterator(root);

        // Use the iterator to get the elements in sorted order
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}
