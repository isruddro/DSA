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

public class Solution
{
    // Function to find the maximum width of the Binary Tree
    public int WidthOfBinaryTree(TreeNode root)
    {
        // If the root is null, the width is zero
        if (root == null)
        {
            return 0;
        }

        // Initialize a variable 'ans' to store the maximum width
        int ans = 0;

        // Create a queue to perform level-order traversal,
        // where each element is a pair of TreeNode and its position in the level
        Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();

        // Push the root node and its position (0) into the queue
        queue.Enqueue(Tuple.Create(root, 0));

        // Perform level-order traversal
        while (queue.Count > 0)
        {
            // Get the number of nodes at the current level
            int size = queue.Count;

            // Get the position of the front node in the current level
            int mmin = queue.Peek().Item2;

            // Store the first and last positions of nodes in the current level
            int first = 0, last = 0;

            // Process each node in the current level
            for (int i = 0; i < size; i++)
            {
                // Calculate current position relative to the minimum position in the level
                int curId = queue.Peek().Item2 - mmin;

                // Get the current node
                TreeNode node = queue.Peek().Item1;
                queue.Dequeue();

                // If this is the first node in the level, update the 'first' variable
                if (i == 0)
                {
                    first = curId;
                }

                // If this is the last node in the level, update the 'last' variable
                if (i == size - 1)
                {
                    last = curId;
                }

                // Enqueue the left child of the current node with its position
                if (node.Left != null)
                {
                    queue.Enqueue(Tuple.Create(node.Left, curId * 2 + 1));
                }

                // Enqueue the right child of the current node with its position
                if (node.Right != null)
                {
                    queue.Enqueue(Tuple.Create(node.Right, curId * 2 + 2));
                }
            }

            // Update the maximum width by calculating the difference between the first and last
            // positions, and adding 1
            ans = Math.Max(ans, last - first + 1);
        }

        // Return the maximum width of the binary tree
        return ans;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(3);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(1);
        root.Left.Left = new TreeNode(6);
        root.Left.Right = new TreeNode(2);
        root.Right.Left = new TreeNode(0);
        root.Right.Right = new TreeNode(8);
        root.Left.Right.Left = new TreeNode(7);
        root.Left.Right.Right = new TreeNode(4);

        Solution solution = new Solution();

        // Get the maximum width of the binary tree
        int maxWidth = solution.WidthOfBinaryTree(root);

        // Print the result
        Console.WriteLine("Maximum width of the binary tree is: " + maxWidth);
    }
}
