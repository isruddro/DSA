using System;
using System.Collections.Generic;

// Node structure for the binary tree
public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    // Constructor to initialize the node with a value
    public Node(int val)
    {
        Data = val;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    // Function to get the Preorder, Inorder, and Postorder traversal
    // Of Binary Tree in One traversal
    public List<List<int>> PreInPostTraversal(Node root)
    {
        // Lists to store traversals
        List<int> pre = new List<int>();
        List<int> inOrder = new List<int>();
        List<int> post = new List<int>();

        // If the tree is empty, return empty traversals
        if (root == null)
        {
            return new List<List<int>> { pre, inOrder, post };
        }

        // Stack to maintain nodes and their traversal state
        Stack<KeyValuePair<Node, int>> st = new Stack<KeyValuePair<Node, int>>();

        // Start with the root node and state 1 (preorder)
        st.Push(new KeyValuePair<Node, int>(root, 1));

        while (st.Count > 0)
        {
            var it = st.Pop();

            // This is part of preorder
            if (it.Value == 1)
            {
                // Store the node's data in the preorder traversal
                pre.Add(it.Key.Data);
                // Move to state 2 (inorder) for this node
                it = new KeyValuePair<Node, int>(it.Key, 2);
                st.Push(it); // Push the updated state back onto the stack

                // Push left child onto the stack for processing
                if (it.Key.Left != null)
                {
                    st.Push(new KeyValuePair<Node, int>(it.Key.Left, 1));
                }
            }

            // This is part of inorder
            else if (it.Value == 2)
            {
                // Store the node's data in the inorder traversal
                inOrder.Add(it.Key.Data);
                // Move to state 3 (postorder) for this node
                it = new KeyValuePair<Node, int>(it.Key, 3);
                st.Push(it); // Push the updated state back onto the stack

                // Push right child onto the stack for processing
                if (it.Key.Right != null)
                {
                    st.Push(new KeyValuePair<Node, int>(it.Key.Right, 1));
                }
            }

            // This is part of postorder
            else
            {
                // Store the node's data in the postorder traversal
                post.Add(it.Key.Data);
            }
        }

        // Returning the traversals as a list of lists
        return new List<List<int>> { pre, inOrder, post };
    }
}

// Main function
class Program
{
    static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);

        Solution solution = new Solution();

        // Getting the pre-order, in-order, and post-order traversals
        List<List<int>> traversals = solution.PreInPostTraversal(root);

        // Extracting the traversals from the result
        List<int> pre = traversals[0];
        List<int> inOrder = traversals[1];
        List<int> post = traversals[2];

        // Printing the traversals
        Console.WriteLine("Preorder traversal: " + string.Join(" ", pre));
        Console.WriteLine("Inorder traversal: " + string.Join(" ", inOrder));
        Console.WriteLine("Postorder traversal: " + string.Join(" ", post));
    }
}
