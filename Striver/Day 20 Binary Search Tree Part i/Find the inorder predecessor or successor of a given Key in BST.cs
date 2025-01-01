public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public void InOrderPredecessorAndSuccessor(TreeNode root, int key, out int predecessor, out int successor) {
        predecessor = -1; // Default for not found
        successor = -1; // Default for not found
        TreeNode cur = root;
        TreeNode lastLeft = null, lastRight = null;

        // Traverse the tree to find the node with the given key
        while (cur != null) {
            if (key < cur.val) {
                successor = cur.val; // Successor could be current node
                cur = cur.left;
            }
            else if (key > cur.val) {
                predecessor = cur.val; // Predecessor could be current node
                cur = cur.right;
            }
            else {
                // When we find the node, we check for its predecessor and successor
                if (cur.left != null) {
                    lastLeft = cur.left;
                    while (lastLeft.right != null) {
                        lastLeft = lastLeft.right;
                    }
                    predecessor = lastLeft.val;
                }
                
                if (cur.right != null) {
                    lastRight = cur.right;
                    while (lastRight.left != null) {
                        lastRight = lastRight.left;
                    }
                    successor = lastRight.val;
                }
                break;
            }
        }
    }
}
