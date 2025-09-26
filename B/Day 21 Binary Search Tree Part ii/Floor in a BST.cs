using System;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    // Function to insert a node into the BST
    public TreeNode Insert(TreeNode root, int value) {
        if (root == null) {
            return new TreeNode(value);
        }

        if (value < root.val) {
            root.left = Insert(root.left, value);
        } else {
            root.right = Insert(root.right, value);
        }

        return root;
    }

    // Function to find the greatest value node smaller than or equal to X
    public int FindGreatestSmallerThanOrEqual(TreeNode root, int X) {
        int result = -1;
        while (root != null) {
            if (root.val <= X) {
                result = root.val;  // Current node is a candidate
                root = root.right;   // Search in the right subtree
            } else {
                root = root.left;    // Search in the left subtree
            }
        }
        return result;
    }

    // Function to process each test case
    public void ProcessTestCase(int[] nodes, int X) {
        TreeNode root = null;
        foreach (int node in nodes) {
            if (node != -1) {
                root = Insert(root, node);  // Build the BST
            }
        }
        
        int result = FindGreatestSmallerThanOrEqual(root, X);
        Console.WriteLine(result);  // Output the result
    }

    public static void Main() {
        Solution solution = new Solution();
        
        // Sample Input 1
        int[][] nodesArray1 = {
            new int[] {10, 5, 15, 2, 6, -1, -1, -1, -1, -1, -1},  // Test case 1 nodes
            new int[] {2, 1, 3, -1, -1, -1, -1}                   // Test case 2 nodes
        };
        int[] queries1 = { 7, 2 };  // Queries for Test case 1
        
        // Sample Input 2
        int[][] nodesArray2 = {
            new int[] {5, 3, 10, 2, 4, 6, 15, -1, -1, -1, -1, -1, -1, -1, -1},  // Test case 1 nodes
            new int[] {5, 3, 10, 2, 4, 6, 15, -1, -1, -1, -1, -1, -1, -1, -1}   // Test case 2 nodes
        };
        int[] queries2 = { 15, 8 };  // Queries for Test case 2

        // Process Test Case 1
        for (int i = 0; i < nodesArray1.Length; i++) {
            solution.ProcessTestCase(nodesArray1[i], queries1[i]);
        }

        // Process Test Case 2
        for (int i = 0; i < nodesArray2.Length; i++) {
            solution.ProcessTestCase(nodesArray2[i], queries2[i]);
        }
    }
}
