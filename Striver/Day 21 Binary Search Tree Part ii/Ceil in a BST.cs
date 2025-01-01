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

    // Function to find the ceil of the key in the BST
    public int FindCeil(TreeNode root, int key) {
        int ceil = -1; // Initialize ceil as -1 (in case no ceil is found)
        
        while (root != null) {
            if (root.val == key) {
                return root.val; // If the key itself is found, it is the ceil
            } else if (root.val > key) {
                ceil = root.val; // Potential candidate for ceil
                root = root.left; // Move to left to find a smaller candidate
            } else {
                root = root.right; // Move to right as key is smaller than current node
            }
        }

        return ceil; // Return the ceil value found
    }

    // Function to process each test case
    public void ProcessTestCase(int[] nodes, int X) {
        TreeNode root = null;
        foreach (int node in nodes) {
            if (node != -1) {
                root = Insert(root, node);  // Build the BST
            }
        }

        int result = FindCeil(root, X); // Find the ceil for the key X
        Console.WriteLine(result);  // Output the result
    }

    public static void Main() {
        Solution solution = new Solution();

        // Sample Input 1
        int[][] nodesArray1 = {
            new int[] {8, 5, 10, 2, 6, -1, -1, -1, -1, -1, 7, -1, -1},  // Test case 1 nodes
            new int[] {8, 5, 10, 2, 6, -1, -1, -1, -1, -1, 7, -1, -1}   // Test case 2 nodes
        };
        int[] queries1 = { 4, 7 };  // Queries for Test case 1

        // Sample Input 2
        int[][] nodesArray2 = {
            new int[] {55, 25, 82, 13, 34, 67, 86, 6, 21, 28, 47, 61, 70, 84, 92, 1, 10, 17, 24, 26, 29, 45, 54, 56, 65, 68, 81, 83, 85, 91, -1},  // Test case 1 nodes
            new int[] {84, 19, 97, 0, 56, 96, 99, -1, 8, 50, 83, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}  // Test case 2 nodes
        };
        int[] queries2 = { 34, 50 };  // Queries for Test case 2

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
