//Any to Any
//focus on the negative so we consider that too
using System;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode() { val = 0; left = null; right = null; }
    public TreeNode(int x) { val = x; left = null; right = null; }
    public TreeNode(int x, TreeNode left, TreeNode right) { val = x; this.left = left; this.right = right; }
}

public class Solution {
    private int res;

    // Recursive function to calculate the maximum path sum
    public int Solve(TreeNode root) {
        if (root == null) return 0;

        // Calculate the maximum path sum for the left and right subtrees
        int left = Math.Max(0, Solve(root.left));  // If negative, discard it by using Math.Max(0, ...)
        int right = Math.Max(0, Solve(root.right));  // Similarly, discard negative path sums

        // Calculate the maximum path that goes through the current node
        int temp = Math.Max(root.val + Math.Max(left, right), root.val); // Max path starting from current node
        int ans = Math.Max(temp, left + right + root.val);  // Max path that includes the current node as a junction

        // Update the result with the maximum path sum found so far
        res = Math.Max(res, ans);

        return temp;  // Return the maximum sum starting from the current node
    }

    public int MaxPathSum(TreeNode root) {
        res = int.MinValue;  // Initialize the result to the smallest possible value
        Solve(root);  // Call the helper function to calculate the max path sum
        return res;  // Return the final result
    }
}
