https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
py:
# Definition for a binary tree node
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def maxDepth(self, root: TreeNode) -> int:
        # Base case: if root is None, depth is 0
        if not root:
            return 0

        # Recursively compute the depth of left and right subtrees
        left_depth = self.maxDepth(root.left)
        right_depth = self.maxDepth(root.right)

        # Return max depth plus 1 for current node
        return 1 + max(left_depth, right_depth)

# Example usage
if __name__ == "__main__":
    root = TreeNode(1)
    root.left = TreeNode(2)
    root.right = TreeNode(3)
    root.left.left = TreeNode(4)
    root.left.right = TreeNode(5)

    sol = Solution()
    print("Maximum Depth:", sol.maxDepth(root))



cpp:
#include <bits/stdc++.h>
using namespace std;

// Definition for a binary tree node
struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;

    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* l, TreeNode* r) : val(x), left(l), right(r) {}
};

class Solution {
public:
    int maxDepth(TreeNode* root) {
        // Base case: if root is null, depth is 0
        if (root == nullptr) return 0;

        // Recursively find the max depth of left and right subtrees
        int leftDepth = maxDepth(root->left);
        int rightDepth = maxDepth(root->right);

        // Return the max depth plus 1 for the current node
        return 1 + max(leftDepth, rightDepth);
    }
};

// Example usage:
int main() {
    TreeNode* root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(3);
    root->left->left = new TreeNode(4);
    root->left->right = new TreeNode(5);

    Solution sol;
    cout << "Maximum Depth: " << sol.maxDepth(root) << endl;

    return 0;
}


c#:
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
