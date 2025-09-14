leetcode.com/problems/diameter-of-binary-tree/description/

py:

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def __init__(self):
        self.res = float('-inf')
    
    # Helper function to calculate height and update diameter
    def solve(self, root):
        if not root:
            return 0

        left = self.solve(root.left)    # Height of left subtree
        right = self.solve(root.right)  # Height of right subtree

        temp = 1 + max(left, right)        # Height of current node
        ans = max(temp, left + right + 1)  # Max diameter including this node
        self.res = max(self.res, ans)      # Update global maximum

        return temp  # Return height
    
    def diameterOfBinaryTree(self, root):
        if not root:
            return 0

        self.res = float('-inf')  # Initialize result
        self.solve(root)
        return self.res - 1       # Subtract 1 to get actual diameter

# Example usage
if __name__ == "__main__":
    root = TreeNode(1,
                    TreeNode(2, TreeNode(4), TreeNode(5)),
                    TreeNode(3))
    sol = Solution()
    print("Diameter of binary tree:", sol.diameterOfBinaryTree(root))



cpp:
#include <bits/stdc++.h>
using namespace std;

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* l, TreeNode* r) : val(x), left(l), right(r) {}
};

class Solution {
private:
    int res;

    // Recursive helper function to calculate height and update diameter
    int Solve(TreeNode* root) {
        if (!root) return 0;

        int left = Solve(root->left);   // Height of left subtree
        int right = Solve(root->right); // Height of right subtree

        int temp = 1 + max(left, right);       // Height of current node
        int ans = max(temp, left + right + 1); // Max diameter including this node
        res = max(res, ans);                   // Update global maximum

        return temp; // Return height
    }

public:
    int DiameterOfBinaryTree(TreeNode* root) {
        if (!root) return 0;
        res = INT_MIN + 1; // Initialize result
        Solve(root);
        return res - 1;    // Subtract 1 to get actual diameter
    }
};

int main() {
    // Example usage:
    TreeNode* root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
    Solution sol;
    cout << "Diameter of binary tree: " << sol.DiameterOfBinaryTree(root) << endl;
    return 0;
}



c#:

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
