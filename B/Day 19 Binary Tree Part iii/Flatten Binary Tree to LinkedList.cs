BF:

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
    // Initialize a global variable 'prev' to keep track of the previously processed node
    private TreeNode prev = null;

    // Function to flatten a binary tree to a right-next Linked List structure
    public void Flatten(TreeNode root)
    {
        // Base case: If the current node is NULL, return
        if (root == null)
        {
            return;
        }

        // Recursive call to flatten the right subtree
        Flatten(root.Right);

        // Recursive call to flatten the left subtree
        Flatten(root.Left);

        // At this point, both left and right subtrees are flattened,
        // and 'prev' is pointing to the rightmost node in the flattened right subtree

        // Set the right child of the current node to 'prev'
        root.Right = prev;

        // Set the left child of the current node to NULL
        root.Left = null;

        // Update 'prev' to the current node for the next iteration
        prev = root;
    }
}

public class Program
{
    // Print the preorder traversal of the Original Binary Tree
    public static void PrintPreorder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintPreorder(root.Left);
        PrintPreorder(root.Right);
    }

    // Print the Binary Tree along the Right Pointers after Flattening
    public static void PrintFlattenTree(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintFlattenTree(root.Right);
    }

    public static void Main(string[] args)
    {
        // Creating the binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Left.Right.Right = new TreeNode(6);
        root.Right.Right = new TreeNode(7);
        root.Right.Left = new TreeNode(8);

        Solution sol = new Solution();

        Console.Write("Binary Tree Preorder: ");
        PrintPreorder(root);
        Console.WriteLine();

        sol.Flatten(root);

        Console.Write("Binary Tree After Flatten: ");
        PrintFlattenTree(root);
        Console.WriteLine();
    }
}



Better:


using System;
using System.Collections.Generic;

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
    // Function to flatten a binary tree to a right-next Linked List structure
    public void Flatten(TreeNode root)
    {
        // Base case: If the current node is NULL, return
        if (root == null)
        {
            return;
        }

        // Use a stack for iterative traversal
        Stack<TreeNode> st = new Stack<TreeNode>();

        // Push the root node onto the stack
        st.Push(root);

        // Continue the loop until the stack is empty
        while (st.Count > 0)
        {
            // Get the top node from the stack
            TreeNode cur = st.Pop();

            // If the right child exists, push it onto the stack
            if (cur.Right != null)
            {
                st.Push(cur.Right);
            }

            // If the left child exists, push it onto the stack
            if (cur.Left != null)
            {
                st.Push(cur.Left);
            }

            // If the stack is not empty, connect the right child to the next node in the stack
            if (st.Count > 0)
            {
                cur.Right = st.Peek();
            }

            // Set the left child to null to form a right-oriented linked list
            cur.Left = null;
        }
    }
}

public class Program
{
    // Print the preorder traversal of the Original Binary Tree
    public static void PrintPreorder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintPreorder(root.Left);
        PrintPreorder(root.Right);
    }

    // Print the Binary Tree along the Right Pointers after Flattening
    public static void PrintFlattenTree(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintFlattenTree(root.Right);
    }

    public static void Main(string[] args)
    {
        // Creating the binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Left.Right.Right = new TreeNode(6);
        root.Right.Right = new TreeNode(7);
        root.Right.Left = new TreeNode(8);

        Solution sol = new Solution();

        Console.Write("Binary Tree Preorder: ");
        PrintPreorder(root);
        Console.WriteLine();

        sol.Flatten(root);

        Console.Write("Binary Tree After Flatten: ");
        PrintFlattenTree(root);
        Console.WriteLine();
    }
}




Optimal:


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
    // Function to flatten a binary tree to a right-next Linked List structure
    public void Flatten(TreeNode root)
    {
        // Initialize a pointer 'curr' to the root of the tree
        TreeNode curr = root;

        // Iterate until 'curr' becomes NULL
        while (curr != null)
        {
            // Check if the current node has a left child
            if (curr.Left != null)
            {
                // If yes, find the rightmost node in the left subtree
                TreeNode pre = curr.Left;
                while (pre.Right != null)
                {
                    pre = pre.Right;
                }

                // Connect the rightmost node in the left subtree to the current node's right child
                pre.Right = curr.Right;

                // Move the entire left subtree to the right child of the current node
                curr.Right = curr.Left;

                // Set the left child of the current node to NULL
                curr.Left = null;
            }

            // Move to the next node on the right side
            curr = curr.Right;
        }
    }
}

public class Program
{
    // Print the preorder traversal of the Original Binary Tree
    public static void PrintPreorder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintPreorder(root.Left);
        PrintPreorder(root.Right);
    }

    // Print the Binary Tree along the Right Pointers after Flattening
    public static void PrintFlattenTree(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.Val + " ");
        PrintFlattenTree(root.Right);
    }

    public static void Main(string[] args)
    {
        // Creating the binary tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Left.Right.Right = new TreeNode(6);
        root.Right.Right = new TreeNode(7);
        root.Right.Left = new TreeNode(8);

        Solution sol = new Solution();

        Console.Write("Binary Tree Preorder: ");
        PrintPreorder(root);
        Console.WriteLine();

        sol.Flatten(root);

        Console.Write("Binary Tree After Flatten: ");
        PrintFlattenTree(root);
        Console.WriteLine();
    }
}
