using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return root;
        }

        // Initialize a queue to perform level-order traversal
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node prev = null;
            int levelSize = queue.Count;

            // Process nodes at the current level
            for (int i = 0; i < levelSize; i++)
            {
                Node currentNode = queue.Dequeue();

                // If prev node exists, connect its next pointer to the current node
                if (prev != null)
                {
                    prev.next = currentNode;
                }

                // Move the prev pointer to the current node
                prev = currentNode;

                // Enqueue the left and right children, if they exist
                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }
        }

        return root;
    }
}
