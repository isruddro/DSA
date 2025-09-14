https://leetcode.com/problems/binary-tree-maximum-path-sum/description/

//Any to Any
//focus on the negative so we consider that too
py:

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def __init__(self):
        self.res = float('-inf')
    
    # Recursive function to calculate maximum path sum
    def solve(self, root):
        if not root:
            return 0
        
        # Maximum path sum from left and right subtrees (discard negatives)
        left = max(0, self.solve(root.left))
        right = max(0, self.solve(root.right))
        
        # Maximum path starting from current node
        temp = max(root.val + max(left, right), root.val)
        
        # Maximum path including current node as junction
        ans = max(temp, left + right + root.val)
        
        # Update global maximum
        self.res = max(self.res, ans)
        
        return temp  # Return max sum starting from current node
    
    def maxPathSum(self, root):
        self.res = float('-inf')
        self.solve(root)
        return self.res

# Example usage
if __name__ == "__main__":
    root = TreeNode(10, 
                    TreeNode(2, TreeNode(20), TreeNode(1)), 
                    TreeNode(10, None, TreeNode(-25, TreeNode(3), TreeNode(4)))
                   )
    sol = Solution()
    print("Maximum Path Sum:", sol.maxPathSum(root))



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

    // Recursive function to calculate the maximum path sum
    int Solve(TreeNode* root) {
        if (!root) return 0;

        // Maximum path sum from left and right subtrees (discard negatives)
        int left = max(0, Solve(root->left));
        int right = max(0, Solve(root->right));

        // Maximum path starting from current node
        int temp = max(root->val + max(left, right), root->val);

        // Maximum path including current node as junction
        int ans = max(temp, left + right + root->val);

        // Update global maximum
        res = max(res, ans);

        return temp; // Return max sum starting from current node
    }

public:
    int MaxPathSum(TreeNode* root) {
        res = INT_MIN; // Initialize result to smallest possible value
        Solve(root);
        return res;
    }
};

int main() {
    // Example usage:
    TreeNode* root = new TreeNode(10, 
                         new TreeNode(2, new TreeNode(20), new TreeNode(1)), 
                         new TreeNode(10, nullptr, new TreeNode(-25, new TreeNode(3), new TreeNode(4)))
                     );

    Solution sol;
    cout << "Maximum Path Sum: " << sol.MaxPathSum(root) << endl;
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
