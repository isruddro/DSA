BF:


using System;

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
    // Global variable to store the diameter
    private int diameter = 0;

    // Function to calculate the height of a subtree
    public int CalculateHeight(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        // Recursively calculate the height of the left and right subtrees
        int leftHeight = CalculateHeight(node.Left);
        int rightHeight = CalculateHeight(node.Right);

        // Calculate the diameter at the current node and update the global variable
        diameter = Math.Max(diameter, leftHeight + rightHeight);

        // Return the height of the current subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    // Function to find the diameter of the binary tree
    public int DiameterOfBinaryTree(Node root)
    {
        // Start the recursive traversal from the root
        CalculateHeight(root);

        // Return the maximum diameter found during traversal
        return diameter;
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);
        root.Left.Right.Right = new Node(6);
        root.Left.Right.Right.Right = new Node(7);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Calculate the diameter of the binary tree
        int diameter = solution.DiameterOfBinaryTree(root);

        Console.WriteLine("The diameter of the binary tree is: " + diameter);
    }
}




Optimal:


using System;

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
    // Function to find the diameter of a binary tree
    public int DiameterOfBinaryTree(Node root)
    {
        // Initialize the variable to store the diameter of the tree
        int diameter = 0;
        // Call the height function to traverse the tree and calculate diameter
        Height(root, ref diameter);
        // Return the calculated diameter
        return diameter;
    }

    // Function to calculate the height of the tree and update the diameter
    private int Height(Node node, ref int diameter)
    {
        // Base case: If the node is null, return 0 indicating the height of an empty tree
        if (node == null)
        {
            return 0;
        }

        // Recursively calculate the height of the left and right subtrees
        int leftHeight = Height(node.Left, ref diameter);
        int rightHeight = Height(node.Right, ref diameter);

        // Update the diameter with the maximum of current diameter or sum of left and right heights
        diameter = Math.Max(diameter, leftHeight + rightHeight);

        // Return the height of the current node's subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a sample binary tree
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);
        root.Left.Right.Right = new Node(6);
        root.Left.Right.Right.Right = new Node(7);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Calculate the diameter of the binary tree
        int diameter = solution.DiameterOfBinaryTree(root);

        Console.WriteLine("The diameter of the binary tree is: " + diameter);
    }
}
