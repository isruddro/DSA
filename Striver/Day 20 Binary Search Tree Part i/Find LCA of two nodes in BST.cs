public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) {
            return root;
        }
        
        if (p.val < root.val && q.val < root.val) {
            return LowestCommonAncestor(root.left, p, q);
        }
        
        if (p.val > root.val && q.val > root.val) {
            return LowestCommonAncestor(root.right, p, q);
        }
        
        return root; // If one node is on the left and the other is on the right, root is the LCA
    }
}
