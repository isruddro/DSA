using System;
using System.Collections.Generic;

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
    // Function to perform zigzag level order traversal
    public IList<IList<int>> ZigZagLevelOrder(TreeNode root)
    {
        // List to store the result of zigzag traversal
        var result = new List<IList<int>>();

        // Check if the root is NULL, return an empty result
        if (root == null)
        {
            return result;
        }

        // Queue to perform level order traversal
        var nodesQueue = new Queue<TreeNode>();
        nodesQueue.Enqueue(root);

        // Flag to determine the direction of traversal (left to right or right to left)
        bool leftToRight = true;

        // Continue traversal until the queue is empty
        while (nodesQueue.Count > 0)
        {
            // Get the number of nodes at the current level
            int size = nodesQueue.Count;

            // List to store the values of nodes at the current level
            var row = new List<int>(size);

            // Traverse nodes at the current level
            for (int i = 0; i < size; i++)
            {
                // Get the front node from the queue
                TreeNode node = nodesQueue.Dequeue();

                // Determine the index to insert the node's value based on the traversal direction
                int index = leftToRight ? i : (size - 1 - i);

                // Insert the node's value at the determined index
                if (row.Count <= index)
                {
                    row.Add(node.Val);
                }
                else
                {
                    row[index] = node.Val;
                }

                // Enqueue the left and right children if they exist
                if (node.Left != null)
                {
                    nodesQueue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    nodesQueue.Enqueue(node.Right);
                }
            }

            // Switch the traversal direction for the next level
            leftToRight = !leftToRight;

            // Add the current level's values to the result list
            result.Add(row);
        }

        // Return the final result of zigzag level order traversal
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Right.Left = new TreeNode(6);
        root.Right.Right = new TreeNode(7);

        Solution solution = new Solution();

        // Get the zigzag level order traversal
        IList<IList<int>> result = solution.ZigZagLevelOrder(root);

        // Print the result
        PrintResult(result);
    }

    // Helper function to print the result
    public static void PrintResult(IList<IList<int>> result)
    {
        foreach (var row in result)
        {
            foreach (int val in row)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
