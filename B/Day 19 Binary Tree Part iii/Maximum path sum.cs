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
    // Recursive function to find the maximum path sum
    // for a given subtree rooted at 'root'
    // The variable 'maxi' is passed by reference
    // to store the maximum path sum encountered
    public int FindMaxPathSum(TreeNode root, ref int maxi)
    {
        // Base case: If the current node is null, return 0
        if (root == null)
        {
            return 0;
        }

        // Calculate the maximum path sum for the left and right subtrees
        int leftMaxPath = Math.Max(0, FindMaxPathSum(root.Left, ref maxi));
        int rightMaxPath = Math.Max(0, FindMaxPathSum(root.Right, ref maxi));

        // Update the overall maximum path sum including the current node
        maxi = Math.Max(maxi, leftMaxPath + rightMaxPath + root.Val);

        // Return the maximum sum considering only one branch (left or right)
        // along with the current node
        return Math.Max(leftMaxPath, rightMaxPath) + root.Val;
    }

    // Function to find the maximum path sum for the entire binary tree
    public int MaxPathSum(TreeNode root)
    {
        // Initialize maxi to the minimum possible integer value
        int maxi = int.MinValue;
        
        // Call the recursive function to find the maximum path sum
        FindMaxPathSum(root, ref maxi);
        
        // Return the final maximum path sum
        return maxi;
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
        root.Left.Right.Right = new TreeNode(6);
        root.Left.Right.Right.Right = new TreeNode(7);

        // Creating an instance of the Solution class
        Solution solution = new Solution();

        // Finding and printing the maximum path sum
        int maxPathSum = solution.MaxPathSum(root);
        Console.WriteLine("Maximum Path Sum: " + maxPathSum);
    }
}
