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

    // Recursive function to calculate the diameter
    public int Solve(TreeNode root) {
        if (root == null) return 0;

        int left = Solve(root.left);  // Height of the left subtree
        int right = Solve(root.right); // Height of the right subtree

        int temp = 1 + Math.Max(left, right); // Height of the current node
        int ans = Math.Max(temp, left + right + 1); // Maximum diameter found so far
        res = Math.Max(res, ans); // Update the result with the maximum diameter

        return temp; // Return height of the current node
    }

    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null) return 0;

        res = int.MinValue + 1; // Initialize the result variable
        Solve(root);  // Call the helper function to calculate the diameter
        return res - 1; // Subtract 1 to get the actual diameter (since we added 1 above)
    }
}
