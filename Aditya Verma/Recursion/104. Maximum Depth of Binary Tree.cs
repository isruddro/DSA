public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode() { }

    public TreeNode(int x) {
        val = x;
    }

    public TreeNode(int x, TreeNode left, TreeNode right) {
        this.val = x;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public int MaxDepth(TreeNode root) {
        // Base case: if root is null, depth is 0
        if (root == null) {
            return 0;
        }

        // Recursively find the max depth of the left and right subtrees
        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);

        // Return the max depth of the current tree
        return 1 + Math.Max(leftDepth, rightDepth);
    }
}
