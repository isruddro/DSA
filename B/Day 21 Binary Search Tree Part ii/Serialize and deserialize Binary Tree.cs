using System;
using System.Collections.Generic;
using System.Text;

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
    // Encodes the tree into a single string
    public string Serialize(TreeNode root)
    {
        if (root == null)
        {
            return "";
        }

        StringBuilder sb = new StringBuilder();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            TreeNode curNode = q.Dequeue();

            if (curNode == null)
            {
                sb.Append("#,");
            }
            else
            {
                sb.Append(curNode.Val + ",");
                q.Enqueue(curNode.Left);
                q.Enqueue(curNode.Right);
            }
        }

        return sb.ToString();
    }

    // Decodes the encoded data to a tree
    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] values = data.Split(',');
        int index = 0;
        TreeNode root = new TreeNode(int.Parse(values[index++]));

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            TreeNode node = q.Dequeue();

            // Deserialize the left child
            if (values[index] != "#")
            {
                TreeNode leftNode = new TreeNode(int.Parse(values[index]));
                node.Left = leftNode;
                q.Enqueue(leftNode);
            }
            index++;

            // Deserialize the right child
            if (values[index] != "#")
            {
                TreeNode rightNode = new TreeNode(int.Parse(values[index]));
                node.Right = rightNode;
                q.Enqueue(rightNode);
            }
            index++;
        }

        return root;
    }
}

// Function to perform an in-order traversal of a binary tree and print its nodes
public class Program
{
    public static void InOrder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        InOrder(root.Left);
        Console.Write(root.Val + " ");
        InOrder(root.Right);
    }

    public static void Main()
    {
        // Create a sample binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Right.Left = new TreeNode(4);
        root.Right.Right = new TreeNode(5);

        Solution solution = new Solution();
        
        // Print the original tree (in-order traversal)
        Console.Write("Original Tree: ");
        InOrder(root);
        Console.WriteLine();

        // Serialize the tree
        string serialized = solution.Serialize(root);
        Console.WriteLine("Serialized: " + serialized);

        // Deserialize the tree
        TreeNode deserialized = solution.Deserialize(serialized);

        // Print the deserialized tree (in-order traversal)
        Console.Write("Tree after deserialization: ");
        InOrder(deserialized);
        Console.WriteLine();
    }
}
