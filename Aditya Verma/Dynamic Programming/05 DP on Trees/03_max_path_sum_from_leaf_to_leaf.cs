//Leaf to Leaf
//so we don't consider the root, unless only one element is root. then we take that root.
cpp:
#include <bits/stdc++.h>
using namespace std;

struct Node {
    int data;
    Node* left;
    Node* right;
    Node(int val) : data(val), left(nullptr), right(nullptr) {}
};

class Solution {
private:
    int res;

    // Recursive function to calculate maximum leaf-to-leaf path sum
    int Solve(Node* root) {
        if (!root) return 0;

        int left = Solve(root->left);
        int right = Solve(root->right);

        int temp;

        // If both children exist, consider path through this node
        if (root->left && root->right) {
            res = max(res, left + right + root->data);  // Update global maximum
            temp = root->data + max(left, right);      // Return max path sum starting from this node
        }
        else if (root->left) {
            temp = root->data + left;
        }
        else if (root->right) {
            temp = root->data + right;
        }
        else { // Leaf node
            temp = root->data;
        }

        return temp;
    }

public:
    int MaxPathSum(Node* root) {
        res = INT_MIN;  // Initialize result to smallest value
        Solve(root);
        return res;
    }
};

int main() {
    // Example usage
    Node* root = new Node(-10);
    root->left = new Node(9);
    root->right = new Node(20);
    root->right->left = new Node(15);
    root->right->right = new Node(7);

    Solution sol;
    cout << "Maximum Leaf-to-Leaf Path Sum: " << sol.MaxPathSum(root) << endl;

    return 0;
}


c#:
using System;

public class Node {
    public int data;
    public Node left, right;
    
    public Node(int data) {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

public class Solution {
    private int res;

    // Recursive function to calculate the maximum path sum
    public int Solve(Node root) {
        if (root == null)
            return 0;

        // Recursively find the maximum sum of the left and right subtrees
        int left = Solve(root.left);
        int right = Solve(root.right);

        int temp;

        // If both left and right children exist, calculate the path through the current node
        if (root.left != null && root.right != null) {
            res = Math.Max(res, left + right + root.data); // Update the result if this path is larger
            temp = root.data + Math.Max(left, right); // Return the maximum path sum from this node
        }
        // If only left child exists, return the sum going through the left child
        else if (root.left != null)
            temp = root.data + left;
        // If only right child exists, return the sum going through the right child
        else if (root.right != null)
            temp = root.data + right;
        // If both children are null, return the value of the current node
        else
            temp = root.data;

        return temp;
    }

    public int MaxPathSum(Node root) {
        res = int.MinValue;  // Initialize the result to the smallest possible value
        Solve(root);  // Call the recursive function to calculate the maximum path sum
        return res;  // Return the final result
    }
}
