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
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true; // An empty tree is a valid BST
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        TreeNode prev = null; // To keep track of the previously visited node

        while (cur != null || stack.Count > 0) {
            while (cur != null) {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Pop();

            // Check if current node's value is greater than the previously visited node's value
            if (prev != null && cur.val <= prev.val) {
                return false; // Violation of BST property
            }

            prev = cur; // Update prev to current node

            cur = cur.right; // Move to the right child
        }

        return true; // No violations found, it's a valid BST
    }
}
