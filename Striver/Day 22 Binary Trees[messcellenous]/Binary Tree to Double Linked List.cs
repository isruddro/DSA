public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode() {}
    public TreeNode(int val) { this.val = val; }
    public TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public void Flatten(TreeNode root) {
        while (root != null) {
            // If the left subtree is not null
            if (root.left != null) {
                // Find the rightmost node of the left subtree
                TreeNode pre = root.left;
                while (pre.right != null) {
                    pre = pre.right;
                }

                // Connect the rightmost node of the left subtree to the original right subtree
                pre.right = root.right;

                // Make the left subtree the new right subtree
                root.right = root.left;
                root.left = null; // Set the left subtree to null
            }
            // Move to the next node in the flattened structure
            root = root.right;
        }
    }
}
