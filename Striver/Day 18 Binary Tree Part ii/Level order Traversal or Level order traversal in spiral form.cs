using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    // Default constructor for TreeNode
    public TreeNode() 
    { 
        Val = 0; 
        Left = null; 
        Right = null; 
    }

    // Constructor with value parameter for TreeNode
    public TreeNode(int x) 
    { 
        Val = x; 
        Left = null; 
        Right = null; 
    }

    // Constructor with value, left child, and right child parameters for TreeNode
    public TreeNode(int x, TreeNode left, TreeNode right) 
    { 
        Val = x; 
        Left = left; 
        Right = right; 
    }
}

public class Solution
{
    // Function to perform level-order traversal of a binary tree
    public List<List<int>> LevelOrder(TreeNode root)
    {
        // Create a 2D list to store levels
        List<List<int>> ans = new List<List<int>>();
        if (root == null)
        {
            // If the tree is empty, return an empty list
            return ans;
        }

        // Create a queue to store nodes for level-order traversal
        Queue<TreeNode> q = new Queue<TreeNode>();
        // Push the root node to the queue
        q.Enqueue(root);

        while (q.Count > 0)
        {
            // Get the size of the current level
            int size = q.Count;
            // Create a list to store nodes at the current level
            List<int> level = new List<int>();

            for (int i = 0; i < size; i++)
            {
                // Get the front node in the queue
                TreeNode node = q.Dequeue();
                // Store the node value in the current level list
                level.Add(node.Val);

                // Enqueue the child nodes if they exist
                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }

            // Store the current level in the answer list
            ans.Add(level);
        }

        // Return the level-order traversal of the tree
        return ans;
    }
}

public class Program
{
    // Function to print the elements of a list
    public static void PrintList(List<int> list)
    {
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        // Creating a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);

        // Create an instance of the Solution class
        Solution solution = new Solution();
        // Perform level-order traversal
        List<List<int>> result = solution.LevelOrder(root);

        Console.WriteLine("Level Order Traversal of Tree: ");
        
        // Printing the level order traversal result
        foreach (List<int> level in result)
        {
            PrintList(level);
        }
    }
}
